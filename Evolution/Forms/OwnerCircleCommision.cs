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
    public partial class OwnerCircleCommision : Form
    {
        public OwnerCircleCommision()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        General.GlobalAccess permit = new General.GlobalAccess(); 
        DataView DVSearch = new DataView();
        DataView DVHistiry = new DataView();
        DataView DVSave = new DataView();
        DataView DV = new DataView();
        Boolean EditServiceFee = false, AllowPreviousPeriod = false;
        private Int64 MemberServiceFeePaymentID;
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DVSearch = SQLCMD.SQLdata("LS_MemberServiceFeeSearch_L_v1 1,"+SalesfloorID.Text.Trim()+",'"+ PropertyID.Text.Trim() + "',"+MemberAgreementNo.Text.Trim()+","+((Sequence.Text.Trim()=="")? "null" : Sequence.Text.Trim())+"").DefaultView;
                if(DVSearch.Count > 0) { FillGrid(); FillGridBankInfo(); }
                
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void FillGrid()
        {
            
            DVHistiry  = SQLCMD.SQLdata("LS_MemberServiceFeePaymentDetail_ML 3,0,0,'" + StartDate.Value + "','" + EndDate.Value + "'," + DVSearch.Table.Rows[0]["AgreementID"].ToString() + "," +
            DVSearch.Table.Rows[0]["CompanyPercentID"].ToString() + ",0").DefaultView;
           
        }
        private void ClearDateRange()
        {
            StartDate.SetToNullValue();
            EndDate.SetToNullValue();
            Reference.Text = "";
            ckbTransfer.CheckState = CheckState.Checked;
            ddlNCType.Text = "";
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(DVSearch.Count < 1)
            { WeekPeriod.Text = ""; ServiceFeeAmount.Text = ""; MemberName.Text = ""; lblEvoStatus.Text = "..."; ClearDateRange();
                DVHistiry.RowFilter = String.Format("agreementid=0"); SumNight();  DV.RowFilter="BankName='xx'";
                goto Proximo;
            }
            //MemberServiceFeePaymentID = Convert.ToInt64(DVSearch.Table.Rows[0]["MemberServiceFeePaymentID"].ToString());
            GRDHistory.DataSource = DVHistiry;
            WeekPeriod.Text = DVSearch.Table.Rows[0]["WeekPeriod"].ToString();
            lblEvoStatus.Text = DVSearch.Table.Rows[0]["EvoStatus"].ToString();
            ServiceFeeAmount.Text = DVSearch.Table.Rows[0]["ServiceFee"].ToString();
            MemberName.Text  = DVSearch.Table.Rows[0]["MemberName"].ToString();

            ClearDateRange();
            /*--------------------------------------*/
            GRDHistory.DataSource = DVHistiry;
            GRD.DataSource = DV;
            SumNight();
            Proximo:;
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
           
            if (SalesfloorID.Text == "") { MessageBox.Show("Missing Salesfloor", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesfloorID.Focus(); return; }
            if (PropertyID.Text == "") { MessageBox.Show("Missing Property", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); PropertyID.Focus(); return; }
            if (MemberAgreementNo.Text == "") { MessageBox.Show("Missing Contract No.", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); MemberAgreementNo.Focus(); return; }
            /*-------------------------------------------------------------*/
            EditServiceFee = false; AllowPreviousPeriod = false;
            Wait wwt = new Wait();
            backgroundWorker2.RunWorkerAsync();
            wwt.ShowDialog();
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2) { PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2) { MemberAgreementNo.SelectionStart = 0; MemberAgreementNo.SelectionLength = MemberAgreementNo.Text.Length; MemberAgreementNo.Focus(); }
        }

        private void Sequence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { bSearch.PerformClick(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void MemberAgreementNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { Sequence.SelectionStart = 0; Sequence.SelectionLength = Sequence.Text.Length; Sequence.Focus(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "OC";
            MemberAgreementNo.Text = "";
            RequestDate.SetToNullValue();
            Sequence.Text = ""; SalesfloorID.Focus();
        }
        private int ValidateRequest()
        {
            DVSave = SQLCMD.SQLdata("LS_MemberServiceFeePaymentDetail_ML 4,@startdate='" + StartDate.Value  + "',@requestDate='" + RequestDate.Value + "'").DefaultView;
            return DVSave.Table.Rows[0]["Result"].ToString().Length;
        }
        private int ValidateDatePeriodt()
        {
            int Validated = 1;
            if(StartDate.Value < DateTime.Parse(DVSearch.Table.Rows[0]["startDate2"].ToString()) || StartDate.Value > DateTime.Parse(DVSearch.Table.Rows[0]["EndDate2"].ToString()))
            {
                if (StartDate.Value < DateTime.Parse(DVSearch.Table.Rows[0]["startDate"].ToString()) || StartDate.Value > DateTime.Parse(DVSearch.Table.Rows[0]["EndDate"].ToString()))
                {
                    //return Validated = 0; puso esta condicion para agregar cuando no se ha pagado el año pasado
                    if(StartDate.Value < DateTime.Parse(DVSearch.Table.Rows[0]["startDate"].ToString()).AddYears(-1) || StartDate.Value > DateTime.Parse(DVSearch.Table.Rows[0]["EndDate"].ToString()).AddYears(-1))
                    {
                        return Validated = 0;
                    }
                }
            }
            if (EndDate.Value < DateTime.Parse(DVSearch.Table.Rows[0]["startDate2"].ToString()) || EndDate.Value > DateTime.Parse(DVSearch.Table.Rows[0]["EndDate2"].ToString()))
            {
                if (EndDate.Value < DateTime.Parse(DVSearch.Table.Rows[0]["startDate"].ToString()) || EndDate.Value > DateTime.Parse(DVSearch.Table.Rows[0]["EndDate"].ToString()))
                {
                    // return Validated = 0; puso esta condicion para agregar cuando no se ha pagado el año pasado
                    if (EndDate.Value < DateTime.Parse(DVSearch.Table.Rows[0]["startDate"].ToString()).AddYears(-1) || EndDate.Value > DateTime.Parse(DVSearch.Table.Rows[0]["EndDate"].ToString()).AddYears(-1))
                    {
                        return Validated = 0;
                    }
                }
            }
            return Validated;
        }
        private void bProccess_Click(object sender, EventArgs e)
        {       
            if (DVSearch.Count < 1) { MessageBox.Show("Invalid Agreement #", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (RequestDate.Text == "") { MessageBox.Show("Missing Request Date", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); RequestDate.Focus(); return; }
            /*-----------------------------------------------------------------------------*/
            if (decimal.Parse(ServiceFeeAmount.Value.ToString()) <= 0) { MessageBox.Show("Invalid Service Fee", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (EndDate.Value <= StartDate.Value) { MessageBox.Show("Invalid Week Period Date", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*---------------------Validate Date Period-------------------------------------------*/
            if (ValidateDatePeriodt() ==0) { MessageBox.Show("Please Type A Valid Week Period Date", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*---------Validar Week Period-------------------------------------------------*/
            if (ValidateRequest() > 1 )
            {
               if (permit.AllowPermit(456) == 0) { MessageBox.Show("Request Rejected", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }/*permiso para agregar periodo cuando la fecha de solicitud sea menor que 3 meses*/
               else
                {
                    if (MessageBox.Show("Request Date Is Less Than 3 Months. \n Do You Want To Contunue ?","Owner",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) { return; }
                    else { goto ValidateRequest; }
                }
            }
            else { AllowPreviousPeriod = true; }
        /*-----------------------------------------------------------------------------*/
        ValidateRequest:;
            if (AllowPreviousPeriod == true) { goto Proximo; }
            Authorization aauto = new Authorization();
            if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AllowPreviousPeriod = true; 
            }
            else { return; }
          
            Proximo:;
            /*----------------------------Validar el total de noche permitida por año-------------------------------------------*/
            if(decimal.Parse(DVSearch.Table.Rows[0]["NightPermited"].ToString()) < (decimal.Parse((EndDate.Value - StartDate.Value).TotalDays.ToString()) + decimal.Parse(TotalNight.Text)) )
                { MessageBox.Show("Cannot Exceed  More Than " + DVSearch.Table.Rows[0]["NightPermited"].ToString()+ " Nights Per Year", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*-------------Validar la CN Type cuando es por recibo---------------------------------------------------------*/
            if (ckbReceipt.CheckState == CheckState.Checked)
            {
                if (ddlNCType.Text == "" || ddlNCType.SelectedValue == null) { MessageBox.Show("Invalid NC Type", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlNCType.Focus(); return; }
            }
            /*--------------------------------------------------------------------------------------------*/
            try
            {
                DVSave = SQLCMD.SQLdata("LS_MemberServiceFeePaymentDetail_ML 1,0,0,'" + StartDate.Value + "','" + EndDate.Value + "'," + DVSearch.Table.Rows[0]["AgreementID"].ToString() + "," +
                   DVSearch.Table.Rows[0]["CompanyPercentID"].ToString() + ",0").DefaultView;
                
                if (DVSave.Table.Rows[0]["Result"].ToString() != "0") { MessageBox.Show(DVSave.Table.Rows[0]["Result"].ToString(), "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                /*------------------Guardar si no existe el periodo en la DB-------------------------------------------------------------------------------------*/
                DVSave = SQLCMD.SQLdata($"LS_MemberServiceFeePaymentDetail_ML 0,0,0,'" + StartDate.Value + "','" + EndDate.Value + "'," + DVSearch.Table.Rows[0]["AgreementID"].ToString() + "," +
                  DVSearch.Table.Rows[0]["CompanyPercentID"].ToString() + "," + General.Globalvariables.guserid + ","+
                  decimal.Parse(ServiceFeeAmount.Text) +",'" + Reference.Text.Trim().Replace("'", "''") + "','" + RequestDate.Value + "',0," +
                  ((ckbTransfer.CheckState == CheckState.Checked)? 1 : 2) +","+((ddlNCType.Text=="" || ddlNCType.SelectedValue ==null)? "Null" : ddlNCType.SelectedValue)+"").DefaultView;
                /*-----------------------------------------*/
                //if (DVSave.Table.Rows[0][0].ToString() != "0" )
                //{
                //    MemberServiceFeePaymentID =Convert.ToInt64(DVSave.Table.Rows[0].Field<string>("Result").First().ToString());
                //}
                
                FillGrid();
                GRDHistory.DataSource = DVHistiry;
                SumNight();
                ClearDateRange();
                MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            if (GRDHistory.RowCount < 1) { return; }

            if (MessageBox.Show("Confirm Undo \n\n"+ GRDHistory.CurrentRow.Cells["StartDate"].Value.ToString()+"\n"+ GRDHistory.CurrentRow.Cells["EndDate"].Value.ToString(), "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            try
            {

                DVSave = SQLCMD.SQLdata("LS_MemberServiceFeePaymentDetail_ML 2,"+ GRDHistory.CurrentRow.Cells["MemberServiceFeePaymentDetailID"].Value.ToString() + ",@UserID=" + General.Globalvariables.guserid + "").DefaultView;
                /*-----------------------------------------*/
                FillGrid();
                GRDHistory.DataSource = DVHistiry;
                SumNight();
                MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            /*--------------------------------------------------------------*/
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void ServiceFeeAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DVSearch.Count < 1) { return; }
            if (permit.AllowPermit(455)==0) { e.Handled = true; return; }/*permiso para editar monto de service fee*/
            /*-----------------------------------------------------------*/
            if(EditServiceFee == true) { goto Proximo; }
            Authorization aauto = new Authorization();
            if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EditServiceFee = true;
            }
            Proximo:;
                if (EditServiceFee == false) { e.Handled = true; }
        }

        private void OptPreviousPeriod_Click(object sender, EventArgs e)
        {
            
           
        }

        private void ServiceFeeAmount_Click(object sender, EventArgs e)
        {
        }

        private void OwnerCircleCommision_Activated(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized) { WindowState = FormWindowState.Normal; }
        }

        private void StartDate_ValueChanged(object sender, EventArgs e)
        {
            EndDate.Value =  StartDate.Value ;
        }

        private void OwnerCircleCommision_Load(object sender, EventArgs e)
        {
            string mindateRequest = "01-01-2018";
            RequestDate.MinDate = ((permit.AllowPermit(457) == 0)? General.Globalvariables.Systemdate : DateTime.Parse( mindateRequest));
            StartDate.SetToNullValue();
            EndDate.SetToNullValue();
            RequestDate.Text = General.Globalvariables.Systemdate.ToString();
            ddlNCType.DataSource = SQLCMD.SQLdata("LS_OwnerCircleNcType_SPL 1").DefaultView;
            ddlNCType.DisplayMember = "Name";
            ddlNCType.ValueMember = "ID";
            ddlNCType.Text = "";

        }
        private void FillGridBankInfo()
        {
            DV = SQLCMD.SQLdata("LS_BankTransference_ML 4,@AgreementID=" + DVSearch.Table.Rows[0]["AgreementID"].ToString() + "").DefaultView;
            
        }
        private void bPrint_Click_1(object sender, EventArgs e)
        {
            DialogResult BankInforesult = MessageBox.Show("Do you want to creat it?", "No Banck Info", MessageBoxButtons.YesNo);

            int BankTransferenceID=0;
            if (GRD.SelectedRows.Count() > 0)
            {
                BankTransferenceID = Convert.ToInt32(GRD.CurrentRow.Cells["BankTransferenceID"].Value);
            }
            else
            {
             if(BankInforesult == DialogResult.Yes)
                {
                    bBankinfo.PerformClick();
                    BankTransferenceID = Convert.ToInt32(GRD.CurrentRow.Cells["BankTransferenceID"].Value);
                }
                else
                {
                    BankTransferenceID = 0;
                }
               
               
            }

            if (DVSearch.Count < 1) { return; }
            DVSave = SQLCMD.SQLdata("LS_MemberServiceFeeSearch_L_v1 2,null,null,null,null,"+DVSearch.Table.Rows[0]["Agreementid"].ToString()+",null,1,9999999999,'01-01-1990','01-01-3000',"+BankTransferenceID + " ").DefaultView;
            
            ReportViewer repo = new ReportViewer();
            string path = "Reports\\OCPaymentReport.rpt";
            repo.reportpath = path;
            repo.Inforeport = DVSave.Table.AsEnumerable().Where(x => x.Field<Int64>("ProcessStatus") == 0).AsDataView();
            repo.Exportar = false;
            repo.ShowDialog();

        }

        private void bBankinfo_Click(object sender, EventArgs e)
        {
            BankTransference bb = new BankTransference();
            bb.Controls["radGroupBox5"].Controls["SalesfloorID"].Text = SalesfloorID.Text;
            bb.Controls["radGroupBox5"].Controls["PropertyID"].Text = PropertyID.Text;
            bb.Controls["radGroupBox5"].Controls["MemberAgreementNo"].Text = MemberAgreementNo.Text;
            bb.Controls["radGroupBox5"].Controls["Sequence"].Text = Sequence.Text;
            bb.ShowDialog();
        }

        private void PropertyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void ckbTransfer_CheckStateChanged(object sender, EventArgs e)
        {
            ckbReceipt.CheckState = ((ckbTransfer.CheckState == CheckState.Checked)? CheckState.Unchecked : CheckState.Checked);
            lblNCType.Visible = ((ckbTransfer.CheckState == CheckState.Checked) ? false : true);
            ddlNCType.Visible = ((ckbTransfer.CheckState == CheckState.Checked) ? false : true);
        }

        private void ckbReceipt_CheckStateChanged(object sender, EventArgs e)
        {
            ckbTransfer.CheckState = ((ckbReceipt.CheckState == CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked);
            lblNCType.Visible = ((ckbReceipt.CheckState == CheckState.Checked) ? true : false);
            ddlNCType.Visible = ((ckbReceipt.CheckState == CheckState.Checked) ? true : false);
        }

        /*-------------Sumar noche y lo que pagara-----------------------------------*/
        private void SumNight()
        {
            if (GRDHistory.RowCount < 1) { TotalNight.Text = "0"; TotalToBePaid.Text = "0.00"; } //#,##0.00
            decimal Night = 0, ToPay = 0, ServiceFeePerWeek = 0;
            for (int R=0; R<=GRDHistory.RowCount -1; R++)
            {
                Night += decimal.Parse(GRDHistory.Rows[R].Cells["Night"].Value.ToString()); 
                ServiceFeePerWeek = decimal.Parse(GRDHistory.Rows[R].Cells["ServiceFeePerWeek"].Value.ToString());
            }
            TotalNight.Text = Night.ToString("#,##0.00");
            ToPay = (ServiceFeePerWeek / 7) * Night;
            TotalToBePaid.Text = ToPay.ToString("#,##0.00");
        }
       /*---------------------------------------------------------*/
    }
}
