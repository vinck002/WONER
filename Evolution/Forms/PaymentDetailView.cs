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
    public partial class ViewPaymentDetail : Form
    {
        public ViewPaymentDetail()
        {
            InitializeComponent();
        }
        DataView DVPayment = new DataView();
        DataView DVHold = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        public string AgreementID, CreationDate1, CreationDate2, CompanyPercentId;
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewPaymentDetail_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void bInactive_Click(object sender, EventArgs e)
        {
            if (transactionslist.RowCount < 1) { MessageBox.Show("No Payments In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (transactionslist.CurrentRow.Cells["Type"].Value.ToString() =="0") { MessageBox.Show("Cannot Inactive This Transaction", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string Reference = transactionslist.CurrentRow.Cells["TransactionType"].Value.ToString() + "\n" + transactionslist.CurrentRow.Cells["Amount"].Value.ToString();
            Wait wwt = new Wait();
            try
            {
                if (MessageBox.Show("Confirm Inactive \n"+Reference, "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                wwt.Show(); wwt.Refresh();
                DVHold = SQLCMD.SQLdata("LS_InactivePayments_M 1," + transactionslist.CurrentRow.Cells["TransactionID"].Value.ToString() + "," + General.Globalvariables.guserid + "").DefaultView;
                FillGrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void bHold_Click(object sender, EventArgs e)
        {
            if(transactionslist.RowCount < 1) { MessageBox.Show("No Payments In The List","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                string SqlQuery = "";
                /*----------------------------------------------------------------------------------------------------------------------------------------*/
                for (int record = 0; record <= transactionslist.RowCount - 1; record++)
                {
                    if (transactionslist.Rows[record].Cells["Hold"].Value.ToString() != transactionslist.Rows[record].Cells["Hold2"].Value.ToString())
                    {
                        SqlQuery = SqlQuery + " " + "Exec LS_SetPaymentHoldToThird_M "+ transactionslist.Rows[record].Cells["TransactionID"].Value.ToString()+","+
                          transactionslist.Rows[record].Cells["Hold"].Value.ToString() + ","+CompanyPercentId+","+ 
                          transactionslist.Rows[record].Cells["AgreementID"].Value.ToString() + ","+ General.Globalvariables.guserid +"";
                    }
                }
                /*-----------------------------------------------------------------------------------------------------------------------------------------*/
                if (SqlQuery == "") { MessageBox.Show("No Payment Changed", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Set Hold", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVHold = SQLCMD.SQLdata(SqlQuery).DefaultView;
                FillGrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void FillGrid()
        {
            DVPayment = SQLCMD.SQLdata("LS_PaymentDetailView_L " + AgreementID + ",'" + CreationDate1 + "','" + CreationDate2 + "',"+CompanyPercentId+"").DefaultView;
            transactionslist.DataSource = DVPayment;
        }

        private void ViewPaymentDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }
        /*==========================================================================================================================================*/
    }
}
