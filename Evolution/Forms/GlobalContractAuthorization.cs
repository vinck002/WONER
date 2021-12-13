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
    public partial class GlobalContractAuthorization : Form
    {
        public GlobalContractAuthorization()
        {
            InitializeComponent();
        }
        DataView DVCompany = new DataView();
        DataView DVContract = new DataView();
        DataView DVContract1 = new DataView();
        DataView DVAuthorize = new DataView();
        DataView DVSave = new DataView();
        DataView DVInfo = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void OwnerAuthorize_Click(object sender, EventArgs e)
        {
            CompanyList.Visible = false;
            SalesFloorID2.Visible = false;
            PropertyID2.Visible = false;
            MemberAgreementNo.Visible = false;
            Sequence.Visible = false;
            bProcess.Visible = true;
            ContractAuthorized.DataSource = DVAuthorize; ContractNoauthorized.DataSource = DVAuthorize;
            radLabel1.Visible = false; RequestDate.Visible = false;
        }

        private void ThirdAuthorize_Click(object sender, EventArgs e)
        {
            CompanyList.Visible = true;
            CompanyList.Location = new Point(SalesFloorID2.Location.X, SalesFloorID2.Location.Y);
            SalesFloorID2.Visible = false;
            PropertyID2.Visible = false;
            MemberAgreementNo.Visible = false; bProcess.Visible = false;
            Sequence.Visible = false;
            ContractAuthorized.DataSource = DVAuthorize; ContractNoauthorized.DataSource = DVAuthorize;
            radLabel1.Visible = false; RequestDate.Visible = false;
        }

        private void MemberAuthorize_Click(object sender, EventArgs e)
        {
            CompanyList.Visible = false;
            SalesFloorID2.Visible = true;
            PropertyID2.Visible = true;
            MemberAgreementNo.Visible = true;
            Sequence.Visible = true;
            bProcess.Visible = false;
            ContractAuthorized.DataSource = DVAuthorize; ContractNoauthorized.DataSource = DVAuthorize;
            radLabel1.Visible = true; RequestDate.Visible = true;
        }

        private void GlobalContractAuthorization_Load(object sender, EventArgs e)
        {
            /*----------------------------------------------*/
            SourceList.DataSource = SQLCMD.SQLdata("dts.dbo.sp_l_source '6','6',''").DefaultView;
            SourceList.DisplayMember = "Name";
            SourceList.ValueMember = "Id";
            /*---------------------------*/
            DVCompany = SQLCMD.SQLdata("LS_CompanyPercent_L 1").DefaultView;
            CompanyList.DataSource = DVCompany;
            CompanyList.DisplayMember = "Companyname";
            CompanyList.ValueMember = "CompanyPercentID";
            /*-----------------------------*/
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            Contractdate1.SetToNullValue();
            RequestDate.SetToNullValue();
            /*---------------------------------------*/
            SourceList.Text = "";
            /*----------------------------------*/
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = "";
            Contract2.Text = "";
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            CompanyList.Text = ""; MemberAgreementNo.Text = "";
            OwnerAuthorize.PerformClick();
            RequestDate.SetToNullValue();
            SalesFloorID2.Text = "";
            PropertyID2.Text = "";
            Sequence.Text = ""; bProcess.Checked = false;
            MemberAgreementNo.Text = ""; SourceList.Text = "";
            SalesfloorID.Focus();
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            /*---------------------------------------------------------------------------------------------*/
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                Checkall1.CheckState = CheckState.Unchecked;
                Checkall2.CheckState = CheckState.Unchecked;
                if (ThirdAuthorize.CheckState == CheckState.Checked) { SearchThirdContracts(); }
                if(OwnerAuthorize.CheckState == CheckState.Checked) { SearchOwnerContract(); }
                if(MemberAuthorize.CheckState == CheckState.Checked) { SearchMemberContract(); }

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message); }
            finally { wwt.Close(); }
            /*---------------------------------------------------------------------------------------------*/
        }
        private void SearchThirdContracts()
        {
            if (SourceList.SelectedValue != null) { goto PROXIMO; }
            if (SalesfloorID.Text.Trim() == "" && PropertyID.Text.Trim() == "" && Contract1.Text.Trim() == "" && Contract2.Text.Trim() == "")
            { MessageBox.Show("Missing Field SalesFloor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesfloorID.Focus(); return; }
            PROXIMO:;
            if (CompanyList.Text.Trim() == "") { MessageBox.Show("Please Select Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); CompanyList.Focus(); return; }
            /*---------------------------------------------------------------------------------------------*/
            
            DVContract = SQLCMD.SQLdata("LS_CompanyContractSearch_L " + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text.Trim()) + "," + ((PropertyID.Text.Trim() == "") ? "null" : "'" + PropertyID.Text + "'") + ",'" +
             ((Contractdate1.Text.Trim() == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "'," +
             ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," + ((Contract2.Text.Trim() == "") ? "999999999" : Contract2.Text) + "," +
             ((CompanyList.Text.Trim() == "") ? "null" : CompanyList.SelectedValue) + ","+
             ((SourceList.Text == "" || SourceList.SelectedValue == null) ? "null" : SourceList.SelectedValue.ToString()) + "").DefaultView;
            /*---------------------------------------------------------------------------------------------*/
            DataTable dt = new DataTable();
            dt = DVContract.Table;
            DVContract1 = new DataView(dt);
            /*-------------------------------------------------------*/
            DVContract.RowFilter = "Authorized = 0";
            ContractNoauthorized.DataSource = DVContract;
            DVContract1.RowFilter = "Authorized = 1";
            ContractAuthorized.DataSource = DVContract1;
        }
        private void SearchOwnerContract()
        {
            /*===============Seatch contract=================================*/
            if(bProcess.Checked == true || SourceList.SelectedValue != null) { goto PROXIMO; }
            if (SalesfloorID.Text.Trim() == "" && PropertyID.Text.Trim() == "" && Contract1.Text.Trim() == "" && Contract2.Text.Trim() == "")
            { MessageBox.Show("Missing SalesFloor","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return;}
            PROXIMO:;
                DVContract = SQLCMD.SQLdata("LS_OWNERSHIPCONTRACT_L2 0," + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text) + "," +
                    ((PropertyID.Text.Trim() == "") ? "null" : "'"+PropertyID.Text +"'") + ",'" + Contractdate1.Text + "','" + Contractdate2.Text + "'," +
                   ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," +((Contract2.Text.Trim() == "") ? "99999999999" : Contract2.Text) + ","+
                   ((bProcess.Checked == false)? "null" : "1") +","+((SourceList.Text=="" || SourceList.SelectedValue ==null)? "null" : SourceList.SelectedValue.ToString())+"").DefaultView;
              //  if (DVContract.Count < 1) { MessageBox.Show("No Record Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                /*-------------------------------------*/
                DataTable dt = new DataTable();
                dt = DVContract.Table;
            DVContract1 = new DataView(dt);
            /*-------------------------------------*/
            DVContract.RowFilter = "OSC_STATUS =0";
            ContractNoauthorized.DataSource = DVContract;
            DVContract1.RowFilter = string.Format("OSC_STATUS=1");
            ContractAuthorized.DataSource = DVContract1;

            /*--------------------------------------------------------------------------------*/
        }
        private void SearchMemberContract()
        {
            if (SourceList.SelectedValue != null) { goto PROXIMO; }
            if (SalesfloorID.Text.Trim() == "" && PropertyID.Text.Trim() == "" && Contract1.Text.Trim() == "" && Contract2.Text.Trim() == "")
            { MessageBox.Show("Missing Field SalesFloor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesfloorID.Focus(); return; }
            PROXIMO:;
            if (SalesFloorID2.Text.Trim() == "") { MessageBox.Show("Missing Member SalesFloor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesFloorID2.Focus(); return; }
            if (PropertyID2.Text.Trim() == "") { MessageBox.Show("Missing Member Property", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); PropertyID2.Focus(); return; }
            if (MemberAgreementNo.Text.Trim() == "") { MessageBox.Show("Missing Member Agreement Number", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); MemberAgreementNo.Focus(); return; }
            /*---------------------------------------------------------------------------------------------*/
            string MemberContractNo = "";
            MemberContractNo = SalesFloorID2.Text.Trim() + "-" + PropertyID2.Text.Trim() + "-" + MemberAgreementNo.Text.Trim() + ((Sequence.Text.Trim() == "" || int.Parse(Sequence.Text) <= 0) ? "" : "-" + Sequence.Text.Trim());
            /*-------------------------------------------------------------------------------------------------------------*/
            DVContract = SQLCMD.SQLdata("LS_MemberContractSearch_L " + ((SalesfloorID.Text.Trim()=="")?"null" : SalesfloorID.Text.Trim()) + "," + ((PropertyID.Text.Trim() == "") ? "null" : "'" + PropertyID.Text + "'") + ",'" +
             ((Contractdate1.Text.Trim() == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "'," +
             ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," + ((Contract2.Text.Trim() == "") ? "999999999" : Contract2.Text) + ",'" +
             MemberContractNo + "',"+ ((SourceList.Text == "" || SourceList.SelectedValue == null) ? "null" : SourceList.SelectedValue.ToString()) + "").DefaultView;
            /*---------------------------------------------------------------------------------------------*/
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt1 = DVContract.Table;
            dt = DVContract.Table;
            DVInfo = new DataView(dt1);
            DVContract1 = new DataView(dt);
            /*-------------------------------------------------------*/
            DVContract.RowFilter = "Authorized = 0";
            ContractNoauthorized.DataSource = DVContract;
            DVContract1.RowFilter = "Authorized = 1";
            ContractAuthorized.DataSource = DVContract1;
            /*-----------------------------------------*/
            DVInfo.RowFilter = "Authorized = -1";
            if(DVInfo.Count < 1) { return; }
            string Info = "";
            foreach (DataRowView dv in DVInfo)
            {
                Info = Info + " " + dv["Agreementnumber"] + " Is Assigned To " + dv["MemberContractNo"] + "\n";
            }
            MessageBox.Show(Info,"Owner",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            /*----------------------------------------*/

        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            if (ContractNoauthorized.RowCount < 1) { return; }
            if (ThirdAuthorize.CheckState == CheckState.Checked) { SaveThirdContract(); }
            if (OwnerAuthorize.CheckState == CheckState.Checked) { SaveOwnerContract(); }
            if (MemberAuthorize.CheckState == CheckState.Checked) { SaveMemberContract(); }
        }

        private void Btndiscard_Click(object sender, EventArgs e)
        {
            if (ContractAuthorized.RowCount < 1) { return; }
            if (ThirdAuthorize.CheckState == CheckState.Checked) { DiscardThirdContract(); }
            if (OwnerAuthorize.CheckState == CheckState.Checked) { DiscardOwnerContract(); }
            if (MemberAuthorize.CheckState == CheckState.Checked) { DiscardMemberContract(); }
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GlobalContractAuthorization_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void Checkall1_Click(object sender, EventArgs e)
        {
            if (ContractNoauthorized.RowCount < 1) { return; }

            for (int record = 0; record <= ContractNoauthorized.Rows.Count - 1; record++)
            {
                ContractNoauthorized.Rows[record].Cells["Select"].Value = 1;
            }

            if (Checkall1.Checked == true)
            {
                for (int record = 0; record <= ContractNoauthorized.Rows.Count - 1; record++)
                {
                    ContractNoauthorized.Rows[record].Cells["Select"].Value = 0;
                }
            }
        }

        private void Checkall2_Click(object sender, EventArgs e)
        {
            if (ContractAuthorized.RowCount < 1) { return; }

            for (int record = 0; record <= ContractAuthorized.Rows.Count - 1; record++)
            {
                ContractAuthorized.Rows[record].Cells["Select"].Value = 1;
            }

            if (Checkall2.Checked == true)
            {
                for (int record = 0; record <= ContractAuthorized.Rows.Count - 1; record++)
                {
                    ContractAuthorized.Rows[record].Cells["Select"].Value = 0;
                }
            }
        }
        private void SaveOwnerContract()
        {
            StringBuilder SQLstrn = new StringBuilder();
            string selected = "";
            /*--------------------------------------------------------------------------*/
            for (int record = 0; record <= ContractNoauthorized.RowCount - 1; record++)
            {
                selected = ContractNoauthorized.Rows[record].Cells["select"].Value.ToString();
                if (selected == "true" || selected == "1")
                {
                    SQLstrn.Append("EXEC LS_OWNERSHIPCONTRACT_M2 " + ContractNoauthorized.Rows[record].Cells["status"].Value.ToString() + ", " + 
                        ContractNoauthorized.Rows[record].Cells["agreementid"].Value.ToString() + "," + General.Globalvariables.guserid + ", null,null,null,null,null,null" + " ");

                }
            }
            if (SQLstrn.ToString() == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }/*Si no hay fila cotejada*/
            DVSave = SQLCMD.SQLdata(SQLstrn.ToString()).DefaultView;
            Btnsearch.PerformClick();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SaveThirdContract()
        {
            if (CompanyList.Text.Trim() == "") { MessageBox.Show("Please Select Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); CompanyList.Focus(); return; }
            /*-------------------------------------------------------------------------*/
            StringBuilder SqlQuery = new StringBuilder();
            bool Validate = false;
            for (int Record = 0; Record <= ContractNoauthorized.RowCount - 1; Record++)
            {
                if (int.Parse(ContractNoauthorized.Rows[Record].Cells["Select"].Value.ToString()) == 1)
                {
                    if (Validate == false)
                    {
                        if (ContractNoauthorized.Rows[Record].Cells["Company"].Value.ToString() != "")
                        {   /*-------Solicitar confirmacion de clave cuando un contracto ya esta autorizado a otra compañia --*/
                            if (MessageBox.Show("Contract # " + ContractNoauthorized.Rows[Record].Cells["Contract"].Value.ToString() + " Is Assigned To " + ContractNoauthorized.Rows[Record].Cells["Company"].Value.ToString() + " \n Do You Want To Authorize It To " + CompanyList.Text + " ?", "OWNER",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Authorization aauto = new Authorization();
                                if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    Validate = true;
                                    SqlQuery.Append("Exec LS_CompanyContract_M 0,0," + ContractNoauthorized.Rows[Record].Cells["Agreementid"].Value.ToString() + "," + CompanyList.SelectedValue + "," + General.Globalvariables.guserid + "" + " ");
                                }
                            }
                        }
                        else
                        {
                            SqlQuery.Append("Exec LS_CompanyContract_M 0,0," + ContractNoauthorized.Rows[Record].Cells["Agreementid"].Value.ToString() + "," + CompanyList.SelectedValue + "," + General.Globalvariables.guserid + "" + " ");
                        }
                    }
                    else
                    {
                        SqlQuery.Append("Exec LS_CompanyContract_M 0,0," + ContractNoauthorized.Rows[Record].Cells["Agreementid"].Value.ToString() + "," + CompanyList.SelectedValue + "," + General.Globalvariables.guserid + "" + " ");
                    }
                }
            }
            if (SqlQuery.ToString() == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                DVSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
                Btnsearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SaveMemberContract()
        {
            if(RequestDate.Text == "") { MessageBox.Show("Missing Request Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); RequestDate.Focus(); return; }
            StringBuilder SqlQuery = new StringBuilder();
            
            for (int Record = 0; Record <= ContractNoauthorized.RowCount - 1; Record++)
            {
                if (int.Parse(ContractNoauthorized.Rows[Record].Cells["Select"].Value.ToString()) == 1)
                {
                   SqlQuery.Append("Exec LS_CompanyContract_M 0,0," + ContractNoauthorized.Rows[Record].Cells["Agreementid"].Value.ToString() + "," + ContractNoauthorized.Rows[Record].Cells["CompanyPercentID"].Value.ToString() + "," +
                       General.Globalvariables.guserid + ","+ ContractNoauthorized.Rows[Record].Cells["MemberAgreementID"].Value.ToString()+",'"+
                       RequestDate.Text + "'" + " ");
                    
                }
            }
            if (SqlQuery.ToString() == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            DVSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
            Btnsearch.PerformClick();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DiscardOwnerContract()
        {
            string   selected = "";
            StringBuilder SQLstrn = new StringBuilder();
            /*--------------------------------------------------------------------------*/
            for (int record = 0; record <= ContractAuthorized.RowCount - 1; record++)
            {
                selected = ContractAuthorized.Rows[record].Cells["select"].Value.ToString();

                if (selected == "true" || selected == "1")
                {
                    SQLstrn.Append("EXEC LS_OWNERSHIPCONTRACT_M2 " + ContractAuthorized.Rows[record].Cells["status"].Value.ToString() + ", " + ContractAuthorized.Rows[record].Cells["agreementid"].Value.ToString() + "," +
                        General.Globalvariables.guserid + ",null,null,null,null,null,null " + " ");
                }
            }
            if (SQLstrn.ToString() == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Confirm Discard", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            DVSave = SQLCMD.SQLdata(SQLstrn.ToString()).DefaultView;
            Btnsearch.PerformClick();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DiscardThirdContract()
        {
            StringBuilder SqlQuery = new StringBuilder();
            for (int Record = 0; Record <= ContractAuthorized.RowCount - 1; Record++)
            {
                if (int.Parse(ContractAuthorized.Rows[Record].Cells["Select"].Value.ToString()) == 1)
                {
                    SqlQuery.Append("Exec LS_CompanyContract_M 1," + ContractAuthorized.Rows[Record].Cells["CompanyContractID"].Value.ToString() + "," + ContractAuthorized.Rows[Record].Cells["Agreementid"].Value.ToString() + "," +
                        ContractAuthorized.Rows[Record].Cells["CompanyPercentID"].Value.ToString() + "," + General.Globalvariables.guserid + ""+" ");
                }
            }
            if (SqlQuery.ToString() == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Confirm Discard", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DVSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
                Btnsearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DiscardMemberContract()
        {
            DiscardThirdContract();
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if(SalesfloorID.Text.Trim().Length >= 2)
            {
                PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus();
            }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.Text.Trim().Length >= 2)
            {
                Contract1.SelectionStart = 0; Contract1.SelectionLength = Contract1.Text.Length; Contract1.Focus();
            }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text.Trim();
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                Contract2.SelectionStart = 0; Contract2.SelectionLength = Contract2.Text.Length; Contract2.Focus();
            }
        }
        /*===========================================================================================================================================================================================*/
    }
}
