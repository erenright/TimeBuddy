using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeBuddy
{
    public partial class SettingsForm : Form
    {
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
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            lstTasks.DataSource = _timeBuddy.Settings.Tasks;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtNewTask.Text.Length > 0)
            {
                _timeBuddy.Settings.Tasks.Add(new Task(txtNewTask.Text));
                txtNewTask.Text = "";
                ReloadTasks();
            }
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
                foreach (Task task in lstTasks.SelectedItems)
                {
                    _timeBuddy.Settings.Tasks.Remove(task);
                }

                ReloadTasks();
            }
        }

        private void ReloadTasks()
        {
            lstTasks.DataSource = null;
            lstTasks.DataSource = _timeBuddy.Settings.Tasks;
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

    }
}
