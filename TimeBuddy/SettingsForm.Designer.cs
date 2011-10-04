namespace TimeBuddy
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.numAdjust = new System.Windows.Forms.NumericUpDown();
            this.txtNewTask = new System.Windows.Forms.TextBox();
            this.btnRemoveTime = new System.Windows.Forms.Button();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.btnClearCounters = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTasks = new System.Windows.Forms.TabPage();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.dtpDayEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDayEnd = new System.Windows.Forms.Label();
            this.dtpDayStart = new System.Windows.Forms.DateTimePicker();
            this.lblDayStart = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAdjust)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageTasks.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // numAdjust
            // 
            this.numAdjust.Location = new System.Drawing.Point(162, 207);
            this.numAdjust.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAdjust.Name = "numAdjust";
            this.numAdjust.Size = new System.Drawing.Size(71, 20);
            this.numAdjust.TabIndex = 6;
            // 
            // txtNewTask
            // 
            this.txtNewTask.Location = new System.Drawing.Point(81, 237);
            this.txtNewTask.Name = "txtNewTask";
            this.txtNewTask.Size = new System.Drawing.Size(242, 20);
            this.txtNewTask.TabIndex = 5;
            this.txtNewTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewTask_KeyPress);
            // 
            // btnRemoveTime
            // 
            this.btnRemoveTime.Location = new System.Drawing.Point(239, 206);
            this.btnRemoveTime.Name = "btnRemoveTime";
            this.btnRemoveTime.Size = new System.Drawing.Size(84, 23);
            this.btnRemoveTime.TabIndex = 4;
            this.btnRemoveTime.Text = "Remove Time";
            this.btnRemoveTime.UseVisualStyleBackColor = true;
            this.btnRemoveTime.Click += new System.EventHandler(this.btnRemoveTime_Click);
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(81, 205);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(75, 23);
            this.btnAddTime.TabIndex = 3;
            this.btnAddTime.Text = "Add Time";
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(0, 205);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTask.TabIndex = 2;
            this.btnRemoveTask.Text = "Remove";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(0, 234);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 1;
            this.btnAddTask.Text = "Add";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.AllowDrop = true;
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(0, 0);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTasks.Size = new System.Drawing.Size(323, 199);
            this.lstTasks.TabIndex = 0;
            this.lstTasks.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstTasks_DragDrop);
            this.lstTasks.DragOver += new System.Windows.Forms.DragEventHandler(this.lstTasks_DragOver);
            this.lstTasks.DoubleClick += new System.EventHandler(this.lstTasks_DoubleClick);
            this.lstTasks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstTasks_MouseDown);
            // 
            // btnClearCounters
            // 
            this.btnClearCounters.Location = new System.Drawing.Point(355, 31);
            this.btnClearCounters.Name = "btnClearCounters";
            this.btnClearCounters.Size = new System.Drawing.Size(89, 23);
            this.btnClearCounters.TabIndex = 1;
            this.btnClearCounters.Text = "Clear Counters";
            this.btnClearCounters.UseVisualStyleBackColor = true;
            this.btnClearCounters.Click += new System.EventHandler(this.btnClearCounters_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(355, 60);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(89, 23);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "About...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(355, 118);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(89, 23);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Report...";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTasks);
            this.tabControl1.Controls.Add(this.tabPageOptions);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(334, 286);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPageTasks
            // 
            this.tabPageTasks.Controls.Add(this.numAdjust);
            this.tabPageTasks.Controls.Add(this.lstTasks);
            this.tabPageTasks.Controls.Add(this.txtNewTask);
            this.tabPageTasks.Controls.Add(this.btnAddTask);
            this.tabPageTasks.Controls.Add(this.btnRemoveTime);
            this.tabPageTasks.Controls.Add(this.btnRemoveTask);
            this.tabPageTasks.Controls.Add(this.btnAddTime);
            this.tabPageTasks.Location = new System.Drawing.Point(4, 22);
            this.tabPageTasks.Name = "tabPageTasks";
            this.tabPageTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTasks.Size = new System.Drawing.Size(326, 260);
            this.tabPageTasks.TabIndex = 0;
            this.tabPageTasks.Text = "Tasks";
            this.tabPageTasks.UseVisualStyleBackColor = true;
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.Controls.Add(this.dtpDayEnd);
            this.tabPageOptions.Controls.Add(this.lblDayEnd);
            this.tabPageOptions.Controls.Add(this.dtpDayStart);
            this.tabPageOptions.Controls.Add(this.lblDayStart);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(326, 260);
            this.tabPageOptions.TabIndex = 1;
            this.tabPageOptions.Text = "Options";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // dtpDayEnd
            // 
            this.dtpDayEnd.CustomFormat = "hh:mm tt";
            this.dtpDayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDayEnd.Location = new System.Drawing.Point(77, 34);
            this.dtpDayEnd.Name = "dtpDayEnd";
            this.dtpDayEnd.ShowUpDown = true;
            this.dtpDayEnd.Size = new System.Drawing.Size(75, 20);
            this.dtpDayEnd.TabIndex = 3;
            this.dtpDayEnd.Value = new System.DateTime(2011, 9, 22, 17, 0, 0, 0);
            // 
            // lblDayEnd
            // 
            this.lblDayEnd.AutoSize = true;
            this.lblDayEnd.Location = new System.Drawing.Point(7, 38);
            this.lblDayEnd.Name = "lblDayEnd";
            this.lblDayEnd.Size = new System.Drawing.Size(61, 13);
            this.lblDayEnd.TabIndex = 2;
            this.lblDayEnd.Text = "End of day:";
            // 
            // dtpDayStart
            // 
            this.dtpDayStart.CustomFormat = "hh:mm tt";
            this.dtpDayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDayStart.Location = new System.Drawing.Point(77, 8);
            this.dtpDayStart.Name = "dtpDayStart";
            this.dtpDayStart.ShowUpDown = true;
            this.dtpDayStart.Size = new System.Drawing.Size(75, 20);
            this.dtpDayStart.TabIndex = 1;
            this.dtpDayStart.Value = new System.DateTime(2011, 9, 22, 8, 30, 0, 0);
            // 
            // lblDayStart
            // 
            this.lblDayStart.AutoSize = true;
            this.lblDayStart.Location = new System.Drawing.Point(7, 12);
            this.lblDayStart.Name = "lblDayStart";
            this.lblDayStart.Size = new System.Drawing.Size(64, 13);
            this.lblDayStart.TabIndex = 0;
            this.lblDayStart.Text = "Start of day:";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(355, 89);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(89, 23);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 310);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnClearCounters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "TimeBuddy Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAdjust)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageTasks.ResumeLayout(false);
            this.tabPageTasks.PerformLayout();
            this.tabPageOptions.ResumeLayout(false);
            this.tabPageOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveTime;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Button btnClearCounters;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.TextBox txtNewTask;
        private System.Windows.Forms.NumericUpDown numAdjust;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTasks;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.DateTimePicker dtpDayEnd;
        private System.Windows.Forms.Label lblDayEnd;
        private System.Windows.Forms.DateTimePicker dtpDayStart;
        private System.Windows.Forms.Label lblDayStart;
        private System.Windows.Forms.Button btnHelp;
    }
}

