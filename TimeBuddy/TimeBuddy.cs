using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using System.Xml.Serialization;
using System.IO;

namespace TimeBuddy
{
    public class TimeBuddy : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private System.Timers.Timer timer;
        private int saveCounter = 0;
        private Boolean paused = false;

        private List<Task> _tasks = new List<Task>();

        public List<Task> Tasks
        {
            get
            {
                return _tasks;
            }
        }

        public TimeBuddy()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));

            trayMenu = new ContextMenu();
            trayMenu.Popup += new EventHandler(trayMenu_Popup);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "TimeBuddy";
            //trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            trayIcon.ContextMenu = trayMenu;
            trayIcon.MouseDoubleClick += new MouseEventHandler(trayIcon_MouseDoubleClick);
            trayIcon.MouseClick += new MouseEventHandler(trayIcon_MouseClick);
            trayIcon.Visible = true;

            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimerTick);
            timer.Interval = 1000; // 1 second
            timer.Enabled = true;

            try
            {
                _tasks = DeserializeFromXml();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load saved tasks. Starting fresh.", "TimeBuddy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _tasks = new List<Task>();

                Task t = new Task("Away from Desk");
                _tasks.Add(t);
                t = new Task("Lunch/Break");
                _tasks.Add(t);
            }
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

            foreach (Task task in _tasks)
            {
                MenuItem item = new MenuItem(task.Name, task_Click);
                if (task.Active)
                    item.Checked = true;
                trayMenu.MenuItems.Add(item);
            }

            trayMenu.MenuItems.Add("-");

            MenuItem p = new MenuItem("Pause", MenuPause);
            p.Checked = paused;

            trayMenu.MenuItems.Add(p);
            trayMenu.MenuItems.Add("Report...", MenuReport);
            trayMenu.MenuItems.Add("Settings...", MenuSettings);
            trayMenu.MenuItems.Add("Quit", OnExit);
        }

        private void OnTimerTick(object source, ElapsedEventArgs e)
        {
            foreach (Task task in _tasks)
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
                    SerializeToXML(_tasks);
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to save tasks.", "TimeBuddy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void task_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            foreach (Task task in _tasks)
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
            if (paused)
            {
                paused = false;
                timer.Start();
            }
            else
            {
                paused = true;
                timer.Stop();
            }

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
                SerializeToXML(_tasks);
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

        private void SerializeToXML(List<Task> tasks)
        {
            XmlSerializer s = new XmlSerializer(typeof(List<Task>));
            TextWriter w = new StreamWriter(Application.UserAppDataPath + @"\\..\\tasks.xml");
            s.Serialize(w, tasks);
            w.Close();
        }

        private List<Task> DeserializeFromXml()
        {
            XmlSerializer s = new XmlSerializer(typeof(List<Task>));
            TextReader r = new StreamReader(Application.UserAppDataPath + @"\\..\\tasks.xml");
            List<Task> tasks;
            tasks = (List<Task>)s.Deserialize(r);
            r.Close();

            // Ensure no tasks are active
            foreach (Task t in tasks)
                t.Active = false;

            return tasks;
        }
    }
}
