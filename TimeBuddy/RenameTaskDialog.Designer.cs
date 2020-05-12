/*
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
            this.txtTaskName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaskName_KeyPress);
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