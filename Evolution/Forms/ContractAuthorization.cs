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

namespace Evolution.Forms
{
    public partial class ContractAuthorization : Form
    {
        public ContractAuthorization()
        {
            InitializeComponent();
        }
        DataView contractview = new DataView();
        DataView contractview1 = new DataView();
        DataView dvdicard = new DataView();
       
        General.Sqlcommandexecuter SQLcmd = new General.Sqlcommandexecuter();
        private void Btnsearch_Click(object sender, EventArgs e)
        {
            /*===============Seatch contract=================================*/
            if (SalesfloorID.Text.Trim() == "" & PropertyID.Text.Trim() == "" & Contract1.Text.Trim() == "" & Contract2.Text.Trim() == "")
            {   if (MessageBox.Show("Search All Contracts ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                 { SalesfloorID.Focus(); return;
                 }
            }
            Wait wwt = new Wait();
            try
            { wwt.Show(); wwt.Refresh();
                contractview = SQLcmd.SQLdata("LS_OWNERSHIPCONTRACT_L2 0," + ((SalesfloorID.Text.Trim() == "") ? "null" : SalesfloorID.Text) + "," +
                    ((PropertyID.Text.Trim() == "")? "null" : PropertyID.Text) + ",'" + Contractdate1.Text + "','" + Contractdate2.Text + "'," +
                   ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text) + "," +
                   ((Contract2.Text.Trim() == "") ? "99999999999" : Contract2.Text) + "").DefaultView;
                if (contractview.Count < 1) { MessageBox.Show("No Record Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);  return; }
                /*-------------------------------------*/
                DataTable dt = new DataTable();
                dt = contractview.Table;
                contractview1 = new DataView(dt);
                /*-------------------------------------*/
                contractview.RowFilter = "OSC_STATUS =0";
                fillGrid1(contractview);
                fillGrid2(contractview1);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"OWNER"); }
            finally { wwt.Close(); }
            /*--------------------------------------------------------------------------------*/
        }
        private void fillGrid1(DataView DV)
        {
            Grdunauthorized.DataSource = DV;
        }
        
        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
        private void All_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            contractview.RowFilter = "OSC_STATUS <> 1";
            fillGrid1(contractview);
        }

        private void Pending_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            contractview.RowFilter = "OSC_STATUS = 0";
            fillGrid1(contractview);
        }

        private void Discarded_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            contractview.RowFilter = "OSC_STATUS = -1";
            fillGrid1(contractview);
        }

        private void BtnMove_Click(object sender, EventArgs e)
        { if(Grdunauthorized.RowCount < 1) { MessageBox.Show("Not Record to Authorize"); return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                string SQLstrn = "", selected = "";
                /*--------------------------------------------------------------------------*/
                if (Contract1.Text == "") { Contract1.Text = "0"; }
                if (Contract2.Text == "") { Contract2.Text = "0"; }
                /*--------------------------------------------------------------------------*/
                for (int record = 0; record <= Grdunauthorized.RowCount - 1; record++)
                {
                    selected = Grdunauthorized.Rows[record].Cells["select"].Value.ToString();
                    if (selected == "true" || selected == "1")
                    {
                        //int row = Grdunauthorized.CurrentRow.Index;
                        SQLstrn = SQLstrn + " " + "EXEC LS_OWNERSHIPCONTRACT_M2 " + Grdunauthorized.Rows[record].Cells["status"].Value.ToString() + ", " + Grdunauthorized.Rows[record].Cells["agreementid"].Value.ToString() + "," + General.Globalvariables.guserid + "," +
                          ((SalesfloorID.Text =="")? "null" : SalesfloorID.Text) + "," + ((PropertyID.Text=="")? "null": PropertyID.Text) + ",'" + Contractdate1.Text + "','" + Contractdate2.Text + "'," + Contract1.Text + "," + Contract2.Text + " ";
                        // Grdunauthorized.Rows.RemoveAt(row);

                    }
                }
                if (SQLstrn == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }/*Si no hay fila cotejada*/
                contractview = SQLcmd.SQLdata(SQLstrn).DefaultView;
                Btnsearch.PerformClick();
            }catch(Exception ecx) { MessageBox.Show(ecx.Message,"OWNER"); }
            finally { wwt.Close(); }
            //MessageBox.Show(SQLstrn); //el codigo en coment funciona


        }
        private void fillGrid2(DataView DV)
        {
            DV.RowFilter = string.Format("OSC_STATUS=1");
            Grdauthorized.DataSource = DV;
        }

        private void Btndiscard_Click(object sender, EventArgs e)
        {
        }

        private void Checkall2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if(SalesfloorID.TextLength >= 2) { PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >=2) { Contract1.Focus(); }
        }

        private void Checkall1_ToggleStateChanged_1(object sender, StateChangedEventArgs args)
        {
           
        }

        private void ContractAuthorization_Load(object sender, EventArgs e)
        {
            
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void PropertyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Contract2_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void SalesfloorID_TextChanged_1(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Length >= 2) { PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged_1(object sender, EventArgs e)
        {
            if (PropertyID.Text.Length>=2) { Contract1.Focus(); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }

        private void SalesfloorID_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero (e);
        }

        private void PropertyID_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Contract1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Contract2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void ContractAuthorization_Load_1(object sender, EventArgs e)
        {
            General.GlobalAccess permiso = new General.GlobalAccess();
                permiso.groubox(radGroupBox3);
        }

        private void Btndiscard_Click_1(object sender, EventArgs e)
        {

            if (Grdauthorized.RowCount < 1) { MessageBox.Show("There is not Record to Dicard"); return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                string SQLstrn = "", selected = "";

                /*--------------------------------------------------------------------------*/
                if (Contract1.Text == "") { Contract1.Text = "0"; }
                if (Contract2.Text == "") { Contract2.Text = "0"; }
                /*--------------------------------------------------------------------------*/

                for (int record = 0; record <= Grdauthorized.RowCount - 1; record++)
                {
                    selected = Grdauthorized.Rows[record].Cells["select"].Value.ToString();

                    if (selected == "true" || selected == "1")
                    {
                        SQLstrn = SQLstrn + " " + "EXEC LS_OWNERSHIPCONTRACT_M2 " + Grdauthorized.Rows[record].Cells["status"].Value.ToString() + ", " + Grdauthorized.Rows[record].Cells["agreementid"].Value.ToString() + "," + General.Globalvariables.guserid + "," +
                           ((SalesfloorID.Text =="")? "null" : SalesfloorID.Text) + "," + ((PropertyID.Text =="")? "null" : PropertyID.Text) + ",'" + Contractdate1.Text + "','" + Contractdate2.Text + "'," + Contract1.Text + "," + Contract2.Text + " ";
                    }
                }
                if (SQLstrn == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Confirm Discard", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) { return; }
                contractview = SQLcmd.SQLdata(SQLstrn).DefaultView;
              
                Btnsearch.PerformClick();
                
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"OWNER"); }
            finally { wwt.Close(); }
        }

        private void Btnclear_Click_1(object sender, EventArgs e)
        {
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = "";
            Contract2.Text = "";
            Contractdate1.Text = DateTime.Now.ToShortTimeString(); //SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortTimeString();
            SalesfloorID.Focus();
        }

        private void ContractAuthorization_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            Btnclear.PerformClick();
        }

        private void Checkall1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (Grdunauthorized.RowCount < 1) { return; }


            for (int record = 0; record <= Grdunauthorized.Rows.Count - 1; record++)
            {
                Grdunauthorized.Rows[record].Cells["Select"].Value = 1;
            }

            if (Checkall1.Checked == false)
            {
                for (int record = 0; record <= Grdunauthorized.Rows.Count - 1; record++)
                {
                    Grdunauthorized.Rows[record].Cells["Select"].Value = 0;
                }

            }
        }

        private void Checkall2_ToggleStateChanged_1(object sender, StateChangedEventArgs args)
        {
            if (Grdauthorized.RowCount < 1) { return; }


            for (int record = 0; record <= Grdauthorized.Rows.Count - 1; record++)
            {
                Grdauthorized.Rows[record].Cells["Select"].Value = 1;
            }

            if (Checkall2.Checked == false)
            {
                for (int record = 0; record <= Grdauthorized.Rows.Count - 1; record++)
                {
                    Grdauthorized.Rows[record].Cells["Select"].Value = 0;
                }

            }
        }



        /*=========================================================================================================================================*/
    }
}
