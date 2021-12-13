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
    public partial class PaymentSynchronize : Form
    {
        public PaymentSynchronize()
        {
            InitializeComponent();
        }
        DataView DVPayments = new DataView();
        DataView DVPayments2 = new DataView();
        DataView DVPaysource = new DataView();
        DataView DVTransfer = new DataView();
        DataView DVTranferenceLog = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void PaymentSynchronize_Load(object sender, EventArgs e)
        {
            CreationDate1.Text  = DateTime.Now.ToShortDateString();
            CreationDate2.Text = DateTime.Now.ToShortDateString();
        }
        private void FillPaymentSource()
        {
            String PaymentSourceID = "0"; int PayID = 0;
            DataTable dt = new DataTable();
            dt = DVPayments.Table;
            DVPayments2 = new DataView(dt);
            if(DVPayments2.Count < 1) { goto FINAL; }
            foreach (DataRowView DV in DVPayments2)
            {
                if(PayID != Convert.ToInt32(DV["PaymentSourceID"].ToString()))
                {
                    PaymentSourceID = PaymentSourceID + "," + DV["PaymentSourceID"];
                }
            }
            FINAL:;
            DVPaysource = SQLCMD.SQLdata("LS_PaymentSource_L '"+PaymentSourceID+"'").DefaultView;
            PaymentSourceList.DataSource = DVPaysource;
        }
        private void Btnsearch_Click(object sender, EventArgs e)
        {
            if (CreationDate1.Text == "") { MessageBox.Show("Missing Date Range1", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (CreationDate2.Text == "") { MessageBox.Show("Missing Date Range2", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (DateTime.Parse(CreationDate1.Text) > DateTime.Parse(CreationDate2.Text)) { MessageBox.Show("Invalid Date Range", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait wwt = new Wait();
            backgroundWorker1.RunWorkerAsync();
            wwt.ShowDialog();

        }
        private void FillGrid()
        {
            //  transactionslist.Rows.Clear();
            transactionslist.DataSource = DVPayments;
            Found.Text = DVPayments.Count.ToString();
            FillPaymentSource();



        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if(transactionslist.Rows.Count < 1) { MessageBox.Show("No Transactions In The List","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning);return; }
                string TransferenceID = "",TransactionID="0";
                TransferenceID = DateTime.Now.ToString("yyyy") + "" + DateTime.Now.ToString("MM") + "" + DateTime.Now.ToString("dd") + "" + DateTime.Now.ToString("HH") + "" + DateTime.Now.ToString("mm") +""+ DateTime.Now.ToString("ss");
                /*----------------------------------------------------------------------------------------------------------------------------------------*/
                for (int record = 0; record <= transactionslist.RowCount - 1; record++)
                {
                    if (transactionslist.Rows[record].Cells["Select"].Value.ToString() == "1")
                    {
                        TransactionID = TransactionID + "," + transactionslist.Rows[record].Cells["TransactionID"].Value.ToString();
                    }
                    
                }
                if (TransactionID =="0") { MessageBox.Show("No Transactions Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                /*-----------------------------------------------------------------------------------------------------------------------------------------*/
                if (MessageBox.Show("Confirm Transference", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVTranferenceLog = SQLCMD.SQLdata("Exec LS_GenerationPayments_M " + TransferenceID + "," + General.Globalvariables.guserid + "").DefaultView;
                DVTransfer = SQLCMD.SQLdata("Exec LS_PaymentsSynchronize_M '"+ TransactionID +"','"+ TransferenceID +"'").DefaultView;
                /*------------------Limpiar Grid------------------------*/
                DVPayments.RowFilter = "transactionID =0";
                transactionslist.DataSource = DVPayments;
                Found.Text = DVPayments.Count.ToString();
                /*---------------------------------------------------*/
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void PaymentSynchronize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {

                DVPayments = SQLCMD.SQLdata("Exec LS_PaymentsSynchronize_L '" + CreationDate1.Text + "','" + CreationDate2.Text + "'").DefaultView;

              }
            catch (Exception ecx)
            { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGrid();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void PaymentSourceList_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
        }

        private void PaymentSourceList_Leave(object sender, EventArgs e)
        {
            
        }

        private void PaymentSourceList_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (PaymentSourceList.RowCount < 1) { return; }
            if (transactionslist.RowCount < 1) { return; }
            int Selected = 0, paysourceid = 0;
            if (e.ColumnIndex == 0)
            {
                Selected = int.Parse(PaymentSourceList.CurrentRow.Cells["Select"].Value.ToString());
                paysourceid = int.Parse(PaymentSourceList.CurrentRow.Cells["PaymentSourceID"].Value.ToString());
                for (int record = 0; record <= transactionslist.RowCount - 1; record++)
            {
                if (paysourceid == int.Parse(transactionslist.Rows[record].Cells["PaymentSourceID"].Value.ToString()))
                {
                    transactionslist.Rows[record].Cells["Select"].Value = Selected;
                }
            } 
            }
        }
        /*============================================================================================================================================================================*/
    }
}
