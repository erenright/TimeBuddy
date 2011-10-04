/*
 * TimeBuddy.cs
 * 
 * Copyright (C) 2011 5amsoftware
 * 
 * All rights reserved.  Distribution an modification strictly prohibited.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace TimeBuddy
{
    public class TimeBuddy : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private System.Timers.Timer timer;
        private int saveCounter = 0;
        private Boolean _paused = false;
        private DateTime lastTick;

        // Icons used by the system tray icon
        private Icon normalIcon;
        private Icon pausedIcon;

        private Settings _settings = new Settings();

        public Settings Settings
        {
            get { return _settings; }
        }

        private Boolean Paused
        {
            get { return _paused; }

            set
            {
                _paused = value;

                if (_paused)
                {
                    timer.Stop();
                    trayIcon.Text = "Paused";
                    trayIcon.Icon = pausedIcon;
                }
                else
                {
                    // Before starting the timer up again, we must reset
                    // |lastTick| to the current time in order to prevent
                    // the end-of-day prompt from potentially displaying
                    // (if timer is paused during 4pm and unpaused during
                    // 5pm)
                    lastTick = System.DateTime.Now;

                    trayIcon.Icon = normalIcon;
                    timer.Start();
                }
            }
        }

        public TimeBuddy()
        {
            // The normal icon comes from the SettingsForm, which the paused icon is a custom resource
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            normalIcon = (Icon)resources.GetObject("$this.Icon");
            pausedIcon = Properties.Resources.PausedIcon;

            trayMenu = new ContextMenu();
            trayMenu.Popup += new EventHandler(trayMenu_Popup);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "TimeBuddy";
            //trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.Icon = normalIcon; // normalIcon;

            trayIcon.ContextMenu = trayMenu;
            trayIcon.MouseDoubleClick += new MouseEventHandler(trayIcon_MouseDoubleClick);
            trayIcon.MouseClick += new MouseEventHandler(trayIcon_MouseClick);

            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimerTick);
            timer.Interval = 1000; // 1 second
            lastTick = System.DateTime.Now;

            try
            {
                LoadSettings();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load saved tasks. Starting fresh.", "TimeBuddy", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Default tasks
                Settings.Tasks = new List<Task>();
                Task t = new Task("Away from Desk");
                Settings.Tasks.Add(t);
                t = new Task("Lunch/Break");
                Settings.Tasks.Add(t);

                // Default times
                Settings.StartHour = 8;
                Settings.StartMinute = 30;
                Settings.EndHour = 17;
                Settings.EndMinute = 0;
            }

            // Enable the timer only after everything has been loaded
            trayIcon.Visible = true;
            timer.Enabled = true;
        }

        void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            System.Reflection.MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            mi.Invoke(trayIcon, null);
        }

        void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form f = new SettingsForm(this);
            f.Show();
        }

        public void RebuildMenu()
        {
            trayMenu.MenuItems.Clear();

            foreach (Task task in _settings.Tasks)
            {
                MenuItem item = new MenuItem(task.Name, task_Click);
                if (task.Active)
                    item.Checked = true;
                trayMenu.MenuItems.Add(item);
            }

            trayMenu.MenuItems.Add("-");

            MenuItem p = new MenuItem("Pause", MenuPause);
            p.Checked = Paused;

            trayMenu.MenuItems.Add(p);
            trayMenu.MenuItems.Add("Report...", MenuReport);
            trayMenu.MenuItems.Add("Settings...", MenuSettings);
            trayMenu.MenuItems.Add("Quit", OnExit);
        }

        /***************************************************************
         * OnTimerTick()
         * 
         *   Timer tick handler.  Performs the following tasks:
         *   
         *     1. Updates the icon tooltip with the current task.
         *     2. Ticks each task.
         *     3. Saves the counters to disk once per minute.
         *     4. Checks if we have transitioned from 4:59pm to
         *        5pm, and if so, pause the counter and prompt the
         *        user to continue.
         */
        private void OnTimerTick(object source, ElapsedEventArgs e)
        {
            foreach (Task task in _settings.Tasks)
            {
                task.Tick();

                if (task.Active)
                    trayIcon.Text = task.ToString();
            }

            // Save tasks once per minute
            if (++saveCounter >= 60)
            {
                saveCounter = 0;

                try
                {
                    SaveSettings();
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to save tasks.", "TimeBuddy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //
            // After-hours transition testing
            //

            DateTime now = System.DateTime.Now;

            // Scale back one hour/minute
            int endHourPrev = Settings.EndHour;
            int endMinutePrev = Settings.EndMinute;

            // If we are aligned on an hour
            if (endMinutePrev == 0)
            {
                // Scale back the hour and use 59 minutes
                if (endHourPrev == 0)
                    endHourPrev = 23;
                else
                    --endHourPrev;

                endMinutePrev = 59;
            }
            else
            {
                // Otherwise, scale back the minute
                --endMinutePrev;
            }

            // Have we transitioned to after-hours?
            if ((lastTick.Hour == endHourPrev && now.Hour == Settings.EndHour)
                && (lastTick.Minute == endMinutePrev && now.Minute == Settings.EndMinute))
            {
                // Yes
                lastTick = now;

                Paused = true;

                DialogResult res = MessageBox.Show("Looks like your work day is done. The timer has been paused.\n\nStart it back up?",
                    "TimeBuddy", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (res == DialogResult.Yes)
                    Paused = false;

                RebuildMenu();
            }
            else
            {
                lastTick = now;
            }
        }

        private void task_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            foreach (Task task in _settings.Tasks)
            {
                task.Active = false;

                if (task.Name == item.Text)
                {
                    task.Active = true;
                }
            }
        }

        private void trayMenu_Popup(object sender, EventArgs e)
        {
            RebuildMenu();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);
        }

        private void MenuPause(object sender, EventArgs e)
        {
            if (Paused)
                Paused = false;
            else
                Paused = true;

            RebuildMenu();
        }

        private void MenuSettings(object sender, EventArgs e)
        {
            Form f = new SettingsForm(this);
            f.Show();
        }

        private void MenuReport(object sender, EventArgs e)
        {
            Form f = new ReportForm(this);
            f.Show();
        }

        private void OnExit(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to save tasks.", "TimeBuddy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                trayIcon.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeBuddy));
            this.SuspendLayout();
            // 
            // TimeBuddy
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeBuddy";
            this.ResumeLayout(false);

        }

        /*
         * Save user settings.  This simply uses an XmlSerializer.
         */
        public void SaveSettings()
        {
            TextWriter w = null;

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(Settings));
                w = new StreamWriter(Application.UserAppDataPath + @"\\..\\tasks.xml");
                s.Serialize(w, Settings);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (w != null)
                    w.Close();
            }
        }

        /*
         * Load settings.  Because we want to allow upgrades from previous
         * versions, we do no use XmlSerializer here but instead use the
         * Settings class itself.  Any exceptions are propogated out.
         */
        public void LoadSettings()
        {
            _settings = new Settings();
            if (_settings.Load(Application.UserAppDataPath + @"\..\tasks.xml"))
            {
                // Previous version was imported
                MessageBox.Show("Settings from a previous version were found and have been imported.",
                    "TimeBuddy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
