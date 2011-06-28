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
            grid.DataSource = _timeBuddy.Tasks;
            grid.Columns.Clear();

            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "Name";
            c.HeaderText = "Task";
            c.Width = (grid.Width / 2) + 100;
            grid.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "HHMM";
            c.HeaderText = "HH:MM";
            c.Width = 50;
            grid.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.DataPropertyName = "HoursFractional";
            c.HeaderText = "Hours";
            c.Width = 50;
            grid.Columns.Add(c);
        }
    }
}
