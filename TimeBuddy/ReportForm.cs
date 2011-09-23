using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TimeBuddy
{
    public partial class ReportForm : Form
    {
        TimeBuddy _timeBuddy;

        public ReportForm()
        {
            InitializeComponent();
        }

        public ReportForm(TimeBuddy timeBuddy)
        {
            InitializeComponent();

            _timeBuddy = timeBuddy;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Clone tasks
            List<Task> sourceTasks = _timeBuddy.Settings.Tasks.GetRange(0, _timeBuddy.Settings.Tasks.Count);
            List<Task> tasks = new List<Task>();

            // Construct initial task list
            foreach (Task task in sourceTasks)
            {
                // If the item has time against it, count it
                if (task.RawSeconds > 0)
                    tasks.Add(task);
            }

            Hashtable summary = new Hashtable();
            foreach (Task task in tasks)
            {
                // Does this look like a project?
                if (Regex.Match(task.Name, @"^\d+\s").Success)
                {
                    // Task begins with numbers, extract them
                    string project = Regex.Replace(task.Name, @"^(\d+)\s.*", "$1");
                    if (summary.Contains(project))
                    {
                        int r = (int)summary[project];
                        r += task.RawSeconds;
                        summary[project] = r;
                    }
                    else
                    {
                        summary.Add(project, task.RawSeconds);
                    }
                }
            }

            foreach (string project in summary.Keys)
            {
                Task task = new Task("[summary] " + project);
                task.RawSeconds = (int)summary[project];
                tasks.Add(task);
            }

            // We have all tasks, so go forward with the grid
            grid.DataSource = tasks;
            grid.Columns.Clear();

            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Name";
            c.HeaderText = "Task";
            grid.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "HHMM";
            c.HeaderText = "HH:MM";
            grid.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "HoursFractional";
            c.HeaderText = "Hours";
            grid.Columns.Add(c);
        }
    }
}
