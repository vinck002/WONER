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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView changepass = new DataView();
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if (password.Text.Trim()=="") { MessageBox.Show("Please Type The Password","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); password.Focus(); return; }
            if (Confirmpassword.Text.Trim() == "") { MessageBox.Show("Please Confirm The Password", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Confirmpassword.Focus(); return; }
            if (password.Text.Trim() != Confirmpassword.Text.Trim()) { MessageBox.Show("Password Does Not Match", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*-----------------------------------------------------------------------------------------------*/
            try
            {
                changepass = SQLCMD.SQLdata("LS_CHANGEPASSWORD_L " + General.Globalvariables.guserid + "," + password.Text.Trim() + "").DefaultView;
                General.Globalvariables.UserPassword = password.Text;
                password.Text = "";
                Confirmpassword.Text = ""; password.Focus();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception) { MessageBox.Show("Could Not Change Password","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            /*-----------------------------------------------------------------------------------------------*/
        }

        private void ChangePassword_Activated(object sender, EventArgs e)
        {
            password.Focus();
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
    }
}
