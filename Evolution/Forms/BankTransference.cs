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
    public partial class BankTransference : Form
    {
        public BankTransference()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        DataView DV = new DataView();
        DataView DVSave = new DataView();
        string BankTransferenceID = "0",BankID="0";
        private void bSearch_Click(object sender, EventArgs e)
        {
            if (SalesfloorID.Text == "") { MessageBox.Show("Missing Salesfloor", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesfloorID.Focus(); return; }
            if (PropertyID.Text == "") { MessageBox.Show("Missing Property", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); PropertyID.Focus(); return; }
            DVSearch = SQLCMD.SQLdata("LS_MemberServiceFeeSearch_L 1,"+SalesfloorID.Text.Trim()+",'"+PropertyID.Text.Trim()+"'," + MemberAgreementNo.Text.Trim() + "," +
             ((Sequence.Text.Trim() == "") ? "null" : Sequence.Text.Trim()) + "").DefaultView;
            /*-----------------------------------------------------------------------------------------------------*/
            if(DVSearch.Count < 1) { MessageBox.Show("Invalid Contract No.","Owner",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            MemberName.Text = DVSearch.Table.Rows[0]["MemberName"].ToString();
            Address.Text = DVSearch.Table.Rows[0]["Address"].ToString();
            FillGrid();
            /*------------------------------------------------------------------------------------------------------*/
        }

        private void BankTransference_Load(object sender, EventArgs e)
        {
            FillCombo();
            bSearch.PerformClick();
        }

        private void FillCombo()
        {
            DV = SQLCMD.SQLdata("LS_Bank_ML 3").DefaultView;
            if(DV.Count < 1) { return; }
            AutoCompleteStringCollection banklist = new AutoCompleteStringCollection();
            foreach (DataRowView dvv in DV)
            {
                banklist.Add(dvv["bankname"].ToString());
            }
           
            BankName.AutoCompleteCustomSource = banklist;
        }

        private void Btnnew_Click(object sender, EventArgs e)
        {
            MemberName.Text = ""; BankID = "0";
            Address.Text = ""; RoutingCode.Text = "";
            AccountNumber.Text = ""; SwiftCode.Text = "";
            BankName.Text = ""; BankAddress.Text = "";
            MemberName.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BankTransference_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }
        private void FillGrid()
        {
            DV = SQLCMD.SQLdata("LS_BankTransference_ML 3,@AgreementID="+ DVSearch.Table.Rows[0]["AgreementID"].ToString()+"").DefaultView;
            GRD.DataSource = DV;
        }
        private void Btnsave_Click(object sender, EventArgs e)
        {
            if (DVSearch.Count < 1) { MessageBox.Show("Search A Contract No.", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); SalesfloorID.Focus(); return; }
            if (MemberName.Text.Trim()=="") { MessageBox.Show("Missing Beneficiary Name", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); MemberName.Focus(); return; }
            if (Address.Text.Trim() == "") { MessageBox.Show("Missing Beneficiary Address", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); Address.Focus(); return; }
            if (AccountNumber.Text.Trim() == "") { MessageBox.Show("Missing Account Number", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); AccountNumber.Focus(); return; }
            if (BankName.Text.Trim() == "" ) { MessageBox.Show("Invalid Bank", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); BankName.Focus(); return; }
            if (BankAddress.Text.Trim() == "") { MessageBox.Show("Invalid Bank Address", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); BankAddress.Focus(); return; }
            if (SwiftCode.Text.Trim() == "") { MessageBox.Show("Invalid Swift Code", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); SwiftCode.Focus(); return; }
            if (RoutingCode.Text.Trim() == "") { MessageBox.Show("Invalid Routing Code", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); RoutingCode.Focus(); return; }
            /*------------------------------------------------------------------------*/
            try
            {
                DVSave = SQLCMD.SQLdata("LS_BankTransference_ML " + ((BankTransferenceID == "0") ? "0" : "1") + "," + BankTransferenceID + "," + BankID + ",'" + MemberName.Text.Trim().Replace("'", "''") + "','" +
                   AccountNumber.Text.Trim().Replace("'", "''") + "','" + Address.Text.Trim().Replace("'", "''") + "'," + DVSearch.Table.Rows[0]["AgreementID"].ToString() + ",'" +
                  BankName.Text.Trim().Replace("'", "''") + "','" + BankAddress.Text.Trim().Replace("'", "''") + "','" + SwiftCode.Text.Trim().Replace("'", "''") + "','"+RoutingCode.Text.Trim().Replace("'", "''") + "',"+General.Globalvariables.guserid+"").DefaultView;
                /*--------------------------------*/
                FillGrid();
                Btnnew.PerformClick();
                MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            /*-------------------------------------------------------------------------*/
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            if (GRD.RowCount < 1) { MessageBox.Show("No Bank Account In The List", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return; }
            if (MessageBox.Show("Confirm Delete", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No) { return; }
            BankTransferenceID = ((BankTransferenceID=="0")? GRD.CurrentRow.Cells["BankTransferenceID"].Value.ToString() : BankTransferenceID);
            /*------------------------------------------------------------------------*/
            try
            {
                DVSave = SQLCMD.SQLdata("LS_BankTransference_ML 2," + BankTransferenceID + ","+BankID+"").DefaultView;
                /*--------------------------------*/
                FillGrid();
                Btnnew.PerformClick();
                MessageBox.Show("Done", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            /*-------------------------------------------------------------------------*/
        }

        private void GRD_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRD.RowCount < 1) { return; }
            BankTransferenceID = GRD.CurrentRow.Cells["BankTransferenceID"].Value.ToString();
            MemberName.Text = GRD.CurrentRow.Cells["MemberName"].Value.ToString();
            Address.Text = GRD.CurrentRow.Cells["Address"].Value.ToString();
            AccountNumber.Text = GRD.CurrentRow.Cells["AccountNumber"].Value.ToString();
            BankID = GRD.CurrentRow.Cells["BankID"].Value.ToString();
            BankName.Text = GRD.CurrentRow.Cells["BankName"].Value.ToString();
            BankAddress.Text = GRD.CurrentRow.Cells["BankAddress"].Value.ToString();
            SwiftCode.Text = GRD.CurrentRow.Cells["SwiftCode"].Value.ToString();
            RoutingCode.Text = GRD.CurrentRow.Cells["RoutingCode"].Value.ToString();
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2) { PropertyID.SelectionStart = 0; PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2) { MemberAgreementNo.SelectionStart = 0; MemberAgreementNo.SelectionLength = MemberAgreementNo.Text.Length; MemberAgreementNo.Focus(); }
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void MemberAgreementNo_KeyPress(object sender, KeyPressEventArgs e)
        { 
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void GRD_Click(object sender, EventArgs e)
        {

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
