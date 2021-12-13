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
    public partial class CompanyContract : Form
    {
        public CompanyContract()
        {
            InitializeComponent();
        }
        DataView DVCompany = new DataView();
        DataView DVContract = new DataView();
        DataView DVContract1 = new DataView();
        DataView DVAuthorize = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void CompanyContract_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortTimeString();
            CompanyList.Text = "";
            SalesfloorID.Focus();
        }

        private void CompanyContract_Load(object sender, EventArgs e)
        {
            DVCompany = SQLCMD.SQLdata("LS_CompanyPercent_L").DefaultView;
            CompanyList.DataSource = DVCompany;
            CompanyList.DisplayMember = "Companyname";
            CompanyList.ValueMember = "CompanyPercentID";
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = "";
            Contract2.Text = "";
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortTimeString();
            CompanyList.Text = "";
            SalesfloorID.Focus();
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        { /*---------------------------------------------------------------------------------------------*/
            Wait wwt = new Wait();
            try
            {
                if (SalesfloorID.Text.Trim() == "") { MessageBox.Show("Missing Field SalesFloor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesfloorID.Focus(); return; }
                if (CompanyList.Text.Trim() == "") { MessageBox.Show("Please Select Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); CompanyList.Focus(); return; }
                /*---------------------------------------------------------------------------------------------*/
                wwt.Show(); wwt.Refresh();
                DVContract = SQLCMD.SQLdata("LS_CompanyContractSearch_L " + SalesfloorID.Text + "," + ((PropertyID.Text.Trim() == "") ? "null" : "'"+PropertyID.Text+"'") + ",'" +
                 ((Contractdate1.Text.Trim() == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "'," +
                 ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," + ((Contract2.Text.Trim() == "") ? "999999999" : Contract2.Text) + "," +
                 ((CompanyList.Text.Trim() == "") ? "null" : CompanyList.SelectedValue) + "").DefaultView;
                /*---------------------------------------------------------------------------------------------*/
                LoadContracts();
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message); }
            finally { wwt.Close(); }
            /*---------------------------------------------------------------------------------------------*/
        }
        private void LoadContracts()
        {
            //ContractNoauthorized.Rows.Clear();
            //ContractAuthorized.Rows.Clear();
            //if (DVContract.Count < 1) { return; }
            DataTable dt = new DataTable();
            dt = DVContract.Table;
            DVContract1 = new DataView(dt);
            /*-------------------------------------------------------*/
            DVContract.RowFilter = "Authorized = 0";
            ContractNoauthorized.DataSource = DVContract;
            //if (DVContract.Count > 0)
            //{
            //    foreach (DataRowView DV in DVContract)
            //    {
            //        ContractNoauthorized.Rows.Add(DV["R"], DV["Agreementnumber"], DV["contractdate"], DV["status"], DV["price"], DV["closingcost"], DV["tax"], DV["agreementid"],
            //            DV["Companyname"], DV["Source"]);
            //    }
            //    ContractNoauthorized.Rows[0].IsCurrent = true;
            //}
            /*-------------------------------------------------------*/
           DVContract1.RowFilter = "Authorized = 1";
            ContractAuthorized.DataSource = DVContract1;
            //if (DVContract.Count < 1) { return; }
            //foreach (DataRowView DV in DVContract)
            //{
            //    ContractAuthorized.Rows.Add(DV["R"], DV["Agreementnumber"], DV["contractdate"], DV["status"], DV["price"], DV["closingcost"], DV["tax"], DV["companyname"], DV["agreementid"],
            //        DV["CompanyContractID"], DV["Source"]);
            //}
            //ContractAuthorized.Rows[0].IsCurrent = true;
            /*----------------------------------------------------------*/
        }

        private void BtnMove_Click(object sender, EventArgs e)
        { /*---------------------------------------------------------------*/
            if(ContractNoauthorized.Rows.Count < 1) { MessageBox.Show("No Contracts To Authorize", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return; }
            if (CompanyList.Text.Trim() == "") { MessageBox.Show("Please Select Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); CompanyList.Focus(); return; }
            /*-------------------------------------------------------------------------*/
            String SqlQuery = "";
            for(int Record=0; Record <= ContractNoauthorized.RowCount - 1; Record++)
            {
                if (int.Parse(ContractNoauthorized.Rows[Record].Cells["Select"].Value.ToString()) == 1)
                {   if (ContractNoauthorized.Rows[Record].Cells["Company"].Value.ToString() != "")
                    {   /*-------Solicitar confirmacion de clave cuando un contracto ya esta autorizado a otra compañia --*/
                        if (MessageBox.Show("Contract # "+ ContractNoauthorized.Rows[Record].Cells["Contract"].Value.ToString() + " Is Assigned To " + ContractNoauthorized.Rows[Record].Cells["Company"].Value.ToString() + " \n Do You Want To Authorize It To "+CompanyList.Text+" ?", "OWNER",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Authorization aauto = new Authorization();
                            if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                SqlQuery = SqlQuery + " " + "Exec LS_CompanyContract_M 0,0," + ContractNoauthorized.Rows[Record].Cells["Agreementid"].Value.ToString() + "," + CompanyList.SelectedValue + "," + General.Globalvariables.guserid + "";
                            }
                        }
                    }
                    else
                    {
                        SqlQuery = SqlQuery + " " + "Exec LS_CompanyContract_M 0,0," + ContractNoauthorized.Rows[Record].Cells["Agreementid"].Value.ToString() + "," + CompanyList.SelectedValue + "," + General.Globalvariables.guserid + "";
                    }
                }
            }
            //Grdunauthorized.Rows[record].Cells["status"].Value.ToString()
            if(SqlQuery == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                DVAuthorize = SQLCMD.SQLdata(SqlQuery).DefaultView;
            Btnsearch.PerformClick();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
            /*-------------------------------------------------------------------------*/
        }

        private void Btndiscard_Click(object sender, EventArgs e)
        {
            /*---------------------------------------------------------------*/
            if (ContractAuthorized.Rows.Count < 1) { MessageBox.Show("No Contracts To Discard", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*-------------------------------------------------------------------------*/
            String SqlQuery = "";
            for (int Record = 0; Record <= ContractAuthorized.RowCount - 1; Record++)
            {
                if (int.Parse(ContractAuthorized.Rows[Record].Cells["Select"].Value.ToString()) == 1)
                {
                    SqlQuery = SqlQuery + " " + "Exec LS_CompanyContract_M 1,"+ ContractAuthorized.Rows[Record].Cells["CompanyContractID"].Value.ToString() + "," + ContractAuthorized.Rows[Record].Cells["Agreementid"].Value.ToString() + ","+CompanyList.SelectedValue +"," + General.Globalvariables.guserid + "";
                }
            }

            if (SqlQuery == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(MessageBox.Show("Confirm Discard", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                DVAuthorize = SQLCMD.SQLdata(SqlQuery).DefaultView;
                Btnsearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ecx) { MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
            /*-------------------------------------------------------------------------*/
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Checkall1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (ContractNoauthorized.RowCount < 1) { return; }


            for (int record = 0; record <= ContractNoauthorized.Rows.Count - 1; record++)
            {
                ContractNoauthorized.Rows[record].Cells["Select"].Value = 1;
            }

            if (Checkall1.Checked == false)
            {
                for (int record = 0; record <= ContractNoauthorized.Rows.Count - 1; record++)
                {
                    ContractNoauthorized.Rows[record].Cells["Select"].Value = 0;
                }

            }
        }

        private void Checkall2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (ContractAuthorized.RowCount < 1) { return; }


            for (int record = 0; record <= ContractAuthorized.Rows.Count - 1; record++)
            {
                ContractAuthorized.Rows[record].Cells["Select"].Value = 1;
            }

            if (Checkall2.Checked == false)
            {
                for (int record = 0; record <= ContractAuthorized.Rows.Count - 1; record++)
                {
                    ContractAuthorized.Rows[record].Cells["Select"].Value = 0;
                }

            }
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2) { PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2) { Contract1.SelectionStart = 0; Contract1.SelectionLength = Contract1.Text.Length; Contract1.Focus(); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }
        /*=================================================================================================================================================================================*/
    }
}
