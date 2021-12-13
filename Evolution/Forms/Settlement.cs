using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Styles;
using Telerik.WinControls.Data;
using Evolution.General;

namespace Evolution.Forms
{
    public partial class Settlement : Form
    {
        public Settlement()
        {
            InitializeComponent();
        }
        DataView contractview = new DataView();
        DataView contractproccess = new DataView();
        DataView salesfloors = new DataView();
        DataView propertys = new DataView();
        DataView paymethod = new DataView();
        DataView settlementview = new DataView();
        DataView liquidarproperty = new DataView();
        DataView DvSheet = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        string currentdate = DateTime.Now.ToShortDateString(), ContractList = "";
        decimal ProcessSettlement = 0;
        bool formatoCeldas = false;
        BackgroundWorker Bw;  // backGround worker PARA LAS FUNCIONES DE EXPORTACION
        BackgroundWorker BwSearchinContract;
        private void Settlement_Load(object sender, EventArgs e)
        {
            Fillcombos();
            General.GlobalAccess permiso = new General.GlobalAccess();
            permiso.permisomenucontectual(Menucontextual);
            permiso.groubox(radGroupBox5);
            permiso.groubox(radGroupBox7);
            permiso.groubox(radGroupBox4);
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            Salesfloor.Text = ""; Property.Text = "";
            
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            
            //Wait wwt = new Wait();
            if (Salesfloorid.Text.Trim() == "") { MessageBox.Show("Missing Sales Floor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Salesfloorid.Focus(); return; }
            if (DateTime.Parse(Contractdate2.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                SearchinWatingB.StartWaiting();
                SearchinWatingB.Visible = true;
                lblSearching.Visible = true;
                bXml.Enabled = ((Quick.Checked == true) ? false : true);
                bExport.Enabled = ((Quick.Checked == true) ? false : true);
                formatoCeldas = true;
                radLabel8.Visible = true;
                Foundrecords.Visible = true;
                Total.Text = "0.00"; Sales.Text = "0.00"; Closingtax.Text = "0.00";
                //backgroundWorker1.RunWorkerAsync();
                //wwt.ShowDialog();

                //******************************************** NUEVA FORMA DE BUSCAR CONTRATOS CON BACKGORUNDWORKER
                BwSearchinContract = new BackgroundWorker();
                BwSearchinContract.WorkerSupportsCancellation = true;
                BwSearchinContract.DoWork += (obj, arg) => BwSearchingContract();
                //BwSearchinContract.ProgressChanged += (obj, arg) => BwProgressSearchingContract(arg);
                BwSearchinContract.RunWorkerCompleted += (obj, arg) => BwCompletedSearchingContract();
                BwSearchinContract.RunWorkerAsync();

            }
            catch (Exception exc) { MessageBox.Show(exc.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { formatoCeldas = false; }
            /*--------t-------------------------------------------------------------------------------------------------------------*/

        }
        private void Searchcontract(int option)
        {/*----------------------------Asignaciones y Validacion-------------------------------------------------------------*/
            int record = 0; if (option == 1) { record = GRDSETTLEMENT.CurrentRow.Index; }
            int agreementid = 0; if (record > 0) { agreementid = int.Parse(GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString()); }
            string status = "";
            status = ((Active.Checked == true) ? "1" : "0") + ((Inactive.Checked == true) ? "1" : "0") + ((Legal.Checked == true) ? "1" : "0") + ((Hold.Checked == true) ? "1" : "0");
            /*----------------------------------------------------------------------------------------------*/
            if (option == 0)
            {
                contractview = SQLCMD.SQLdata("LS_LIQUIDACIONVENTAS_New_L1 " + ((Salesfloorid.Text == "") ? "null" : Salesfloorid.Text) + ",'" + ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "','" + Agreementnumber1.Text + "','" +
                Agreementnumber2.Text + "'," + option + ",'" + status + "'," + ((Propertyid.Text == "") ? "null" : Propertyid.Text) + "," + agreementid + "," + ((Paid.Checked == true) ? 1 : 0) + "," + ((Quick.Checked == true) ? "1" : "null") + "," +
                ((Settled.CheckState == CheckState.Checked) ? "1" : "0") + "," + ((ckbNCGuarantee.Checked == true) ? 1 : 0) + "").DefaultView;
            }
            else
            {
                agreementid = int.Parse(GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString());
                settlementview = SQLCMD.SQLdata("LS_LIQUIDACIONVENTAS_L1 " + ((Salesfloorid.Text == "") ? "null" : Salesfloorid.Text) + ",'" + ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "','" + Agreementnumber1.Text + "','" +
                  Agreementnumber2.Text + "'," + option + ",'" + status + "'," + ((Propertyid.Text == "") ? "null" : Propertyid.Text) + "," + agreementid + "," + ((Paid.Checked == true) ? 1 : 0) + "").DefaultView;
                TransactionSettlement(settlementview);
            }
            /*--------------------------------------------------------------------------------------------*/
        }
        private void TransactionSettlement(DataView DV)
        {
            GRDTRANSACTIONS.DataSource = DV;
        }
        private void FillGRDS(DataView DV)
        {

            /*-------------------------------------------------------------------------------------------------------------------------------------------------*/
            GRDSETTLEMENT.DataSource = DV;
            if (DV.Count > 0)
            {
                for (int record1 = 0; record1 <= GRDSETTLEMENT.RowCount - 1; record1++)
                {
                    /*-------------------------pinstar celda de contracto------------------------------------------------*/
                    this.GRDSETTLEMENT.Rows[record1].Cells["agreementnumber"].Style.CustomizeFill = true;
                    this.GRDSETTLEMENT.Rows[record1].Cells["agreementnumber"].Style.DrawFill = true;
                    this.GRDSETTLEMENT.Rows[record1].Cells["agreementnumber"].Style.BackColor = ((Convert.ToInt32(GRDSETTLEMENT.Rows[record1].Cells["NCGuarantee"].Value) == 1) ? Color.Lime : Color.White);
                    /*-------------------------------------pintar las filas de liquidaciones-------------------------------------------------------------*/
                    if (Convert.ToInt32(GRDSETTLEMENT.Rows[record1].Cells["select"].Value) == 0) { GRDSETTLEMENT.Rows[record1].Cells["select"].ReadOnly = true; }
                    if (GRDSETTLEMENT.Rows[record1].Cells["status"].Value.ToString() == "Hold") { GRDSETTLEMENT.Rows[record1].Cells["agreementnumber"].Style.ForeColor = Color.Red; }
                    if (Convert.ToDecimal(GRDSETTLEMENT.Rows[record1].Cells["SettlementValidation"].Value.ToString()) > 0 & Convert.ToDecimal(GRDSETTLEMENT.Rows[record1].Cells["Tosettlesales"].Value.ToString()) != 0)
                    { GRDSETTLEMENT.Rows[record1].Cells["Tosettlesales"].Style.ForeColor = Color.Red; }
                    if (Convert.ToDecimal(GRDSETTLEMENT.Rows[record1].Cells["SettlementValidation"].Value.ToString()) > 0 & Convert.ToDecimal(GRDSETTLEMENT.Rows[record1].Cells["TosettleTaxClosing"].Value.ToString()) != 0)
                    { GRDSETTLEMENT.Rows[record1].Cells["TosettleTaxClosing"].Style.ForeColor = Color.Red; }
                    if (GRDSETTLEMENT.Rows[record1].Cells["UpDown_Grade"].Value.ToString() != "") { GRDSETTLEMENT.Rows[record1].Cells["NetSales"].Style.ForeColor = Color.Blue; }

                }
            }
            grandtotalaliquidar();/*sumatoria de lo que se va a liquidar*/
            Foundrecords.Text = DV.Count.ToString();
            if (DV.Count < 1) { MessageBox.Show("No Record Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void GRDSETTLEMENT_CellPaint(object sender, GridViewCellPaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Salesfloorid_TextChanged(object sender, EventArgs e)
        {
            if (Salesfloorid.TextLength >= 2)
            {
                SalesfloorID1.Text = Salesfloorid.Text; Propertyid.SelectionStart = 0;
                Propertyid.SelectionLength = Propertyid.Text.Length; Propertyid.Focus(); Salesfloor.SelectedValue = Convert.ToInt32(Salesfloorid.Text);
            }
        }

        private void Propertyid_TextChanged(object sender, EventArgs e)
        {
            if (Propertyid.TextLength >= 2)
            { PropertyID1.Text = Propertyid.Text; Agreementnumber1.Focus(); Property.SelectedValue = Convert.ToInt32(Propertyid.Text); }
        }

        private void Agreementnumber1_TextChanged(object sender, EventArgs e)
        {
            Agreementnumber2.Text = Agreementnumber1.Text;
        }
        private void Fillcombos()
        {
            salesfloors = SQLCMD.SQLdata("sp_l_salesfloor '2','0',''").DefaultView;
            Salesfloor.DataSource = salesfloors;
            Salesfloor.DisplayMember = "name";
            Salesfloor.ValueMember = "Id";
            propertys = SQLCMD.SQLdata("sp_l_Property '4','0',' '").DefaultView;
            Property.DataSource = propertys;
            Property.DisplayMember = "commonName";
            Property.ValueMember = "Id";
            paymethod = SQLCMD.SQLdata("SP_L_paymenttype 1,0,null").DefaultView;
            Paymentmethod.DataSource = paymethod;
            Paymentmethod.DisplayMember = "Description";
            Paymentmethod.ValueMember = "ID";
            /*--------------------------------------------------------*/
        }
        private void bClear_Click(object sender, EventArgs e)
        {

            Salesfloorid.Text = "";
            Propertyid.Text = "";
            Agreementnumber1.Text = "";
            Agreementnumber2.Text = "";
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            Salesfloor.Text = "";
            Property.Text = "";
            Salesfloorid.Focus();
        }

        private void Settlement_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) { this.WindowState = FormWindowState.Maximized; }
            Salesfloorid.Focus();
            Paymentmethod.Text = "";
            Applicationdate.SetToNullValue();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Findname_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bProcess_Click(object sender, EventArgs e)
        {/*----------------------------Asignaciones y Validacion-------------------------------------------------------------*/
            int onerow = 0; double amoutsales = 0, amoutcctax = 0;
            String AppDate = "";
            if (GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            for (int row1 = 0; row1 <= GRDSETTLEMENT.RowCount - 1; row1++)
            {
                if (Convert.ToBoolean(GRDSETTLEMENT.Rows[row1].Cells["select"].Value))
                {
                    onerow++;
                    amoutsales = double.Parse(GRDSETTLEMENT.Rows[row1].Cells["tosettlesales"].Value.ToString());
                    amoutcctax = double.Parse(GRDSETTLEMENT.Rows[row1].Cells["tosettletaxclosing"].Value.ToString());
                }
            }
            if (onerow == 0) { MessageBox.Show("Nothing To Process", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            string OldDate = "01-01-1990";
            //if (int.Parse(GRDSETTLEMENT.Rows[record].Cells["Select"].Value.ToString()) == 0) { MessageBox.Show("Nothing To Process", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Paymentmethod.Text == "") { MessageBox.Show("Select Payment Type", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Paymentmethod.Focus(); return; }
            if (Applicationdate.Text.Trim() == "") { MessageBox.Show("Select Application Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Applicationdate.Focus(); return; }
            if (DateTime.Parse(Applicationdate.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Reference.Text.Trim() == "") { MessageBox.Show("Type The Reference", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Reference.Focus(); return; }
            if (Sales.Text.Trim() == "") { MessageBox.Show("Sales Amount Required", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Sales.Focus(); return; }
            if (Closingtax.Text.Trim() == "") { MessageBox.Show("Closing + Tax Amount Required", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Closingtax.Focus(); return; }
            AppDate = Applicationdate.Text;
            if (DateTime.Parse(Applicationdate.Text) > DateTime.Parse(Contractdate2.Text) || DateTime.Parse(Applicationdate.Text) < ((Contractdate1.Text == "") ? DateTime.Parse(OldDate) : DateTime.Parse(Contractdate1.Text)))
            {
                if (MessageBox.Show("Application Date is Out Of Searching Date Range \n Do you Want To Continue ? ", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) { return; }
            }
            /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            string salesfloorid = "", propertyid = "", contractdate1 = "", option = "0";
            if (Salesfloor.Text == "") { salesfloorid = "NULL"; } else { salesfloorid = Salesfloor.SelectedValue.ToString(); }
            if (Property.Text == "") { propertyid = "NULL"; } else { propertyid = Property.SelectedValue.ToString(); }
            if (Contractdate1.Text == "") { contractdate1 = null; } else { contractdate1 = Contractdate1.Text; }
            if (onerow > 1) { grandtotalaliquidar(); }
            if (double.Parse(Sales.Text) + double.Parse(Closingtax.Text) == 0) { MessageBox.Show("Cannot Process When Total is Zero", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (onerow == 1)
            {
                if (amoutsales < double.Parse(Sales.Text)) { MessageBox.Show("amount to settle is bigger than available", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (amoutcctax < double.Parse(Closingtax.Text)) { MessageBox.Show("amount to settle is bigger than available", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }
            /*--------------------------------------------------------------------------------------------------------------------------------------------*/
            SettlementsValidation();
            if (ProcessSettlement > 0)
            {
                if (MessageBox.Show("one or more contracts have payment already processed \n " + ContractList + "\n Do You Want To Continue ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            }
            if (MessageBox.Show("Confirm Process ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            /*--------------------------------Proccess Settlement--------------------------------------------------------------*/
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                contractproccess = SQLCMD.SQLdata("LS_M_CHECKHISTORY_2 " + salesfloorid + ",'" + contractdate1 + "','" + Contractdate2.Text + "','" + Agreementnumber1.Text + "','" +
                    Agreementnumber2.Text + "','" + Reference.Text + "'," + option + ",0," + Paymentmethod.SelectedValue + "," + General.Globalvariables.guserid + ",0," +
                   double.Parse(Sales.Text) + "," + double.Parse(Closingtax.Text) + ",0,0,'" + AppDate + "'").DefaultView;
                if (contractproccess.Count < 1) { return; }
                int checkhistoryID = Convert.ToInt32(contractproccess.Table.Rows[0]["ID_CHECKHISTORY"].ToString());
                /*------------------------Recorrer todos los contractos cotejado para procesarlos----------------------------------------------*/
                int agreementid;
                string SQLstrn = ""; Double saletosettle, cctaxtosettle, saletosettlex1, cctaxtosettlex1;

                for (int record3 = 0; record3 <= GRDSETTLEMENT.RowCount - 1; record3++)
                {
                    
                    if (Convert.ToBoolean(GRDSETTLEMENT.Rows[record3].Cells["select"].Value))
                    {
                        agreementid = Convert.ToInt32(GRDSETTLEMENT.Rows[record3].Cells["agreementid"].Value.ToString());
                        saletosettle = Convert.ToDouble(GRDSETTLEMENT.Rows[record3].Cells["tosettlesales"].Value.ToString());
                        cctaxtosettle = Convert.ToDouble(GRDSETTLEMENT.Rows[record3].Cells["tosettletaxclosing"].Value.ToString());
                        SQLstrn = SQLstrn + " " + "EXEC LS_M_CHECKHISTORYDETAIL1 " + checkhistoryID + "," + saletosettle + "," + cctaxtosettle + "," + agreementid + "";
                        /*------------------------------------------------------------------------------------------------------------------------------------*/
                        saletosettlex1 = ((onerow > 1) ? saletosettle : double.Parse(Sales.Text));
                        cctaxtosettlex1 = ((onerow > 1) ? cctaxtosettle : double.Parse(Closingtax.Text));
                        /*-----------------------poner en cero lo que se procesan para evitar procesarlo dos veces--------------------------------------*/
                        GRDSETTLEMENT.Rows[record3].Cells["select"].Value = "0";
                        GRDSETTLEMENT.Rows[record3].Cells["tosettlesales"].Value = "0";
                        GRDSETTLEMENT.Rows[record3].Cells["tosettletaxclosing"].Value = "0";
                        // UpdateProcessedRecord(agreementid, saletosettlex1, cctaxtosettlex1); omitido
                    }
                }

                contractproccess = SQLCMD.SQLdata(SQLstrn).DefaultView;
                grandtotalaliquidar();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void GRDSETTLEMENT_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            AgreementIDView.Text = GRDSETTLEMENT.CurrentRow.Cells["AgreementID"].Value.ToString();
            Authorization aauto = new Authorization();
            if (e.ColumnIndex == 0)
            {
                // MessageBox.Show("test click");
                if (GRDSETTLEMENT.CurrentRow.Cells["select"].Value.ToString() == "1" || double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettlesales"].Value.ToString()) + double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettletaxclosing"].Value.ToString()) != 0)//tosettletaxclosing
                {

                    if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        GRDSETTLEMENT.CurrentRow.Cells["select"].ReadOnly = false;
                        contractview.RowFilter = string.Format("agreementid = " + int.Parse(GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString()) + "");
                        contractview.AllowEdit = true;

                        contractview[0]["R"] = ((int.Parse(GRDSETTLEMENT.CurrentRow.Cells["select"].Value.ToString()) == 1) ? 0 : 1);
                        contractview[0].EndEdit();
                        contractview.RowFilter = "";
                        grandtotalaliquidar();/*sumatoria de lo que se va a liquidar*/
                    }

                }
            }

        }

        private void holdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            HoldSettlement hold = new HoldSettlement();

            // int record = GRDSETTLEMENT.CurrentRow.Cells[""].Value
            hold.agreementid = GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString();
            hold.agreementnumber = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            hold.membername = GRDSETTLEMENT.CurrentRow.Cells["name"].Value.ToString();
            if (hold.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                contractview.RowFilter = string.Format("agreementid =" + GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString() + "");
                contractview.AllowEdit = true;
                double amounttosettle = double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettlesales"].Value.ToString()) + double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettletaxclosing"].Value.ToString());
                contractview[0]["R"] = ((int.Parse(GRDSETTLEMENT.CurrentRow.Cells["Select"].Value.ToString()) == 1) ? 0 : ((amounttosettle > 0) ? 1 : 0));
                contractview[0]["Status_Description"] = ((GRDSETTLEMENT.CurrentRow.Cells["status"].Value.ToString() == "Hold") ? "Active" : "Hold");
                contractview[0].EndEdit();
                contractview.RowFilter = "";
            }
        }

        private void paymentDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            PaymentDetail paydetail = new PaymentDetail();
            decimal totalpaid1 = 0, AccountReceivable1 = 0;
            paydetail.datecreate = Contractdate2.Text;
            totalpaid1 = decimal.Parse(GRDSETTLEMENT.CurrentRow.Cells["paymentreceived"].Value.ToString());
            AccountReceivable1 = decimal.Parse(GRDSETTLEMENT.CurrentRow.Cells["accountreceive"].Value.ToString());
            paydetail.Controls["radGroupBox2"].Controls["AgreementNumber"].Text = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            paydetail.Controls["radGroupBox2"].Controls["Membername"].Text = GRDSETTLEMENT.CurrentRow.Cells["name"].Value.ToString();
            paydetail.Controls["radGroupBox2"].Controls["TotalPaid1"].Text = totalpaid1.ToString("#,##0.00");
            paydetail.Controls["AccountReceivable"].Text = AccountReceivable1.ToString("#,##0.00");
            paydetail.agreementid = GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString();
            if (paydetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { //no ejectar nada despues de cerrar este form 
            }
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts To Process", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (int.Parse(GRDSETTLEMENT.CurrentRow.Cells["Select"].Value.ToString()) == 0) { MessageBox.Show("Nothing To Process", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ProcessContracts prcess = new ProcessContracts();
            prcess.agrementnumber = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            prcess.SettlementValidation = double.Parse(GRDSETTLEMENT.CurrentRow.Cells["SettlementValidation"].Value.ToString());
            prcess.reference = Reference.Text;
            prcess.paymentmethod = ((Paymentmethod.Text.Trim() == "") ? "0" : Paymentmethod.SelectedValue.ToString());
            prcess.sales = double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettlesales"].Value.ToString());
            prcess.closing_tax = double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettletaxclosing"].Value.ToString());
            prcess.salesfloorid = GRDSETTLEMENT.CurrentRow.Cells["salesfloorid"].Value.ToString();
            prcess.contractdate1 = ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text);
            prcess.contractdate2 = Contractdate2.Text;
            prcess.agreementid = GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString();
            if (prcess.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UpdateProcessedRecord(int.Parse(GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString()), prcess.xsales, prcess.xcctax);
                contractview.RowFilter = "";
            }
        }

        private void viewContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ContractSequence seqcontract = new ContractSequence();
            seqcontract.action = "1";
            seqcontract.AN = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            seqcontract.MdiParent = MdiParent;
            seqcontract.Show();
        }

        private void Salesfloorid_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Propertyid_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Agreementnumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { Agreementnumber2.Focus(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Agreementnumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { bSearch.PerformClick(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Closingtax_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void bUndo_Click(object sender, EventArgs e)
        {

            Wait wwt = new Wait();
            Authorization aauto = new Authorization();
            try
            {
                int option = 0, action1 = 0, agreementid, IDcheckhistory, salesfloorid, idcheckhistorydetail; string sqlquery = "";
                // double amoutsales, amountcctax;

                if (bSamereference.IsChecked)
                {
                    action1 = 1;
                    if (Comment.Text.Trim() == "") { MessageBox.Show("Reference Is Required", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Comment.Focus(); return; }
                    /*------------------------Validar si existe la referencia---------------------------*/
                    int salesfloorx1 = ((SalesfloorID1.Text.Trim() == "") ? 0 : int.Parse(SalesfloorID1.Text));
                    settlementview = SQLCMD.SQLdata("LS_M_CHECKHISTORY_2 " + salesfloorx1 + ",null,null,null,null,'" + Comment.Text.Trim() + "',4,null,null,null,null,null,null").DefaultView;
                    if (settlementview.Count < 1) { MessageBox.Show("This Reference Does Not Exist", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    /*------------------------------------------------------------------------------------------------*/
                    option = 2;
                    if (SalesfloorID1.Text.Trim() == "" || PropertyID1.Text.Trim() == "")
                    {
                        action1 = 2;
                        if (MessageBox.Show("Warning Salesfloor and Property No Include \n All Transactions With this Reference will be Undone. Continue ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        { return; }
                    }
                    else
                    {
                        if (MessageBox.Show("Confirm Undo", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                    }

                    salesfloorid = ((SalesfloorID1.Text.Trim() == "") ? 0 : int.Parse(SalesfloorID1.Text.Trim()));
                    IDcheckhistory = 0;
                    idcheckhistorydetail = 0;
                    agreementid = 0;
                    /*-----------------------------------------------------------------------------------------------------------*/
                    sqlquery = sqlquery + " " + "EXEC LS_M_CHECKHISTORY_2 " + salesfloorid + ",null,null,null,null,'" + Comment.Text + "'," + option + ",null,null," + General.Globalvariables.guserid + "," +
                        IDcheckhistory + ",null,null," + idcheckhistorydetail + "," + agreementid + ",null," + action1 + "";
                    /*-------------------------------------------------------------------------------------------------------------------*/
                }
                /*----------------------------------------------------------------------------------------------------------------------------------------*/
                if (bCurrent.IsChecked == true)
                {
                    if (GRDTRANSACTIONS.Rows.Count < 1) { MessageBox.Show("No Transaction In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    option = 3;
                    salesfloorid = int.Parse(GRDTRANSACTIONS.CurrentRow.Cells["salesfloorID"].Value.ToString());
                    IDcheckhistory = int.Parse(GRDTRANSACTIONS.CurrentRow.Cells["ID"].Value.ToString());
                    idcheckhistorydetail = int.Parse(GRDTRANSACTIONS.CurrentRow.Cells["checkhistorydetailID"].Value.ToString());
                    agreementid = int.Parse(GRDTRANSACTIONS.CurrentRow.Cells["agreementid"].Value.ToString());
                    /*-----------------------------------------------------------------------------------------------------------------*/
                    if (MessageBox.Show("Confirm Undo", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                    /*-----------------------------------------------------------------------------------------------------------------*/
                    sqlquery = sqlquery + " LS_M_CHECKHISTORY_2 " + salesfloorid + ",null,null,null,null,null," + option + ",null,null," + General.Globalvariables.guserid + "," +
                        IDcheckhistory + ",null,null," + idcheckhistorydetail + "," + agreementid + ",null";
                    /*-------------------------------------------------------------------------------------------------------------------*/
                }
                /*------------------------Deshacer Transacciones-------------------------------------------------------------------------------------------------------*/
                if ((SalesfloorID1.Text.Trim() == "" || PropertyID1.Text.Trim() == "") & bSamereference.IsChecked == true)
                {
                    if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        wwt.Show(); wwt.Refresh();
                        settlementview = SQLCMD.SQLdata(sqlquery).DefaultView;
                    }
                    else { return; }
                }
                else
                {
                    wwt.Show(); wwt.Refresh();
                    settlementview = SQLCMD.SQLdata(sqlquery).DefaultView;
                }
                if (action1 > 0 & contractview.Count > 0) { pictureBox2.Visible = true; Searchcontract(0); pictureBox2.Visible = false; }/*Actializar el listado para ver el efecto del Undo*/
                if (contractview.Count > 0)/*filtrar si hay contracto en la lista de contracto a liquidar*/
                {
                    Searchcontract(1);
                    contractview.RowFilter = "";
                    Findname.Text = "-"; Findname.Text = "";/*actualizar el gridview al buscar en el textbox name*/
                    grandtotalaliquidar();
                }
                MessageBox.Show("Undone", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radPageView1.SelectedPage = radPageViewPage1;
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER"); }
            finally { wwt.Close(); }
        }

        private void GRDSETTLEMENT_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            paymentDetailToolStripMenuItem.PerformClick();
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { return; }
            Searchcontract(1);
            radPageView1.SelectedPage = radPageViewPage2;
        }
        private void UpdateProcessedRecord(int agreementid, double xsales, double xcctax)
        {
            contractview.RowFilter = string.Format("agreementid =" + agreementid + "");
            contractview.AllowEdit = true;
            contractview[0]["R"] = 0;
            contractview[0]["sales_settled"] = double.Parse(contractview[0]["sales_settled"].ToString()) + double.Parse(contractview[0]["tosettle_sales"].ToString());
            contractview[0]["tax_settled"] = double.Parse(contractview[0]["tax_settled"].ToString()) + double.Parse(contractview[0]["tosettle_taxcc"].ToString());
            contractview[0]["tosettle_sales"] = double.Parse(contractview[0]["tosettle_sales"].ToString()) - xsales;
            contractview[0]["tosettle_taxcc"] = double.Parse(contractview[0]["tosettle_taxcc"].ToString()) - xcctax;
            contractview[0]["pendigtosettle_sales"] = double.Parse(contractview[0]["distribution_sales"].ToString()) - double.Parse(contractview[0]["sales_settled"].ToString());
            contractview[0]["pendigtosettle_taxcc"] = double.Parse(contractview[0]["distribution_taxcc"].ToString()) - double.Parse(contractview[0]["tax_settled"].ToString());
            contractview[0].EndEdit();
            /*------------------------------*/

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string status = "", agreementid = "0";
            status = ((Active.Checked == true) ? "1" : "0") + ((Inactive.Checked == true) ? "1" : "0") + ((Legal.Checked == true) ? "1" : "0") + ((Hold.Checked == true) ? "1" : "0");
            /*-------------------------------------------------------------------------------------------------------*/
            for (int record = 0; record <= GRDSETTLEMENT.RowCount - 1; record++)
            {
                agreementid = agreementid + "," + GRDSETTLEMENT.Rows[record].Cells["agreementid"].Value.ToString();
            }
            /*-------------------------------------------------------------------------------------------------------*/
            SelectReport repo = new SelectReport();
            repo.salesfloor = Salesfloorid.Text;
            repo.propertyid = Propertyid.Text;
            repo.contractdate1 = Contractdate1.Text;
            repo.contractdate2 = Contractdate2.Text;
            repo.contract1 = Agreementnumber1.Text;
            repo.contract2 = Agreementnumber2.Text;
            repo.status = status;
            repo.paid = ((Paid.Checked == true) ? "1" : "0");
            repo.agreementid = agreementid;
            repo.DVreport = contractview;
            repo.ShowDialog();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait frmwait = new Wait();
            try
            {
                frmwait.Show(); frmwait.Refresh();
                General.ExportToExcel exportexcel = new General.ExportToExcel();

                exportexcel.ExportaraExcel(contractview);
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, "OWNER"); }
            finally { frmwait.Close(); }
        }

        

        //*********************************funcion asincronica para el boton "to Thirdd*************************************************
        private async void BwBExport()
        {
            ExportToThirdGlobaliaCom ETHIRD_GLOBLA = new ExportToThirdGlobaliaCom();
            StringBuilder AllAgreementID = new StringBuilder();
            AllAgreementID.Append("0");
            for (int rw = 0; rw <= GRDSETTLEMENT.RowCount - 1; rw++)
            {
                AllAgreementID.Append("," + GRDSETTLEMENT.Rows[rw].Cells["agreementid"].Value.ToString());
            }
            DataView DAV = new DataView();


            DAV = SQLCMD.SQLdata($"LS_SUMMARYPAYMENTREPORT_M '{AllAgreementID.ToString()}','{((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text)}','{Contractdate2.Text}'").DefaultView;
           
            /*----------------------------------------*/
            ETHIRD_GLOBLA.ExportarGridview(GRDSETTLEMENT, Salesfloor.Text, ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text), Contractdate2.Text, 0, DAV);
            //General.ExportGlobaliaComision.ExportarGridview(GRDSETTLEMENT, Salesfloor.Text, ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text), Contractdate2.Text, 0, DAV);

        }
        //*********************************funcion asincronica para buscar los contratos*************************************************
        private async void BwSearchingContract(DoWorkEventArgs e = null)
        {

            if (BwSearchinContract.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Searchcontract(0);
        }
        private async void BwCompletedSearchingContract()
        {
            FillGRDS(contractview);
            //var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            //frm.Close();

            SearchinWatingB.StopWaiting();
            SearchinWatingB.Visible = false;
            lblSearching.Visible = false;


        }
       

        //*************funcion asincronica para "Export"*****************************************************
        private async void BwReportToThird()
        {
           
            General.ReportToThird_v2 ReportToThird = new General.ReportToThird_v2(1);
            ReportToThird.ExportarGridview(GRDSETTLEMENT, Salesfloor.Text, ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text), Contractdate2.Text, 1);
            
        }
       
        private async void WorkerCompleted(object btn = null)
        {
            ExportWaitingBar.StopWaiting();
            ExportWaitingBar.Visible = false;
            LblEporting.Visible = false;
            if (btn is RadButton)
            {
                ((RadButton)btn).Enabled = true;
            }
            else
            {
                ((Button)btn).Enabled = true;
            }
           

        }
        //************************************************************
        private void bExport1_Click(object sender, EventArgs e)
        {
           
            try
            {
                ((Control)sender).Enabled = false;
                Bw = new BackgroundWorker();
                ExportWaitingBar.StartWaiting();
                ExportWaitingBar.Visible = true;
                LblEporting.Visible = true;
                Bw.DoWork += (obj, arg) => BwReportToThird();
                Bw.RunWorkerCompleted += (obj, arg) => WorkerCompleted(sender);
                Bw.RunWorkerAsync();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "OWNER");
            }
            /*------------------------------------------------*/

        }

        private void bXml_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait frmwait = new Wait();
            try
            {
                //!= "UPGRADED"  EvoStatus
                DataView Data = contractview.Table.AsEnumerable().Where(x => !(x.Field<string>("UpDown_Grade").Contains("UpGrade"))).AsDataView();

                frmwait.Show(); frmwait.Refresh();
                General.ExportToExcel exportaXML = new General.ExportToExcel();
                exportaXML.ExportToXML(Data);
            }
            catch (Exception exs) { MessageBox.Show(exs.Message, "OWNER"); }
            finally { frmwait.Close(); }
        }
        /*---------------Sumar el total de tosettlesales y tosettlecctax--------------------------------------*/
        private void grandtotalaliquidar()
        {
            double sumsalestosettle = 0, sumcctaxtosettle = 0, grandtotal = 0;

            if (GRDSETTLEMENT.RowCount < 1) { return; }
            for (int record = 0; record <= GRDSETTLEMENT.RowCount - 1; record++)
            {
                if (Convert.ToBoolean(GRDSETTLEMENT.Rows[record].Cells["select"].Value))
                {
                    sumsalestosettle += double.Parse(GRDSETTLEMENT.Rows[record].Cells["tosettlesales"].Value.ToString());
                    sumcctaxtosettle += double.Parse(GRDSETTLEMENT.Rows[record].Cells["tosettletaxclosing"].Value.ToString());
                }
            }

            Sales.Text = sumsalestosettle.ToString("#,##0.00");
            Closingtax.Text = sumcctaxtosettle.ToString("#,##0.00");
            grandtotal = sumsalestosettle + sumcctaxtosettle;
            Total.Text = grandtotal.ToString("#,##0.00");
        }



        private void radPageViewPage2_Click(object sender, EventArgs e)
        {

        }

        private void radPageViewPage2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void radPageView1_Click(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage == radPageViewPage2)
            {
                if (GRDSETTLEMENT.RowCount < 1) { return; }
                Searchcontract(1);
            }
        }

        private void Ckeckinclude_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            SalesfloorID1.Enabled = true; PropertyID1.Enabled = true;
            if (Ckeckinclude.Checked == false)
            { SalesfloorID1.Enabled = false; PropertyID1.Enabled = false; }
        }

        private void Closingtax_TextChanged(object sender, EventArgs e)
        {
            double x1 = ((Sales.Text.Trim() == "") ? 0 : double.Parse(Sales.Text)), x2 = ((Closingtax.Text.Trim() == "") ? 0 : double.Parse(Closingtax.Text)), x3 = 0;
            x3 = x1 + x2;
            Total.Text = x3.ToString("#,##0.00");
        }

        private void Sales_TextChanged(object sender, EventArgs e)
        {
            double x1 = ((Sales.Text.Trim() == "") ? 0 : double.Parse(Sales.Text)), x2 = ((Closingtax.Text.Trim() == "") ? 0 : double.Parse(Closingtax.Text)), x3 = 0;
            x3 = x1 + x2;
            Total.Text = x3.ToString("#,##0.00");
        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        //private void MasterTemplate_CellPaint(object sender, GridViewCellPaintEventArgs e)
        //{


        //}
        private void GRDSETTLEMENT_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            /*--------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "tosettlesales")
            {
                e.CellElement.DrawFill = true;
                if (Convert.ToDecimal(e.CellElement.Value) != 0)
                {

                    e.CellElement.BackColor = Color.LemonChiffon;
                    e.CellElement.NumberOfColors = 1;
                }
                else
                {
                    e.CellElement.BackColor = Color.Yellow;
                    e.CellElement.NumberOfColors = 1;
                }
            }
            /*--------------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "tosettletaxclosing")
            {
                e.CellElement.DrawFill = true;
                if (Convert.ToDecimal(e.CellElement.Value) != 0)
                {

                    e.CellElement.BackColor = Color.LemonChiffon;
                    e.CellElement.NumberOfColors = 1;
                }
                else
                {
                    e.CellElement.BackColor = Color.Yellow;
                    e.CellElement.NumberOfColors = 1;
                }

            }
            if (e.CellElement.ColumnInfo.Name == "settledsales")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.PaleTurquoise;
                e.CellElement.NumberOfColors = 1;

            }
            /*-------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "settledtaxclosing")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.PaleTurquoise;
                e.CellElement.NumberOfColors = 1;

            }
            /*-------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "pendingtosales")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.PaleTurquoise;
                e.CellElement.NumberOfColors = 1;

            }
            /*-------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "pendingtotaxclosing")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.PaleTurquoise;
                e.CellElement.NumberOfColors = 1;

            }
            /*-------Inactivar color para las demas columnas----*/
            if (e.CellElement.ColumnInfo.Name == "netsales") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "closingcost") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "tax") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "distsales") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "distclosingtax") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "paymentreceived") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "paymentpercent") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "accountreceive") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "ownercorrection") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "name") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "status") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "contractdate") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "updrade") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "financetax") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "exitprogram") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "contractsequence") { e.CellElement.DrawFill = false; }

        }
        private void MasterTemplate_CustomSorting(object sender, GridViewCustomSortingEventArgs e)
        {

        }

        private void radPageViewPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReportToThird_Click(object sender, EventArgs e)
        {
           
            //ExportToThirdGlobaliaCom ETHIRD_GLOBLA = new ExportToThirdGlobaliaCom();
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            //Wait frmwait = new Wait();
            try
            {
                if (GRDSETTLEMENT.Rows.Count > 0)
                {

                    ((Control)sender).Enabled = false;
                    ExportWaitingBar.Visible = true;
                    LblEporting.Visible = true;

                    ExportWaitingBar.StartWaiting();
                    Bw = new BackgroundWorker();
                    Bw.DoWork += (obj, arg) => BwBExport();
                    Bw.RunWorkerCompleted += (obj, arg) => WorkerCompleted(sender);
                    Bw.RunWorkerAsync();

                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {
                //frmwait.Close();
            }
            /*----------------------------------------------------------------------------------------*/
        }

        private void GRDSETTLEMENT_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void bWeekly_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait frmwait = new Wait();
            try
            {
                frmwait.Show(); frmwait.Refresh();
                General.WeeklyReport Semanal = new General.WeeklyReport();
                DateTime Since = ((Contractdate1.Text == "") ? DateTime.Parse("01-01-1990") : DateTime.Parse(Contractdate1.Text));
                DateTime Until = DateTime.Parse(Contractdate2.Text);
                Semanal.ExportarGridview(contractview, Salesfloor.Text, Since.ToString("dd-MMM-yyyy"), Until.ToString("dd-MMMM-yyyy"), int.Parse(Salesfloor.SelectedValue.ToString()));
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { frmwait.Close(); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Findname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { FilterContract(); }
        }
        private void FilterContract()
        {
            contractview.RowFilter = "";
            if (contractview.Count < 1) { Findname.Text = ""; return; }
            try
            {

                contractview.RowFilter = string.Format("MemberName+agreementnumber like '%" + Findname.Text.Trim().Replace("'", "''") + "%'");

                FillGRDS(contractview);
            }
            catch (Exception) { MessageBox.Show("Record No found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); Findname.Focus(); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RecordFound2.Text = DateTime.Now.Second.ToString();
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Searchcontract(0);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGRDS(contractview);
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
            /*------------------------------------------------*/
        }

        private void bVerificationSheet_Click(object sender, EventArgs e)
        {
            try
            {

                if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contract In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Salesfloorid.Focus(); return; }
                ((Control)sender).Enabled = false;
                ExportWaitingBar.StartWaiting();
                ExportWaitingBar.Visible = true;
                LblEporting.Visible = true;
                Bw = new BackgroundWorker();
                Bw.DoWork += (obj, arg) => StartverificSheetAsinc();
                Bw.RunWorkerCompleted += (obj, arg) => WorkerCompleted(sender);
                Bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OWNER");
            }
           
        
      
            //Wait wwt = new Wait();
            //backgroundWorker2.RunWorkerAsync();
            //wwt.ShowDialog();

        }

        private async void StartverificSheetAsinc()
        {
            string AgreementIDVS = "";
            for (int Vs = 0; Vs <= GRDSETTLEMENT.RowCount - 1; Vs++)
            {
                AgreementIDVS = AgreementIDVS + ((AgreementIDVS.Length <= 0) ? "" : ",") + GRDSETTLEMENT.Rows[Vs].Cells["AgreementID"].Value.ToString();
            }

            DvSheet = SQLCMD.SQLdata("DTSdemo.[dbo].[CONTRACT_TEMPLATE_OWNER_VS] '" + AgreementIDVS + "'").DefaultView;
           
            General.VerificationSheetExport vs = new General.VerificationSheetExport();
            vs.ExportVS(DvSheet);
            //var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            //frm.Close();
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
          

            //string AgreementIDVS = "";
            //for (int Vs = 0; Vs <= GRDSETTLEMENT.RowCount - 1; Vs++)
            //{
            //    AgreementIDVS = AgreementIDVS + ((AgreementIDVS.Length <= 0) ? "" : ",") + GRDSETTLEMENT.Rows[Vs].Cells["AgreementID"].Value.ToString();
            //}

            //DvSheet = SQLCMD.SQLdata("DTSdemo.[dbo].[CONTRACT_TEMPLATE_OWNER_VS] '" + AgreementIDVS + "'").DefaultView;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //General.VerificationSheetExport vs = new General.VerificationSheetExport();
            //vs.ExportVS(DvSheet);
            //var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            //frm.Close();
        }

        private void setHoldCanceledContractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            bool IsCanceled = false;
            HoldCanceledContract frm = new HoldCanceledContract();
            for (int Rw = 0; Rw <= GRDSETTLEMENT.RowCount - 1; Rw++)
            {
                if (GRDSETTLEMENT.Rows[Rw].Cells["EvoStatus"].Value.ToString().ToUpper() == "CANCELED" && GRDSETTLEMENT.Rows[Rw].Cells["status"].Value.ToString().ToUpper() != "HOLD")
                {
                    var contractno = new HoldCanceledContract.ContractsCanceled
                    {
                        Selected = 1,
                        ContractNo = GRDSETTLEMENT.Rows[Rw].Cells["agreementnumber"].Value.ToString(),
                        Status = GRDSETTLEMENT.Rows[Rw].Cells["EvoStatus"].Value.ToString(),
                        BalanceDue = double.Parse(GRDSETTLEMENT.Rows[Rw].Cells["accountreceive"].Value.ToString()),
                        AgreementID = long.Parse(GRDSETTLEMENT.Rows[Rw].Cells["agreementid"].Value.ToString())
                    };
                    frm.ContractoCancelado.Add(contractno);
                    IsCanceled = true;
                }
            }
            if (IsCanceled == false) { MessageBox.Show("No Contracts Canceled In The List \n Or Contracts Are Already Hold", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bSearch.PerformClick();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
 
            ChoosExportColumns Columns = new ChoosExportColumns(1);
            Columns.ShowDialog();
        }

        private void Settlement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (BwSearchinContract != null)
                {
                    if (BwSearchinContract.IsBusy)
                    {
                        BwSearchinContract.CancelAsync();
                        
                    }
                }
               

            }

        }

        private void SettlementsValidation()
        {
            ProcessSettlement = 0;/* ContractList = "";*/
            for (int row1 = 0; row1 <= GRDSETTLEMENT.RowCount - 1; row1++)
            {
                if (decimal.Parse(GRDSETTLEMENT.Rows[row1].Cells["SettlementValidation"].Value.ToString()) > 0)
                {
                    ProcessSettlement = ProcessSettlement + decimal.Parse(GRDSETTLEMENT.Rows[row1].Cells["SettlementValidation"].Value.ToString());
                    ContractList = ContractList + "," + GRDSETTLEMENT.Rows[row1].Cells["AgreementNumber"].Value.ToString();
                }
            }
        }
        /*====================================================================================================================================================================================*/
    }
}
