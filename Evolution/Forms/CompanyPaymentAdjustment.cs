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
    public partial class CompanyPaymentAdjustment : Form
    {
        public CompanyPaymentAdjustment()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVPayment = new DataView();
        private void CompanyPaymentAdjustment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void CompanyPaymentAdjustment_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
        }

        private void CompanyPaymentAdjustment_Load(object sender, EventArgs e)
        {
            DVPayment = SQLCMD.SQLdata("LS_CompanyPaymentAdjust_L").DefaultView;
            PaymentAdjustList.DataSource = DVPayment;
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DVPayment.RowFilter = "Agreementnumber like '%"+Searching.Text.Trim()+"%'";
                PaymentAdjustList.DataSource = DVPayment;
            }
            catch(Exception ) { MessageBox.Show("Invalid Character"); }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
    }
}
