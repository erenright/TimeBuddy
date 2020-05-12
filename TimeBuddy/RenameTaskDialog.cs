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
    public partial class RenameTaskDialog : Form
    {
        private Task _task;

        /***************************************************************
         * RenameTaskDialog()
         * 
         *   This constructor is not used.
         */
        public RenameTaskDialog()
        {
            throw new NotImplementedException("Do not use this constructor");
        }

        /***************************************************************
         * RenameTaskDialog()
         * 
         *   Main constructor for the dialog.
         */
        public RenameTaskDialog(Task task)
        {
            InitializeComponent();

            _task = task;
            txtTaskName.Text = task.Name;
            nudMaxMinutes.Value = task.MaxSeconds / 60;
        }

        /*
         * Sanitize the data for upper layers
         */
        private void SanitizeData()
        {
            _task.Name = txtTaskName.Text.Trim();

            // Can't fail since we forbid decimals
            _task.MaxSeconds = Convert.ToInt32(nudMaxMinutes.Value) * 60;
        }

        /***************************************************************
         * btnOk_Click()
         * 
         *   |Click| handler for |btnOk|.  Updates the task's name and
         *   closes the dialog.
         */
        private void btnOk_Click(object sender, EventArgs e)
        {
            SanitizeData();

            Close();
        }

        /***************************************************************
         * btnCancel_Click()
         * 
         *   |Click| handler for |btnCancel|.  Closes the dialog without
         *   updating the task's name.
         */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
         * If ENTER was pressed, then the same as clicking "OK".
         */
        private void txtTaskName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SanitizeData();
                Close();
            }
        }
    }
}
