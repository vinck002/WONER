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
    public partial class HistoryCommission :  Form
    {
        public HistoryCommission()
        {
            InitializeComponent();
        }
        DataView dvtransaction = new DataView();
        DataView dvcompany = new DataView();
        DataView savetransaction = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        public string PaymentApplication = "",SQLQuery1="0",CompanyName="";
        public int CompanyPercentID1 = 0;
        private void HistoryCommission_Load(object sender, EventArgs e)
        {
            dvcompany = SQLCMD.SQLdata("LS_CompanyPercent_L").DefaultView;
            Companylist.DataSource = dvcompany;
            Companylist.DisplayMember = "companyname";
            Companylist.ValueMember = "companyPercentID";
            

            /*-------------------------------------------------------------------------*/
            // dvtransaction = SQLCMD.SQLdata("Loadhistorycommission_L").DefaultView;
            //FillGrid();
        }
        private void FillGrid()
        {
            Sumpaymentmade.Text = "0.00";
            //Transactionlist.Rows.Clear();
            Transactionlist.DataSource = dvtransaction;
            if (dvtransaction.Count < 1) { return; }
            double amount = 0, sum1 = 0, totalsum;
            foreach (DataRowView record in dvtransaction)
            {   amount = double.Parse(record["Totalpaymentmade"].ToString());
                sum1 += amount;
                //Transactionlist.Rows.Add(record["reference"], record["CreationDate"], record["invoicenumber"], amount.ToString("#,##0.00"), record["CompanyReportHistoryID"], record["companyPercentID"], record["CompanyName"]);
            }
           // Transactionlist.Rows[0].IsCurrent = true;
            totalsum = sum1 ;
            Sumpaymentmade.Text = totalsum.ToString("#,##0.00");
        }

        private void HistoryCommission_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            if (CompanyPercentID1 == 0) { Companylist.Text = ""; }
            Companylist.Text = CompanyName;
            LoadCompanyInfo(0);
            CreationDate1.SetToNullValue();
            RealPaymentDate.SetToNullValue();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            LoadCompanyInfo(1);
        }
        private void LoadCompanyInfo(int Option)
        {
            dvtransaction = SQLCMD.SQLdata("LS_CompanyReportHistory_L 1, " + ((Companylist.Text.Trim() == "") ? "null" : ((Option == 1)? Companylist.SelectedValue.ToString() :CompanyPercentID1.ToString())) + "").DefaultView;
            FillGrid();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
        private void cleartextbox()
        {
            Reference.Text = ""; Invoicenumber.Text = ""; Amount.Text = ""; Reference.Focus();
        }

        private void bPayment_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Invoicenumber.Enabled = false;
        }

        private void bInvoice_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Invoicenumber.Enabled = true;
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if (Reference.Text.Trim() == "") { MessageBox.Show("Please Type Reference", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Reference.Focus(); return; }
            if (bInvoice.IsChecked == true  )
            {
              if (Invoicenumber.Text.Trim() == "") { MessageBox.Show("Please Type Invoice Number", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Invoicenumber.Focus(); return; }
            }
            if (Amount.Text.Trim() == "") { MessageBox.Show("Please Type Amount", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);Amount.Focus(); return; }
            if (double.Parse(Amount.Text) <=0) { MessageBox.Show("Amount Must Be Mayor Than Zero", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (CompanyPercentID1 == 0)
            {
                if (Companylist.Text.Trim() == "") { MessageBox.Show("Please Select A Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }
            if (RealPaymentDate.Text == "") { MessageBox.Show("Missing Real Payment Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); RealPaymentDate.Focus(); return; }
            if (CreationDate1.Text  == "") { MessageBox.Show("Please Type Application Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); CreationDate1.Focus(); return; }
            /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
            savetransaction = SQLCMD.SQLdata("LS_CompanyReportHistory_M 0,1,'" + Reference.Text.Trim() + "','" + Invoicenumber.Text.Trim() + "'," +
                double.Parse(Amount.Text.Trim()) +","+((CompanyPercentID1 == 0)?int.Parse(Companylist.SelectedValue.ToString()) : CompanyPercentID1 )+ "," +
                General.Globalvariables.guserid + ",'"+ CreationDate1.Text + "','"+ RealPaymentDate.Text + "'").DefaultView;
            string HistoryID1 = "";
            HistoryID1 = savetransaction.Table.Rows[0]["CompanyReportHistoryID"].ToString();
            /*-------------------------------------------------------------------------------------------------------------------------------*/
            if (SQLQuery1 != "0" /*&& bPayment.IsChecked == true*/)
            {
                savetransaction = SQLCMD.SQLdata("LS_CompanyCommisionReport_L2 null,null,'01-01-1990','"+ CreationDate1.Text + "',1,9999999999,"+
                  ((CompanyPercentID1 == 0) ? int.Parse(Companylist.SelectedValue.ToString()) : CompanyPercentID1) + ",'"+ SQLQuery1 + "',"+
                  HistoryID1 + ","+ General.Globalvariables.guserid + "").DefaultView;             
            /*-------------------------------------------------------------------------------------------------------------------------------*/

               // savetransaction = SQLCMD.SQLdata("LS_CompanyReportHistory_M 2,"+ HistoryID1 + ",'','',0,0,0,'"+CreationDate1.Text +"'").DefaultView;
                SQLQuery1 = "0";
                 Searching(1);/*Refrescar en el form comision report*/
                
            }
            /*------------------------------------------------------------------------------------------------------------------------------*/
            bSearch.PerformClick();
            cleartextbox();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*--------------------------------------------------------------------------------------------------------------------------------------------------------*/
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            if (Transactionlist.RowCount < 1) { MessageBox.Show("No Transactions In The List","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            if (Companylist.Text.Trim() == "") { MessageBox.Show("Please Select A Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Confirm Undo", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.No) {  return; }
            string ID = "", idcompany = "";
            Authorization aauto = new Authorization();
            if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ID = Transactionlist.CurrentRow.Cells["id"].Value.ToString();
                idcompany = Transactionlist.CurrentRow.Cells["companyid"].Value.ToString();
                savetransaction = SQLCMD.SQLdata("LS_CompanyReportHistory_M 1," + ID + ",'','',0," + Companylist.SelectedValue.ToString() + "," + General.Globalvariables.guserid + ",'','01-01-3000'").DefaultView;
                bSearch.PerformClick();
                
                
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //Companylist.Text = "xexexe";
            //Companylist.SelectedValue  = 3;
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            // Companylist.Text = "xexexe";
            //Companylist.SelectedValue = 3;
            //Companylist.SelectedValue = 2;
            //Companylist.SelectedValue = 3;
            //Companylist.SelectedValue = 3;
        }

        /*----------------------------Delegado para ejecutar evento en form comision report----------------------------*/
        public delegate void Search1(int R1);
        public event Search1 Searching;
        /*---------------------------------------------------------------------------------------------------------------*/
    }
}
