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
        }

        /***************************************************************
         * btnOk_Click()
         * 
         *   |Click| handler for |btnOk|.  Updates the task's name and
         *   closes the dialog.
         */
        private void btnOk_Click(object sender, EventArgs e)
        {
            _task.Name = txtTaskName.Text.Trim();
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
    }
}
