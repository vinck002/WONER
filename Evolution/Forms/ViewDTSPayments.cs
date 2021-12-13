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
    public partial class ViewDTSPayments : Form
    {
        public ViewDTSPayments()
        {
            InitializeComponent();
        }
        DataView paymentview = new DataView();
        General.Sqlcommandexecuter SqlCMD = new General.Sqlcommandexecuter();
        public string agreementid, datecreate,agreementnumber;
        public double totalmembership = 0;
        private void bExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ViewDTSPayments_Load(object sender, EventArgs e)
        {
            Membership.Text = totalmembership.ToString("#,##0.00");
            Contractnumber.Text = agreementnumber;
            paymentview = SqlCMD.SQLdata("LS_VIEWDTSPAYMENT_L "+ agreementid + ",'"+ datecreate + "'").DefaultView;
            FillGrid();

        }
        private void FillGrid()
        {
            
            Paidtotal.Text = "0.00";
            Balancedue.Text = totalmembership.ToString("#,##0.00");
            double totalpayment = 0,  balance = 0,paid;
            Paymentlist.DataSource = paymentview;
            if (paymentview.Count < 1) { return; }
            for (int rw =0; rw <= Paymentlist.RowCount - 1; rw++)
            {
                totalpayment = totalpayment + double.Parse(Paymentlist.Rows[rw].Cells["Amount"].Value.ToString());
            }
            paid = totalpayment * -1;
            Paidtotal.Text = paid.ToString("#,##0.00");
            balance = totalmembership - ((totalpayment <0)? totalpayment*-1 : totalpayment);
            Balancedue.Text = balance.ToString("#,##0.00");
        }
        /*--------------------------------------------------------------------------------*/
    }
}
