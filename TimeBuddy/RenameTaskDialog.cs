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
