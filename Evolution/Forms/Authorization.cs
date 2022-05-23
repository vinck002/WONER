using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void bOk_Click(object sender, EventArgs e)
        {
            if (Userpassword.Text.Trim() == "") { MessageBox.Show("Please Type Your Password", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Userpassword.Focus(); return; }
            if (General.Globalvariables.UserPassword.ToUpper() == Userpassword.Text.Trim().ToUpper())
            {
                DialogResult = DialogResult.OK;
            }
            else { MessageBox.Show("Invalid Password","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); Userpassword.Focus(); }
        }

        private void Authorization_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { DialogResult = DialogResult.Cancel; }
        }

        private void Userpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) { bOk.PerformClick(); }
        }
    }
}
