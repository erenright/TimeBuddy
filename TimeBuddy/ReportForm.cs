﻿/*
 * Copyright (c) 2011-2020, Eric Enright
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *
 *     * Neither the name of Eric Enright nor the
 *       names of his contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL ERIC ENRIGHT BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

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
        /// <summary>
        /// The minimum number of seconds required to consider an item
        /// </summary>
        private const int minimumSeconds = (60 * 5);

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
            int totalTime = 0;
            int lostTime = 0;

            // Clone tasks
            List<Task> sourceTasks = _timeBuddy.Settings.Tasks.GetRange(0, _timeBuddy.Settings.Tasks.Count);
            List<Task> tasks = new List<Task>();

            // Construct initial task list
            foreach (Task task in sourceTasks)
            {
                // If the item has more than 5 minutes against it, count it
                if (task.RawSeconds >= minimumSeconds)
                    tasks.Add(task);
                else
                    lostTime += task.RawSeconds;
            }

            Hashtable summary = new Hashtable();
            foreach (Task task in tasks)
            {
                // Does this look like a project?
                if (Regex.Match(task.Name, @"^\d+\S*\s").Success)
                {
                    // Task begins with numbers, extract them
                    string project = Regex.Replace(task.Name, @"^(\d+\S*).*", "$1");
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

                // Tally total time
                totalTime += task.RawSeconds;
            }

            foreach (string project in summary.Keys)
            {
                Task task = new Task("[summary] " + project);
                int seconds = (int)summary[project];

                if (_timeBuddy.Settings.RoundSummaries)
                {
                    // Rounding algorithm is as follows:
                    //
                    //    divide tabulated time by the round point, saving the remainder
                    //    the remainder is divided by the round point
                    //    if the dividend is greater than or equal to 0.5, round up
                    //    otherwise, round down
                    int roundPoint = _timeBuddy.Settings.SummaryRoundPoint * 60;

                    int remainder = seconds % roundPoint;
                    double dividend = (double)remainder / roundPoint;

                    if (dividend >= 0.5)
                    {
                        seconds += roundPoint - remainder;
                        lostTime -= roundPoint - remainder;
                    }
                    else
                    {
                        seconds -= remainder;
                        lostTime += remainder;
                    }
                }

                if (seconds >= minimumSeconds)
                {
                    task.RawSeconds = seconds;
                    tasks.Add(task);
                }
            }

            // Add fake [total] task
            Task totalTask = new Task("[total]");
            totalTask.RawSeconds = totalTime;
            tasks.Add(totalTask);

            if (_timeBuddy.Settings.RoundSummaries)
            {
                // Add fake [lost] task
                Task lostTask = new Task("[lost]");
                lostTask.RawSeconds = lostTime;
                tasks.Add(lostTask);
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
