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
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            lstTasks.DataSource = _timeBuddy.Tasks;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtNewTask.Text.Length > 0)
            {
                _timeBuddy.Tasks.Add(new Task(txtNewTask.Text));
                txtNewTask.Text = "";
                ReloadTasks();
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            foreach (Task task in lstTasks.SelectedItems)
            {
                _timeBuddy.Tasks.Remove(task);
            }

            ReloadTasks();
        }

        private void ReloadTasks()
        {
            lstTasks.DataSource = null;
            lstTasks.DataSource = _timeBuddy.Tasks;
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
            foreach (Task task in _timeBuddy.Tasks)
            {
                task.Clear();
            }

            ReloadTasks();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string msg = String.Format("TimeBuddy version {0}", GetType().Assembly.GetName().Version.ToString());
            MessageBox.Show(msg, "About");
        }

        private void txtNewTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnAddTask_Click(sender, e);
        }

    }
}
