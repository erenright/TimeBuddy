using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TimeBuddy
{
    public partial class SettingsForm : Form
    {
        [DllImport("user32.dll")]
        static extern short GetKeyState(int key);

        private TimeBuddy _timeBuddy;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(TimeBuddy timeBuddy)
        {
            InitializeComponent();

            _timeBuddy = timeBuddy;

            // Copy in settings
            DateTime dt = new DateTime(2011, 9, 22, _timeBuddy.Settings.StartHour, _timeBuddy.Settings.StartMinute, 0);
            dtpDayStart.Value = dt;
            dt = new DateTime(2011, 9, 22, _timeBuddy.Settings.EndHour, _timeBuddy.Settings.EndMinute, 0);
            dtpDayEnd.Value = dt;
            chkHourlyReminder.Checked = _timeBuddy.Settings.HourlyReminderEnabled;
            txtHourlyReminder.Text = _timeBuddy.Settings.HourlyReminder;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            lstTasks.DataSource = _timeBuddy.Settings.Tasks;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtNewTask.Text.Length > 0)
            {
                // Mark old tasks inactive
                foreach (Task task in _timeBuddy.Settings.Tasks)
                    task.Active = false;

                // Create new task
                Task newTask = new Task(txtNewTask.Text);
                _timeBuddy.Settings.Tasks.Add(newTask);
                txtNewTask.Text = "";

                // New task is active
                newTask.Active = true;

                ReloadTasks();
            }
        }

        private void RemoveTasks()
        {
            foreach (Task task in lstTasks.SelectedItems)
            {
                // If this task is active, pause the timer
                if (task.Active)
                    _timeBuddy.Paused = true;

                _timeBuddy.Settings.Tasks.Remove(task);
            }

            ReloadTasks();
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            DialogResult res;
            string msg = "Are you sure you want to delete the selected ";

            if (lstTasks.SelectedItems.Count <= 0)
                return;
            else if (lstTasks.SelectedItems.Count == 1)
                msg += "item?\r\n\r\nNote: You can select more than one.";
            else
                msg += "items?";

            res = MessageBox.Show(msg, "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes)
            {
                RemoveTasks();
            }
        }

        private void ReloadTasks()
        {
            // Remember currently selected index
            int idx = lstTasks.SelectedIndex;

            lstTasks.DataSource = null;
            lstTasks.DataSource = _timeBuddy.Settings.Tasks;
            lstTasks.SelectedItems.Clear();

            // Restore selected index if valid
            if (idx >= 0)
            {
                if (idx >= lstTasks.Items.Count)
                    lstTasks.SelectedIndex = lstTasks.Items.Count - 1;
                else
                    lstTasks.SelectedIndex = idx;
            }
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            foreach (Task task in lstTasks.SelectedItems)
            {
                task.Adjust(Convert.ToInt32(numAdjust.Value) * 60);
            }

            ReloadTasks();
        }

        private void btnRemoveTime_Click(object sender, EventArgs e)
        {
            foreach (Task task in lstTasks.SelectedItems)
            {
                task.Adjust(-Convert.ToInt32(numAdjust.Value) * 60);
            }

            ReloadTasks();
        }

        private void btnClearCounters_Click(object sender, EventArgs e)
        {
            DialogResult res;
            string msg = "Are you sure you want to clear counters for all items?";
            res = MessageBox.Show(msg, "Confirm clear", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes)
            {
                foreach (Task task in _timeBuddy.Settings.Tasks)
                {
                    task.Clear();
                }

                ReloadTasks();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string version = GetType().Assembly.GetName().Version.ToString();

            // Strip 4th number because we don't use it
            version = version.Substring(0, version.Length - 2);

            string msg = String.Format("TimeBuddy version {0}\n\nCopyright © 2011 5amsoftware",
                version);
            MessageBox.Show(msg, "About");
        }

        /***************************************************************
         * txtNewTask_KeyPress()
         * 
         *   |KeyPRess| handler for |txtNewTask|.  Wrapper around clicking
         *   the "Add" button (add task to list) when ENTER is pressed.
         */
        private void txtNewTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnAddTask_Click(sender, e);
        }

        /***************************************************************
         * lstTasks_DoubleClick()
         * 
         *   |DoubleClick| handler for |lstTasks|.  Opens a dialog that
         *   allows the user to rename the current task.
         */
        private void lstTasks_DoubleClick(object sender, EventArgs e)
        {
            Task task = (Task)lstTasks.SelectedItem;
            if (task == null)
                return;

            // Prompt the user to rename the task
            RenameTaskDialog dlg = new RenameTaskDialog(task);
            dlg.ShowDialog();

            // Reload tasks in case the name changed.
            ReloadTasks();
        }

        /***************************************************************
         * btnSettings_Click()
         * 
         *   |Click| event handler for |btnReport|.  Generates a new
         *   report dialog.
         */
        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportForm frm = new ReportForm(_timeBuddy);
            frm.Show();
        }

        /***************************************************************
         * SettingsForm_FormClosing()
         * 
         *   |FormClosing| event handler for the form.  Passes all user
         *   options back up to TimeBuddy.
         */
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timeBuddy.Settings.StartHour = dtpDayStart.Value.Hour;
            _timeBuddy.Settings.StartMinute = dtpDayStart.Value.Minute;
            _timeBuddy.Settings.EndHour = dtpDayEnd.Value.Hour;
            _timeBuddy.Settings.EndMinute = dtpDayEnd.Value.Minute;
            _timeBuddy.Settings.HourlyReminderEnabled = chkHourlyReminder.Checked;
            _timeBuddy.Settings.HourlyReminder = txtHourlyReminder.Text.Trim();
        }

        /***************************************************************
         * btnHelp_Click()
         * 
         *   |Click| event handler for |btnHelp|.  Opens up
         *   "TimeBuddy Help.chm"
         */
        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("TimeBuddy Help.chm");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open help file.");
            }
        }

        /*
         * Starts up drag and drop for reordering tasks.
         */
        private void lstTasks_MouseDown(object sender, MouseEventArgs e)
        {
            bool ctrlPressed = false;
            bool shiftPressed = false;

            short k = GetKeyState(0x10);    // Shift
            if (k != 0 && k != 1)
                shiftPressed = true;

            k = GetKeyState(0x11);          // Control
            if (k != 0 && k != 1)
                ctrlPressed = true;

            // Only look at doing a drag and drop for a single click.
            // Control and Shift keys must not be down, otherwise this
            // indicates item selection
            if (e.Button == MouseButtons.Left && e.Clicks == 1
                && !(shiftPressed || ctrlPressed))
            {
                if (lstTasks.SelectedItem == null)
                    return;

                lstTasks.DoDragDrop(lstTasks.SelectedItem, DragDropEffects.Move);
            }
        }

        /*
         * Repositions the "moving" bar when dragging and dropping.
         */
        private void lstTasks_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /*
         * Completes the drag and drop function, moving the selected task.
         */
        private void lstTasks_DragDrop(object sender, DragEventArgs e)
        {
            // Find our newly selected index
            Point point = lstTasks.PointToClient(new Point(e.X, e.Y));
            int index = lstTasks.IndexFromPoint(point);

            // If an invalid slot is selected, default to the end
            if (index < 0)
                index = lstTasks.Items.Count - 1;

            // Move the task
            Task task = (Task)e.Data.GetData(typeof(Task));
            _timeBuddy.Settings.Tasks.Remove(task);
            _timeBuddy.Settings.Tasks.Insert(index, task);

            ReloadTasks();
        }

        /*
         * If the delete key was pressed, delete the selected task(s).
         */
        private void lstTasks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveTasks();
        }

    }
}
