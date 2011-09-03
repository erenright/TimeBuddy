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
            this.grpTasks = new System.Windows.Forms.GroupBox();
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
            this.grpTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdjust)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTasks
            // 
            this.grpTasks.Controls.Add(this.numAdjust);
            this.grpTasks.Controls.Add(this.txtNewTask);
            this.grpTasks.Controls.Add(this.btnRemoveTime);
            this.grpTasks.Controls.Add(this.btnAddTime);
            this.grpTasks.Controls.Add(this.btnRemoveTask);
            this.grpTasks.Controls.Add(this.btnAddTask);
            this.grpTasks.Controls.Add(this.lstTasks);
            this.grpTasks.Location = new System.Drawing.Point(12, 12);
            this.grpTasks.Name = "grpTasks";
            this.grpTasks.Size = new System.Drawing.Size(337, 282);
            this.grpTasks.TabIndex = 0;
            this.grpTasks.TabStop = false;
            this.grpTasks.Text = "Tasks";
            // 
            // numAdjust
            // 
            this.numAdjust.Location = new System.Drawing.Point(168, 226);
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
            this.txtNewTask.Location = new System.Drawing.Point(87, 256);
            this.txtNewTask.Name = "txtNewTask";
            this.txtNewTask.Size = new System.Drawing.Size(242, 20);
            this.txtNewTask.TabIndex = 5;
            this.txtNewTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewTask_KeyPress);
            // 
            // btnRemoveTime
            // 
            this.btnRemoveTime.Location = new System.Drawing.Point(245, 225);
            this.btnRemoveTime.Name = "btnRemoveTime";
            this.btnRemoveTime.Size = new System.Drawing.Size(84, 23);
            this.btnRemoveTime.TabIndex = 4;
            this.btnRemoveTime.Text = "Remove Time";
            this.btnRemoveTime.UseVisualStyleBackColor = true;
            this.btnRemoveTime.Click += new System.EventHandler(this.btnRemoveTime_Click);
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(87, 224);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(75, 23);
            this.btnAddTime.TabIndex = 3;
            this.btnAddTime.Text = "Add Time";
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(6, 224);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTask.TabIndex = 2;
            this.btnRemoveTask.Text = "Remove";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(6, 253);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 1;
            this.btnAddTask.Text = "Add";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(6, 19);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTasks.Size = new System.Drawing.Size(323, 199);
            this.lstTasks.TabIndex = 0;
            this.lstTasks.DoubleClick += new System.EventHandler(this.lstTasks_DoubleClick);
            // 
            // btnClearCounters
            // 
            this.btnClearCounters.Location = new System.Drawing.Point(355, 31);
            this.btnClearCounters.Name = "btnClearCounters";
            this.btnClearCounters.Size = new System.Drawing.Size(91, 23);
            this.btnClearCounters.TabIndex = 1;
            this.btnClearCounters.Text = "Clear Counters";
            this.btnClearCounters.UseVisualStyleBackColor = true;
            this.btnClearCounters.Click += new System.EventHandler(this.btnClearCounters_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(355, 60);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(91, 23);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "About...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(355, 89);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(89, 23);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Report...";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 306);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnClearCounters);
            this.Controls.Add(this.grpTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "TimeBuddy Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grpTasks.ResumeLayout(false);
            this.grpTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdjust)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTasks;
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
    }
}

