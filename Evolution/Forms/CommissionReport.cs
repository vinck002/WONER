using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.Drawing;
namespace Evolution.Forms
{
    public partial class CommissionReport : Form
    {
        public CommissionReport()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView Savetransactions = new DataView();
        DataView DVToBePaid = new DataView();
        DataView Loadtransactions = new DataView();
        DataView dvcompany = new DataView();
        DataView dvcompany1 = new DataView();
        DataView sumappliedpayment = new DataView();
        DataView DVUnauthorize = new DataView();
        DataView DVPayments = new DataView();
        bool OpenForm = false;
        int ProcesStatus1 = 0;
        bool SearchAutomatic = false;
        private void TransactionsList_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        { 
        
        }
      
       
        private void CommissionReport_Load(object sender, EventArgs e)
        {
            
            dvcompany = SQLCMD.SQLdata("Ls_CompanyPercent_L").DefaultView;
            Companylist.DataSource = dvcompany;
            Companylist.DisplayMember = "CompanyName";
            Companylist.ValueMember = "CompanyPercentID";
        }
       private void FillGrid(int action)
        {   /*--------------------------------------------------------------------------*/
            if (action <= 1)
            {
                Found.Text = Loadtransactions.Count.ToString();
                TransactionsList.DataSource = Loadtransactions;
            }
            if (TransactionsList.RowCount < 1) { return; }
            if (action == 2) { Found.Text = TransactionsList.RowCount.ToString(); }
            /*-----------------------------------------------------------------------*/

            for (int R1 = 0; R1 <= TransactionsList.RowCount - 1; R1++)
                {
                    TransactionsList.Rows[R1].Cells["paymentmade"].Style.ForeColor = Color.Red;
                    TransactionsList.Rows[R1].Cells["ToPay"].Style.ForeColor = Color.Green;
                    TransactionsList.Rows[R1].Cells["MemberName"].Style.ForeColor = ((TransactionsList.Rows[R1].Cells["EvoStatusID"].Value.ToString() == "0") ? Color.Red : Color.Black);
                    TransactionsList.Rows[R1].Cells["ContractNo"].Style.ForeColor = ((TransactionsList.Rows[R1].Cells["EvoStatusID"].Value.ToString() == "0") ? Color.Red : Color.Black);
                    TransactionsList.Rows[R1].Cells["Type"].Style.ForeColor = ((TransactionsList.Rows[R1].Cells["UpDown_Grade"].Value.ToString() == "") ? Color.Black : Color.Blue);
                    TransactionsList.Rows[R1].Cells["ContractDate"].Style.ForeColor = ((TransactionsList.Rows[R1].Cells["UpDown_Grade"].Value.ToString() == "") ? Color.Black : Color.Blue);
                }
            if (action == 0)
            {
                TotalPaymentToMake();
            }
            /*--------------------------------------------------------------------------*/

        }
        private void TotalPaymentToMake()
        {
            double TotalToMake = 0;

            if (TransactionsList.RowCount < 1) { return; }
            for (int record = 0; record <= TransactionsList.RowCount - 1; record++)
            {TotalToMake += double.Parse(TransactionsList.Rows[record].Cells["Amount"].Value.ToString());
            }
             Paymentmade.Text = TotalToMake.ToString("#,##0.00");
        }

        private void TransactionsList_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bProccess_Click(object sender, EventArgs e)
        {
            /*----------------------------------------------------------------------------------------*/
            
            if (TransactionsList.RowCount < 1) { MessageBox.Show("No Contract In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Companylist.Text.Trim() == "") { MessageBox.Show("Select A Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Companylist.Focus(); return; }
            /*-----------------------------------------------------------------------------------------*/
                String HistoryID = "0", Query = "",AgreementIDX2="0";
                /*---------------------------------------------------------------*/
                for (int Record = 0; Record <= TransactionsList.RowCount - 1; Record++)
                {
                  if (int.Parse(TransactionsList.Rows[Record].Cells["ProcessStatus"].Value.ToString()) != 0) { ProcesStatus1 = ProcesStatus1 + 1; }
                  if (double.Parse(TransactionsList.Rows[Record].Cells["ToPay"].Value.ToString()) != 0 & int.Parse(TransactionsList.Rows[Record].Cells["ProcessStatus"].Value.ToString()) == 0)
                   {
                    AgreementIDX2 = AgreementIDX2 + "," + TransactionsList.Rows[Record].Cells["agreementID"].Value.ToString();
                  Query = Query + " " + "Exec LS_CompanyCommissionReport_M 0,0," + HistoryID + "," + TransactionsList.Rows[Record].Cells["agreementID"].Value.ToString() + ",'" +
                         TransactionsList.Rows[Record].Cells["ContractNo"].Value.ToString() + "'," + TransactionsList.Rows[Record].Cells["PaymentApplied1"].Value.ToString() + "," +
                         TransactionsList.Rows[Record].Cells["MrToApply"].Value.ToString() + "," + TransactionsList.Rows[Record].Cells["InterestToApply"].Value.ToString() + "," +
                         TransactionsList.Rows[Record].Cells["ToPay"].Value.ToString() + ","+ TransactionsList.Rows[Record].Cells["Price"].Value.ToString() + "," + General.Globalvariables.guserid + ",'" + Weekreference.Text + "'," +
                         Companylist.SelectedValue + ",'"+DateTime.Parse( TransactionsList.Rows[Record].Cells["ContractDate"].Value.ToString()) + "','"+Contractdate2.Text  +"'";
                    }
                }
            /*--------------------------------------------------------------------*/
            if(ProcesStatus1 != 0) { MessageBox.Show("Some Payments will not Be Processed because have been Already processed with date greater than searching date", "OWNER",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); }
            ProcesStatus1 = 0;
            
            HistoryCommission hhc = new HistoryCommission();
            hhc.PaymentApplication = "yes";
            hhc.CompanyPercentID1 = int.Parse(Companylist.SelectedValue.ToString());
            hhc.SQLQuery1 = AgreementIDX2;
            hhc.CompanyName = Companylist.Text;
            hhc.Searching += new HistoryCommission.Search1(Buscar);
            hhc.MdiParent = MdiParent;
            hhc.Show();
            /*-----------------------------------------------------------------------------------------*/
        }

        private void TransactionsList_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }
        

        private void bPrint_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (TransactionsList.RowCount < 1) { MessageBox.Show("No Contracts In the List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                General.ExportCommissionToExcel exportar = new General.ExportCommissionToExcel();
                exportar.ExportarGridview(TransactionsList, Companylist.Text, Double.Parse(Appliedpayment.Text), DVPayments);
            }catch(Exception ecx) { MessageBox.Show(ecx.Message,"OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }


        }

        private void TransactionsList_CellClick(object sender, GridViewCellEventArgs e)
        {
          if(TransactionsList.RowCount < 1) { return; }
            AgreementIDView.Text = TransactionsList.CurrentRow.Cells["AgreementID"].Value.ToString();
        }
        public void Buscar(int R1)
        {
            bSearch.PerformClick();
        }
        private  void bSearch_Click(object sender, EventArgs e)
        {
            /*------------------Validar------------------------*/
            if(SearchAutomatic == false) { return; }
            Paymentmade.Text = "0.00"; Appliedpayment.Text = "0.00"; Totaltobepaid.Text = "0.00";
            if (Companylist.Text.Trim() == "" || Companylist.SelectedValue == null) { MessageBox.Show("Please Select A Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Companylist.Focus(); return; }
 
            /*------------------------------------------------------------------------------------------------*/
            backgroundWorker1.RunWorkerAsync();
            Wait wwt = new Wait();
            wwt.ShowDialog();
            /*-------------------------------------------------------------------------------------------*/
        }

        private void CommissionReport_Activated(object sender, EventArgs e)
        {
            if (OpenForm == false)
            {
                Companylist.Text = "";
                Contractdate1.SetToNullValue();
                Contractdate2.Text = DateTime.Now.ToShortDateString();
                SalesfloorID.Focus();
                OpenForm = true;
                SearchAutomatic = true;
            }
        }

        private void CommissionReport_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void bAdd_Click(object sender, EventArgs e)
        { 
        }

        private void bReverse_Click(object sender, EventArgs e)
        {
            
        }
        
        private void TransactionsList_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {
            
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = "";
            Contract2.Text = "";
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            Companylist.Text = "";
            Percent1.Text = "0%";
            Percent.Text = "0%";
            SalesfloorID.Focus();
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if(SalesfloorID.TextLength >= 2) { PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2) { Contract1.SelectionStart = 0; Contract1.SelectionLength = Contract1.Text.Length; Contract1.Focus(); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }

        private void bThird_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (TransactionsList.RowCount < 1) { MessageBox.Show("No Contracts In the List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                General.ExportCommissionToExcel exportar = new General.ExportCommissionToExcel();
                exportar.ExportarGridviewToThird(TransactionsList, Companylist.Text, Double.Parse(Appliedpayment.Text),DVPayments,Contractdate2.Text, decimal.Parse(Paymentmade.Text));
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); ExcludePaid.CheckState = CheckState.Unchecked; ExcludeCanceled.CheckState = CheckState.Unchecked; Loadtransactions.RowFilter = ""; FillGrid(1);  }
        }
        private void TransactionsList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            viewPaymentToolStripMenuItem.PerformClick();
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            /*-------------------------------------------------------------------------------------*/
            string Pathfile = "";
            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Excel Files (*.xlsx)|*.xls";
            openfile1.Title = "Select An Excel File";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile1.FileName.Equals("") == false) { Pathfile = openfile1.FileName; }
            }
            else { return; }
            TransactionsList.Rows.Clear();
            /*-------------------------Read Excel File-----------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            aplicacion.Workbooks.Open(openfile1.FileName);
            libros_trabajo = aplicacion.Workbooks.Open(openfile1.FileName);
            hoja_trabajo = libros_trabajo.Worksheets.get_Item(1);
            int fila = hoja_trabajo.Rows.Count;
            for (int record = 8; record <= fila; record++)
            {
                Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A"+record+""];
                Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["B" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["C" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["D" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango5 = aplicacion.Range["E" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango6 = aplicacion.Range["F" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango7 = aplicacion.Range["G" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango8 = aplicacion.Range["H" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango9 = aplicacion.Range["I" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango10 = aplicacion.Range["J" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango11 = aplicacion.Range["K" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango12 = aplicacion.Range["L" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango13 = aplicacion.Range["M" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango14 = aplicacion.Range["O" + record + ""];
                Microsoft.Office.Interop.Excel.Range rango15 = aplicacion.Range["R" + record + ""];
                if ( rango1.Value == null) { break; }
                TransactionsList.Rows.Add(rango1.Value, rango2.Value, rango3.Value,
                 rango4.Value, rango5.Value, rango6.Value,
                rango7.Value, rango8.Value, rango9.Value,
                 rango10.Value, ((rango11.Value ==null)? "0" : rango11.Value), rango11.Value, rango12.Value,
                 rango13.Value, rango14.Value, rango15.Value,0,"","", ((rango7.Value ==null)?"0" : rango7.Value), 
                 ((rango9.Value==null)?"0" : rango9.Value), ((rango14.Value== null)? "0" : rango14.Value));
               // if(record == 22) { break; }
            }
            aplicacion.DisplayAlerts = false;
            libros_trabajo.Close();
            aplicacion.Quit();
            TotalPaymentToMake();
            double TotalPaid = 0, TotalTobePaid1=0;
            TotalPaid = 0;
            Appliedpayment.Text = TotalPaid.ToString("#,##0.00");
            TotalTobePaid1 = double.Parse(Paymentmade.Text) - TotalPaid;
            Totaltobepaid.Text = TotalTobePaid1.ToString("#,##0.00");
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*--------------------------------------------------------------------------------------*/
        }

        private void viewPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TransactionsList.RowCount < 1) { return; }
            if(Companylist.Text == "") { MessageBox.Show("Missing Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Companylist.Focus(); return; }
            ViewPaymentDetail VPay = new ViewPaymentDetail();
            VPay.Controls["radGroupBox2"].Controls["AgreementNumber"].Text = TransactionsList.CurrentRow.Cells["contractno"].Value.ToString();
            VPay.Controls["radGroupBox2"].Controls["Membername"].Text = TransactionsList.CurrentRow.Cells["membername"].Value.ToString();
            VPay.AgreementID = TransactionsList.CurrentRow.Cells["agreementid"].Value.ToString();
            VPay.CreationDate1 = ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text);
            VPay.CreationDate2 = Contractdate2.Text;
            VPay.CompanyPercentId = Companylist.SelectedValue.ToString();
            VPay.ShowDialog();
        }

        private void unauthorizeContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(TransactionsList.RowCount < 1) { return; }
            if(Companylist.Text == "") { MessageBox.Show("Select A Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); Companylist.Focus(); return; }
            if (MessageBox.Show("Confirm Unauthorize", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            DVUnauthorize = SQLCMD.SQLdata("LS_CompanyContract_M 2,0," + TransactionsList.CurrentRow.Cells["agreementid"].Value.ToString() + ","+ Companylist.SelectedValue.ToString() + "," + General.Globalvariables.guserid + "").DefaultView;
            bSearch.PerformClick();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contractPaymentStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TransactionsList.RowCount < 1) { return; }
            if (TransactionsList.CurrentRow.Cells["EvostatusID"].Value.ToString() == "1") { MessageBox.Show("Contract Status Not Apply ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ContractPaymentStatus CPS = new ContractPaymentStatus();
            CPS.Controls["radGroupBox2"].Controls["AgreementNumber"].Text = TransactionsList.CurrentRow.Cells["contractno"].Value.ToString();
            CPS.AgreementID = TransactionsList.CurrentRow.Cells["agreementid"].Value.ToString();
            CPS.ShowDialog();
        }

        private void Contract2_TextChanged(object sender, EventArgs e)
        {

        }

        private void transferUpgradePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TransactionsList.RowCount <1) { MessageBox.Show("No Contract In The List ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            TransferUpgradePayments Tup = new TransferUpgradePayments();
            Tup.Controls["AgreementNumber"].Text = TransactionsList.CurrentRow.Cells["contractno"].Value.ToString();
            Tup.AgreementID = TransactionsList.CurrentRow.Cells["agreementID"].Value.ToString();
            Tup.ShowDialog();

        }

        private void paymentAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TransactionsList.RowCount < 1) { MessageBox.Show("No Contract In The List ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(Companylist.Text == "") { MessageBox.Show("Select a Company  ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Companylist.Focus(); return; }
            CompanyPaymentAdjust Cpa = new CompanyPaymentAdjust();
            decimal OverPayment = (( decimal.Parse(TransactionsList.CurrentRow.Cells["PendingBalance"].Value.ToString()) <0)? -1* decimal.Parse(TransactionsList.CurrentRow.Cells["PendingBalance"].Value.ToString()) : decimal.Parse(TransactionsList.CurrentRow.Cells["PendingBalance"].Value.ToString()));
            Cpa.Controls["AgreementNumber"].Text = TransactionsList.CurrentRow.Cells["contractno"].Value.ToString();
            Cpa.Controls["Amount"].Text = OverPayment.ToString("#,##0.00");
            Cpa.AgreementID = TransactionsList.CurrentRow.Cells["agreementID"].Value.ToString();
            Cpa.CompanyPercentID = Companylist.SelectedValue.ToString();
            Cpa.ShowDialog(); 
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
          int  CompanyID = ((Companylist.Text == "") ? 0 : int.Parse(Companylist.SelectedValue.ToString()));
            try
            {
              
                /*-------------------------------------------------------------------------------------------*/
                Loadtransactions =  SQLCMD.SQLdata("LS_CompanyCommisionReport_L " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text) + "," + ((PropertyID.Text.Trim() == "") ? "null" : PropertyID.Text) + ",'" +
                    ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "', " + ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," +
                    ((Contract2.Text.Trim() == "") ? "999999999" : Contract2.Text) + "," + ((Companylist.Text.Trim() == "") ? "null" : CompanyID.ToString()) + "").DefaultView;
                
                /*--------------------------------------------------------------------*/
                sumappliedpayment = SQLCMD.SQLdata("LS_CompanyReportHistory_L 0," + CompanyID + ",'" + ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "'").DefaultView;
                
                DVPayments = SQLCMD.SQLdata("LS_CompanyReportHistory_L 1," + CompanyID + ",'" + ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "'").DefaultView;
                /*--------------------------------------------------------------------*/
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
          
        }

        private void ExcludePaid_Click(object sender, EventArgs e)
        {
            if(Loadtransactions.Count < 1) { MessageBox.Show("No Contract To Export","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
            if (ExcludePaid.CheckState == CheckState.Unchecked)
            {
                if (ExcludeCanceled.CheckState == CheckState.Checked)
                {
                    Loadtransactions.RowFilter = "ExportAction not in(1,2)";

                }
                else
                {
                    Loadtransactions.RowFilter = "ExportAction not in(1)";
                }

                FillGrid(1);
            }
            else
            {
                Loadtransactions.RowFilter = "";
                FillGrid(1);
                ExcludeCanceled.CheckState = CheckState.Unchecked;
            }
        }

        private void ExcludeCanceled_Click(object sender, EventArgs e)
        {
            if (Loadtransactions.Count < 1) { MessageBox.Show("No Contract To Export", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            if (ExcludeCanceled.CheckState == CheckState.Unchecked)
            {
                 if (ExcludePaid.CheckState == CheckState.Checked)
                {
                    Loadtransactions.RowFilter = "ExportAction not in(1,2)";
                  
                }else
                { Loadtransactions.RowFilter = "ExportAction not in(2)";
                }
               
                FillGrid(1);
            }
            else
            {
                Loadtransactions.RowFilter = "";
                FillGrid(1);
                ExcludePaid.CheckState = CheckState.Unchecked;
            }
        }

        private void Companylist_SelectedValueChanged(object sender, EventArgs e)
        {
            bSearch.PerformClick();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                FillGrid(0);
                Double TotalPaid = 0, TotalTobePaid1 = 0;
                TotalPaid = double.Parse(sumappliedpayment.Table.Rows[0]["TotalPaid"].ToString());
                Appliedpayment.Text = TotalPaid.ToString("#,##0.00");
                TotalTobePaid1 = double.Parse(Paymentmade.Text) - TotalPaid;
                Totaltobepaid.Text = TotalTobePaid1.ToString("#,##0.00");
                var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
                frm.Close();
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }
           
        }
        /*-------------------------------------------------------------------------------------------*/
    }
}
