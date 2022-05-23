using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using Evolution.General;

namespace Evolution
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        General.Conexion con = new General.Conexion();
        General.Globalvariables gbv = new General.Globalvariables();
        SqlDataReader dr;
        private void Btnquit_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            if (MessageBox.Show("Quit", "EVOLUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;//Application.Exit();
            }
            

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
        private bool validacampo()
        {
            if (user.Text.Trim() == "") { MessageBox.Show("Please type the User", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); user.Focus(); return false; }
            if (password.Text.Trim() == "") { MessageBox.Show("Please type the Password", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); password.Focus(); return false; }
            user.Text = user.Text.Replace("'", "");
            password.Text = password.Text.Replace("'", "");
            return true;
        }
        private void Btnlogin_Click(object sender, EventArgs e)
        {
            if (validacampo() == false) { return; }
            try
            {   
                SqlCommand cmd = new SqlCommand("USER_LX '" + user.Text.Trim() + "','" + password.Text.Trim() + "'", con.SQL());
                con.SQL().Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    General.Globalvariables.guserid = Convert.ToInt32(dr["userid"]);
                    General.Globalvariables.Systemdate = Convert.ToDateTime (dr["systemdate"]);
                    General.Globalvariables.Userfullname = dr["firstname"].ToString().Trim() + " " + dr["lastname"].ToString().Trim();
                    General.Globalvariables.Username = dr["code"].ToString().Trim();
                    General.Globalvariables.UserprofileID = Convert.ToInt32(dr["userprofileid"]);
                    General.Globalvariables.Departament = dr["deparment"].ToString().Trim();
                    General.Globalvariables.Salesfloorid = Convert.ToInt32(dr["salesfloorid"]);
                    General.Globalvariables.AppName = dr["AppName"].ToString().Trim();
                    General.Globalvariables.UserPassword = password.Text.Trim();

                    this.DialogResult = DialogResult.OK;

                }
                else {  MessageBox.Show("Invalid Access...", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                dr.Close();
               
            }
            catch (Exception  )
            {
                MessageBox.Show("\n Invalid Access \n Could Not Connect To Server", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            { con.SQL().Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) { Btnlogin.PerformClick(); }
           
        }

        private void Login_Activated(object sender, EventArgs e)
        {
 
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape) { Application.Exit(); }
            //
            Conexion con = new Conexion();
            
            if (Program.SwichDemo == true)
            {
                if (e.KeyData == Keys.F1)
                {
                    user.Text = Properties.Settings.Default.UserID;
                    password.Text = Properties.Settings.Default.Password;
                    Btnlogin.PerformClick();
                }
            }
        }
        /*==========================================================================================================================================================*/
       

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        /*==========================================================================================================================================================*/
    }
}
