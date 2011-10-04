namespace TimeBuddy
{
    partial class RenameTaskDialog
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
            this.lblRenameTask = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMaxMinutes = new System.Windows.Forms.Label();
            this.nudMaxMinutes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRenameTask
            // 
            this.lblRenameTask.AutoSize = true;
            this.lblRenameTask.Location = new System.Drawing.Point(12, 15);
            this.lblRenameTask.Name = "lblRenameTask";
            this.lblRenameTask.Size = new System.Drawing.Size(63, 13);
            this.lblRenameTask.TabIndex = 0;
            this.lblRenameTask.Text = "Task name:";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(81, 12);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(185, 20);
            this.txtTaskName.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 64);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMaxMinutes
            // 
            this.lblMaxMinutes.AutoSize = true;
            this.lblMaxMinutes.Location = new System.Drawing.Point(12, 41);
            this.lblMaxMinutes.Name = "lblMaxMinutes";
            this.lblMaxMinutes.Size = new System.Drawing.Size(70, 13);
            this.lblMaxMinutes.TabIndex = 4;
            this.lblMaxMinutes.Text = "Max Minutes:";
            // 
            // nudMaxMinutes
            // 
            this.nudMaxMinutes.Location = new System.Drawing.Point(81, 39);
            this.nudMaxMinutes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMaxMinutes.Name = "nudMaxMinutes";
            this.nudMaxMinutes.Size = new System.Drawing.Size(58, 20);
            this.nudMaxMinutes.TabIndex = 5;
            // 
            // RenameTaskDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 96);
            this.Controls.Add(this.nudMaxMinutes);
            this.Controls.Add(this.lblMaxMinutes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.lblRenameTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenameTaskDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Task Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRenameTask;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMaxMinutes;
        private System.Windows.Forms.NumericUpDown nudMaxMinutes;
    }
}