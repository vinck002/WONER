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
    public partial class CompanyPaymentAdjust : Form
    {
        public CompanyPaymentAdjust()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVPayment = new DataView();
        DataView DVSave = new DataView();
        DataView DVTransaction = new DataView();
        public string AgreementID = "0",CompanyPercentID="0";
        //string CompanyPaymentAdjustID = "0";
        string transactionID = "0";


        private void CompanyPaymentAdjust_Load(object sender, EventArgs e)
        {
            FillGrid();
            /*-------------------------------------------*/
            DVTransaction = SQLCMD.SQLdata("LS_TransactionType_L1").DefaultView;
            TransactionTypeList.DataSource = DVTransaction;
            TransactionTypeList.DisplayMember = "Name";
            TransactionTypeList.ValueMember = "ID";
            /*--------------------------------*/
            TransactionTypeList.Text = "";
            ApplicationDate.SetToNullValue();
            /*---------------------------------------------*/
        }
        private void FillGrid()
        {
            DVPayment = SQLCMD.SQLdata("LS_CompanyPaymentAdjust_L_v1 "+AgreementID+","+ CompanyPercentID + "").DefaultView;
            PaymentAdjustList.DataSource = DVPayment;

        }

        private void CompanyPaymentAdjust_Activated(object sender, EventArgs e)
        {
            
        }

        private void Btnnew_Click(object sender, EventArgs e)
        {
            TransactionTypeList.Text = "";
            Amount.Text = "";
            DownpaymentPercent.Text = "";
            MrPaymentPercent.Text = "";
            DownpaymentPercent.Enabled = true;
            MrPaymentPercent.Enabled = true;
            ApplicationDate.SetToNullValue();
            //CompanyPaymentAdjustID = "0";
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            

                decimal DP = 0, MR = 0;
           // string CreationDate = "";
            DP = ((DownpaymentPercent.Text =="")? 0 : decimal.Parse(DownpaymentPercent.Text));
            MR = ((MrPaymentPercent.Text == "") ? 0 : decimal.Parse(MrPaymentPercent.Text));
          //  if (Amount.Text == "" || decimal.Parse(Amount.Text)<=0) { MessageBox.Show("Missing Amount", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Amount.Focus(); return; }
            //if (DP <0 ) { MessageBox.Show("Invalid Downpayment ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); DownpaymentPercent.Focus(); return; }
            //if (MR ) { MessageBox.Show("Invalid MRPayment %", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); MrPaymentPercent.Focus(); return; }
            //if (DP+MR <=0) { MessageBox.Show("Missing Value For Downpayment Or MRPayment  ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); DownpaymentPercent.Focus(); return; }
            if (ApplicationDate.Text == "") { MessageBox.Show("Missing Application Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ApplicationDate.Focus(); return; }
           // CreationDate = ApplicationDate.Text;
            if (TransactionTypeList.Text == "") { MessageBox.Show("Missing Transaction Type","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); TransactionTypeList.Focus(); return; }
            Authorization autoriza = new Authorization();
            if (autoriza.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                MessageBox.Show("Access Denied \n Operation Could Not Completed", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
              
                /*---------------------------------------------------------------------------------------------------*/
             
                DVSave = SQLCMD.SQLdata("LS_CompanyPaymentAdjust_M_V1 " + ((transactionID == "0") ? "0" : "1") + "," + ((DP <= 0) ? "0" : transactionID) + "," + AgreementID + "," +
                    CompanyPercentID + "," + DP + "," + TransactionTypeList.SelectedValue + "," + ((PAYMENTTYPE.SelectedIndex == 0) ? "1" : "2") + "," + General.Globalvariables.guserid + ",'" + ApplicationDate.Text + "'").DefaultView;
                /*---------------------------------------------------------------------------------------------------*/
                //DVSave = SQLCMD.SQLdata("LS_CompanyPaymentAdjust_M_V1 " + ((CompanyPaymentAdjustID == "0") ? "0" : "1") + "," + ((MR <= 0) ? "0" : CompanyPaymentAdjustID) + "," + AgreementID + "," +
                //    CompanyPercentID + "," + MR + "," + TransactionTypeList.SelectedValue + ",2," + General.Globalvariables.guserid + ",'" + ApplicationDate.Text + "'").DefaultView;
                /*---------------------------------------------------------------------------------------------------*/
                FillGrid();
                Btnnew.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            Authorization autoriza = new Authorization();
            if (autoriza.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                MessageBox.Show("Access Denied \n Operation Could Not Completed", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (PaymentAdjustList.RowCount < 1) { return; }
                transactionID = ((transactionID == "0") ? PaymentAdjustList.CurrentRow.Cells["transactionID"].Value.ToString() : transactionID);
                //CompanyPaymentAdjustID = ((CompanyPaymentAdjustID == "0") ? PaymentAdjustList.CurrentRow.Cells["CompanyPaymentAdjustID"].Value.ToString() : CompanyPaymentAdjustID);
                if (MessageBox.Show("Confirm Delete", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVSave = SQLCMD.SQLdata("LS_CompanyPaymentAdjust_M_V1 2," + transactionID + "," + AgreementID + ",0,0,0,0," + General.Globalvariables.guserid + ",'01-01-1990'").DefaultView;
                FillGrid();
                Btnnew.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void PaymentAdjustList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (PaymentAdjustList.RowCount < 1) { return; }
            decimal PaymentAmount;
            PaymentAmount = decimal.Parse(PaymentAdjustList.CurrentRow.Cells["amount"].Value.ToString());
            TransactionTypeList.SelectedValue = int.Parse(PaymentAdjustList.CurrentRow.Cells["Transactiontypeid"].Value.ToString());
            DownpaymentPercent.Text = ((PaymentAdjustList.CurrentRow.Cells["Type"].Value.ToString() =="2" )? "" : PaymentAmount.ToString("#,##0.00"));
            MrPaymentPercent.Text = ((PaymentAdjustList.CurrentRow.Cells["Type"].Value.ToString() == "1") ? "" : PaymentAmount.ToString("#,##0.00"));
            DownpaymentPercent.Enabled = ((PaymentAdjustList.CurrentRow.Cells["Type"].Value.ToString() == "2") ? false : true);
            MrPaymentPercent.Enabled = ((PaymentAdjustList.CurrentRow.Cells["Type"].Value.ToString() == "1") ? false : true);
            ApplicationDate.Value = DateTime.Parse( DateTime.Now.ToShortDateString());
            ApplicationDate.Text = PaymentAdjustList.CurrentRow.Cells["CreationDate"].Value.ToString();
            transactionID = PaymentAdjustList.CurrentRow.Cells["CompanyPaymentAdjustID"].Value.ToString();

        }

        private void CompanyPaymentAdjust_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }
  /*------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
