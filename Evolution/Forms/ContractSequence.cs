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
    public partial class ContractSequence : Form
    {
        public ContractSequence()
        {
            InitializeComponent();
        }
        /*---------------Variables e instancia de clase-------------------------------------*/
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView contractView = new DataView();
        private int agreementid;
        public string action = "0", AN = "0";
        /*---------------------------------------------------------------*/
        private void radTextBox2_TextChanged(object sender, EventArgs e)
        { 
            if (Boughtweek.TextLength > 0) { BtnSavechange.Enabled = true; }else { BtnSavechange.Enabled = false; }
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            if (Salesfloorid.Text.Trim()=="" & Propertyid.Text.Trim()=="" & Agreementnumber.Text.Trim()=="" & Agreementnumber1.Text.Trim()=="" & action == "0")
            {
                if (MessageBox.Show("Do You Want To Search All Contracts ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                contractView = SQLCMD.SQLdata($"OWNERSHIPCONTRACTTRX_L2 {((Salesfloorid.Text.Trim() == "")? "null" : Salesfloorid.Text.Trim())}," +
                    $"{ ((Propertyid.Text.Trim() == "")? "null" : Propertyid.Text.Trim()) },{ ((Agreementnumber.Text.Trim() == "")? "null" : Agreementnumber.Text.Trim()) }," +
                    $"{ ((Agreementnumber1.Text.Trim() == "")? "null" : Agreementnumber1.Text.Trim()) }, '{ AN }'").DefaultView;
                /*---------------------------------------------------------------*/
                GRDCONTRACT.DataSource = contractView;
                if (contractView.Count < 1)
                {
                    MessageBox.Show("No Record Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cotejar_upgrade_exit();
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }
       
        private void cotejar_upgrade_exit()
        {
            if (GRDCONTRACT.Rows.Count < 1) { return; }
            string check = "";
            for (int record=0; record<= GRDCONTRACT.RowCount -1; record++)
            {/*---------------------------------------------------------------------*/
                check = GRDCONTRACT.CurrentRow.Cells["upgrade"].Value.ToString();
                if(check != "0")
                {
                    GRDCONTRACT.CurrentRow.Cells["upgrade"].Value = 1;
                }
                else { GRDCONTRACT.CurrentRow.Cells["upgrade"].Value = 0; }
                /*---------------------------------------------------------------------*/
                check = GRDCONTRACT.CurrentRow.Cells["exit"].Value.ToString();
                if (check == "2")
                {
                    GRDCONTRACT.CurrentRow.Cells["exit"].Value = 1;
                }
                else { GRDCONTRACT.CurrentRow.Cells["exit"].Value = 0; }
                /*---------------------------------------------------------------------*/
                FillCampos();
            }
        }
        private void FillCampos()
        {
            if (GRDCONTRACT.Rows.Count < 1) { return; }
            /*----------------------------------------------------------------------*/
            Currentcontract.Text = GRDCONTRACT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            Boughtweek1.SelectedIndex = ((int.Parse(GRDCONTRACT.CurrentRow.Cells["exit"].Value.ToString()) == 0)? 0 : 1);

            Membership.Text = decimal.Parse(GRDCONTRACT.CurrentRow.Cells["distmembership1"].Value.ToString()).ToString("#,##0.00");
            Closingcost.Text = decimal.Parse(GRDCONTRACT.CurrentRow.Cells["distclosingcost1"].Value.ToString()).ToString("#,##0.00");
            Tax.Text = decimal.Parse(GRDCONTRACT.CurrentRow.Cells["disttax1"].Value.ToString()).ToString("#,##0.00");
            Dist_membership.Text = decimal.Parse(GRDCONTRACT.CurrentRow.Cells["distmembership"].Value.ToString()).ToString("#,##0.00");
            Dist_closingcost.Text = decimal.Parse(GRDCONTRACT.CurrentRow.Cells["distclosingcost"].Value.ToString()).ToString("#,##0.00");
            Dist_tax.Text = decimal.Parse(GRDCONTRACT.CurrentRow.Cells["disttax"].Value.ToString()).ToString("#,##0.00");
            AR.Text = decimal.Parse(GRDCONTRACT.CurrentRow.Cells["AR"].Value.ToString()).ToString("#,##0.00");
            /*--------------------------------------------------------------------------*/
            if (GRDCONTRACT.CurrentRow.Cells["exit"].Value.ToString() == "0")
            { Contracttype.Text = "UNLIMITED"; }
            else
            { Contracttype.Text = "EXIT"; }
            /*--------------------------------------------------------------------------*/
            if (GRDCONTRACT.CurrentRow.Cells["upgrade"].Value.ToString() == "0")
            { Upgrade.Checked = false; 
            }
            else
            { Upgrade.Checked = true; 
            }
            /*------------------------------------------------------------------------*/
        }
        private void ContractSequence_Load(object sender, EventArgs e)
        {
            General.GlobalAccess permiso = new General.GlobalAccess();
            permiso.groubox(radGroupBox3);
            permiso.groubox(radGroupBox4);
            permiso.groubox(radGroupBox5);

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
          

        }

        private void Changecontract_TextChanged(object sender, EventArgs e)
        {
            if(Changecontract.TextLength >= 3) { BtnSaveContractChange.Enabled = true; }
            else { BtnSaveContractChange.Enabled = false; }
        }

        private void GRDCONTRACT_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            FillCampos();
        }

        private void Upgrade_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            FillCampos();
        }

        private void Upgrade_Click(object sender, EventArgs e)
        {
            if (GRDCONTRACT.Rows.Count < 1) { MessageBox.Show("Please Search a Contract", "OWNER");
                if (Upgrade.Checked == true) { Upgrade.Checked = false; } else { Upgrade.Checked = true; }
                Agreementnumber.Focus(); return; }
            int preveusagreementid; /*record;*/
            if (MessageBox.Show("Please Confirm", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                agreementid = int.Parse(GRDCONTRACT.CurrentRow.Cells["agreementid"].Value.ToString());
                if (int.Parse(GRDCONTRACT.CurrentRow.Cells["upgrade"].Value.ToString()) == 0)
                { preveusagreementid = 1; 
                }
                else 
                { preveusagreementid = 0; 
                }

                SQLCMD.SQLdata("LS_CHANGEPREVEUSAGREEMENTID_M " + agreementid + "," + preveusagreementid + "");
                Btnsearch.PerformClick();
            }
            else
            {
                if(Upgrade.Checked == true) { Upgrade.Checked = false; } else { Upgrade.Checked = true; }
            }

        }

        private void BtnSavechange_Click(object sender, EventArgs e)
        {
            if (GRDCONTRACT.Rows.Count < 1){ MessageBox.Show("Please Search a Contract", "OWNER"); Salesfloorid.Focus(); return; }
            if (Boughtweek1.Text.Trim() == "") { MessageBox.Show("Please Type a Valid Number", "OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Please Confirm", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int week = ((Boughtweek1.SelectedIndex == 0 )? 99 : 98);
                agreementid = int.Parse(GRDCONTRACT.CurrentRow.Cells["agreementid"].Value.ToString());
                SQLCMD.SQLdata("LS_X_UPDATE_CONTRACT_WEEKS2 " + agreementid + "," + week + "");
                Btnsearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSaveContractChange_Click(object sender, EventArgs e)
        {
            if (GRDCONTRACT.Rows.Count < 1) { MessageBox.Show("Please Search a Contract", "OWNER"); Agreementnumber.Focus(); return; }
            if (Changecontract.Text.Trim() == "") { MessageBox.Show("Please Type a Valid Contract Number", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Please Confirm", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                agreementid = int.Parse(GRDCONTRACT.CurrentRow.Cells["agreementid"].Value.ToString());
                int propertyid = int.Parse(GRDCONTRACT.CurrentRow.Cells["propertyid"].Value.ToString());
                SQLCMD.SQLdata("LS_X_UPDATE_CONTRACT_NUMBER2 " + agreementid + ",'" + Changecontract.Text + "',0,0,0,0,0," + General.Globalvariables.guserid + "," + propertyid + "");
                Btnsearch.PerformClick();
                Changecontract.Text = "";
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Boughtweek_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ContractSequence_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            if (action == "0") { Salesfloorid.Focus();  }
            else
            {
                Btnsearch.PerformClick();
            }
        }

        private void GRDCONTRACT_Click(object sender, EventArgs e)
        {

        }

        private void Membership_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Closingcost_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Tax_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Dist_membership_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Dist_closingcost_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Dist_tax_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void bclear_Click(object sender, EventArgs e)
        {
            Salesfloorid.Text = "";
            Propertyid.Text = "";
            Agreementnumber.Text = "";
            Agreementnumber1.Text = "";
            Salesfloorid.Focus();
        }

        private void Salesfloorid_TextChanged(object sender, EventArgs e)
        {
            if (Salesfloorid.Text.Trim().Length>=2) { Propertyid.Focus(); }
        }

        private void Propertyid_TextChanged(object sender, EventArgs e)
        {
            if (Propertyid.Text.Trim().Length>=2) { Agreementnumber.Focus(); }
        }

        private void Agreementnumber_TextChanged(object sender, EventArgs e)
        {
            Agreementnumber1.Text = Agreementnumber.Text;
        }

        private void Salesfloorid_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox valida = new General.ValidarTexbox();
            valida.Solonumerosentero(e);
        }

        private void Propertyid_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox valida = new General.ValidarTexbox();
            valida.Solonumerosentero(e);
        }

        private void Agreementnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox valida = new General.ValidarTexbox();
            valida.Solonumerosentero(e);
        }

        private void Agreementnumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox valida = new General.ValidarTexbox();
            valida.Solonumerosentero(e);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if (GRDCONTRACT.Rows.Count < 1) { MessageBox.Show("Please Search a Contract", "OWNER"); Agreementnumber.Focus(); return; }

            if (MessageBox.Show("Please Confirm", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {   /*-----------------------------------------------------------------------------------*/
                if (Membership.Text.Trim() == "") { Membership.Text = "0"; }
                if (Closingcost.Text.Trim() == "") { Closingcost.Text = "0"; }
                if (Tax.Text.Trim() == "") { Tax.Text = "0"; }
                if (Dist_membership.Text.Trim() == "") { Dist_membership.Text = "0"; }
                if (Dist_closingcost.Text.Trim() == "") { Dist_closingcost.Text = "0"; }
                if (Dist_tax.Text.Trim() == "") { Dist_tax.Text = "0"; }
                if (AR.Text.Trim() == "") { AR.Text = "0"; }

                /*-----------------------------------------------------------------------------------*/
                agreementid = int.Parse(GRDCONTRACT.CurrentRow.Cells["agreementid"].Value.ToString());

                SQLCMD.SQLdata("LS_OwnershipContractTRX_M2 " + agreementid + "," + decimal.Parse(Membership.Text) + "," + decimal.Parse(Tax.Text) + "," + decimal.Parse(Closingcost.Text) + "," + General.Globalvariables.guserid + "," + decimal.Parse(Dist_membership.Text) + ","
                    + decimal.Parse(Dist_tax.Text) + "," + decimal.Parse(Dist_closingcost.Text) + "," + decimal.Parse(AR.Text) + ",'" + Currentcontract.Text + "'");
                 Btnsearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Dist_membership_TextChanged(object sender, EventArgs e)
        {

        }

        private void AR_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }
        /*==============================================================================================================================================*/
    }
}
