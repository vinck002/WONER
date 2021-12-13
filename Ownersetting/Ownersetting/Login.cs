using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ownersetting
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            AcceptButton = bAcept;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAcept_Click(object sender, EventArgs e)
        {
            if(Password.Text.Trim()=="ownermanagersetting")
            { Encryptions cifrado = new Encryptions();
                cifrado.Show();
                this.Hide();
            }
            else
            { MessageBox.Show("Invalid Password...",Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }
    }
}
