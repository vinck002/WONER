using Persistence.DataBase.RealEstateMoldels;
using Services.RealEstate.Owner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms.RealEstate
{
    public partial class FrmAuthorizationkey : Form
    {
        public List<UserModel> UserAuthorization;
        public FrmAuthorizationkey()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Owner ow = new Owner();
            UserAuthorization = ow.GetAuthorizationkey(txtValue.Text);
            if (UserAuthorization.Count == 0)
            {
                MessageBox.Show("Wrong password!");
                return;
                
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
              
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmAuthorizationkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
           
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }
    }
}
