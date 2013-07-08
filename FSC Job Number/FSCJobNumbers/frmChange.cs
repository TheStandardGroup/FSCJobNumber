using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FSCJobNumbers
{
    public partial class frmChange : Form
    {
        frmMain myparent = null;
        public frmChange()
        {
            InitializeComponent();
        }

        public frmChange(frmMain myp) {
            InitializeComponent();
            myparent = myp;
            lblCurrentName.Text = myparent.getDbName();
            this.BackColor = Color.FromArgb(28, 63, 119);
            this.ForeColor = Color.White;
            frmMain.setButtonColor(btnCancel);
            frmMain.setButtonColor(btnOkay);
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (tbNew.Text == "")
                System.Windows.Forms.MessageBox.Show("You must enter a new Database name", "Error");
            else {
                myparent.setDbName(tbNew.Text);
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
