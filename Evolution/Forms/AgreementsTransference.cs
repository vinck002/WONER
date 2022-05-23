using Evolution.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms
{
    public partial class AgreementsTransference : Form
    {
        public AgreementsTransference()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView contractview = new DataView();
        DataView contracttransfer = new DataView();
        DataView salesfloors = new DataView();
        DataView propertys = new DataView();
        DataView DiscarDV = new DataView();
        DataView contractExecuter = new DataView();
        
        private void LeadNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Checkall1.Checked = false;
            
            Wait wwt = new Wait();
            try
            {
                bgwSearch.RunWorkerAsync();
                wwt.ShowDialog();
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            if (Contractlist.Rows.Count > 0)
            {
                radGroupBox5.Visible = true;
            }
            /*-------------------------------------------------------------------------------------------------*/
        }
        private void FillGrid()
        {
           
            contractview.RowFilter = "";
            Contractlist.DataSource = contractview;
            Records.Text = contractview.Count.ToString();
    
           if (contractview.Count < 1) { MessageBox.Show("No Record Found","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Information); return; }
            
        }

        private void Salesfloorid_TextChanged(object sender, EventArgs e)
        {
            if(Salesfloorid.Text.Length >= 2) { Propertyid.Focus(); Salesfloor.SelectedValue = Convert.ToInt32(Salesfloorid.Text); }
        }

        private void Propertyid_TextChanged(object sender, EventArgs e)
        {
            if(Propertyid.Text.Length >= 2) { Agreementnumber1.Focus(); Property.SelectedValue = Propertyid.Text; }
        }

        private void Agreementnumber1_TextChanged(object sender, EventArgs e)
        {
            Agreementnumber2.Text = Agreementnumber1.Text;
        }

        private void AgreementsTransference_Load(object sender, EventArgs e)
        {
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortTimeString();
            salesfloors = SQLCMD.SQLdata("sp_l_salesfloor '2','0',''").DefaultView;
            Salesfloor.DataSource = salesfloors;
            Salesfloor.DisplayMember = "name";
            Salesfloor.ValueMember = "Id";
            propertys = SQLCMD.SQLdata("sp_l_Property '4','0',' '").DefaultView;
            Property.DataSource = propertys;
            Property.DisplayMember = "commonName";
            Property.ValueMember = "Id";
            /*------------------------------------------------*/
            if (Globalvariables.DataBaseInfo.Table.Rows[0]["Currentdatabase"].ToString().ToLower() == "ownerdemo")
            {
                SourceList.DataSource = SQLCMD.SQLdata("dtsdemo.dbo.sp_l_source '6','6',''").DefaultView;
            }
            else
            {
                SourceList.DataSource = SQLCMD.SQLdata("dts.dbo.sp_l_source '6','6',''").DefaultView;
            }

            //SourceList.DataSource = SQLCMD.SQLdata("dtsdemo.dbo.sp_l_source '6','6',''").DefaultView;
            SourceList.DisplayMember = "Name";
            SourceList.ValueMember = "Id";
            General.GlobalAccess permiso = new General.GlobalAccess();
            permiso.groubox(radGroupBox1);
        }

        private void AgreementsTransference_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            Salesfloor.Text = "";
            Property.Text = ""; SourceList.Text = "";
        }

        private void Checkall1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (Contractlist.Rows.Count < 1)
            {
                return;
            }
            Checkall1.Enabled = false;
            if (Checkall1.Checked)
            {
                for (int i = 0; i < Contractlist.Rows.Count; i++)
                {
                    Contractlist.Rows[i].Cells["select"].Value = true;
                }

            }
            else
            {

                for (int i = 0; i < Contractlist.Rows.Count; i++)
                {
                    Contractlist.Rows[i].Cells["select"].Value = false;
                }
            }
            Checkall1.Enabled = true;

        }
            private void bClear_Click(object sender, EventArgs e)
        {
            Salesfloorid.Text = "";
            Propertyid.Text = "";
            Agreementnumber1.Text = "";
            Agreementnumber2.Text = "";
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortTimeString();
            LeadNumber.Text = "";
            Salesfloor.Text = "";
            Property.Text = "";
            SourceList.Text = ""; bProcess.Checked = false;
            Salesfloorid.Focus(); 
            
        }

        private void bTransfer_Click(object sender, EventArgs e)
        {
            if (Contractlist.RowCount < 1) { MessageBox.Show("No Contract In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                string agreementid = "0",agreementID1="0", selected = "0",SqlQuery="",Sqlquery2="";
                
                    /*------------------------------------------------------------------------------------------------------------------------------------------------------------*/
                    for (int record = 0; record <= Contractlist.RowCount - 1; record++)
                    {
                        selected = Contractlist.Rows[record].Cells["select"].Value.ToString();
                        if (selected == "1") 
                        {
                        agreementid = agreementid +","+ Contractlist.Rows[record].Cells["agreementid"].Value.ToString();
                        //agreementid =  Contractlist.Rows[record].Cells["agreementid"].Value.ToString();
                        Sqlquery2 = Sqlquery2 + " " + "EXEC LS_OWNERSHIPCONTRACT_M2 0,"+ Contractlist.Rows[record].Cells["agreementid"].Value.ToString() + ","+
                            General.Globalvariables.guserid +",null,null,'01-01-1990','01-01-3000',null,null";
                        /*-------------------------------------------------------------------------------------------*/
                         }
                         else
                         { 
                              agreementID1 = agreementID1 + "," + Contractlist.Rows[record].Cells["agreementid"].Value.ToString();
                         }
                    }
                    SqlQuery = "EXEC [0LS_LOAD_COPYCONTRACT_G_2] '" + agreementid + "',null,1";
                 if (agreementid == "0") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return; }
                if (MessageBox.Show("Confirm Transfer", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                /*-------------------------------------------------------------------------------------------------------------------------------------------------------------*/
                contractExecuter = SQLCMD.SQLdata(SqlQuery).DefaultView;
              //  contractExecuter = SQLCMD.SQLdata(Sqlquery2).DefaultView; /*no autorizarlo automaticamente en owner*/
                if (Discard.Checked == true) { DiscarDV = SQLCMD.SQLdata("[0LS_LOAD_COPYCONTRACT_G_2] null,'"+agreementID1+"',5").DefaultView; }
                bSearch.PerformClick();
                Checkall1.Checked = false;
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
             catch (Exception ) { MessageBox.Show("Could Not Transfer the Contracts", "OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void Viewselected_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (Checktransfer.Checked == true) { Checktransfer.Checked = false; }
           
        }

        private void Checktransfer_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (Viewselected.Checked == true) { Viewselected.Checked = false; }
        }

        private void bPreselect_Click(object sender, EventArgs e)
        {
            if (Contractlist.RowCount < 1) { MessageBox.Show("No Contract In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                string agreementid = "0",  selected = "", SqlQuery = "";
                
                    /*----------------------------------------------------------------------------*/
                    for (int record = 0; record <= Contractlist.RowCount - 1; record++)
                    {
                        selected = Contractlist.Rows[record].Cells["select"].Value.ToString();
                        if (selected == "1" & Contractlist.Rows[record].Cells["R"].Value.ToString() == "0")
                        {
                            agreementid = Contractlist.Rows[record].Cells["agreementid"].Value.ToString();
                            SqlQuery = SqlQuery + " " + "EXEC [0LS_LOAD_COPYCONTRACT_G_2] null," + agreementid + ",4"; 
                        /*-------------------------------------------------------------------------------------------------------*/
                      }
                    }
                    if (SqlQuery == "") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                if (MessageBox.Show("Confirm Preselect", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                /*-------------------------------------------------------------------------------------------------------------------------------------------------------------*/
                contractExecuter = SQLCMD.SQLdata(SqlQuery).DefaultView;
                bSearch.PerformClick();
                Checkall1.Checked = false;
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER"); }
            finally { wwt.Close(); }
        }

        private void bDiscard_Click(object sender, EventArgs e)
        {
            if (Contractlist.RowCount < 1) { MessageBox.Show("No Contract In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                string agreementid = "", selected = "", SqlQuery = "";

                /*------------------------------------------------------------------------------------------------------------------------------------------------------------*/
                for (int record = 0; record <= Contractlist.RowCount - 1; record++)
                {
                    selected = Contractlist.Rows[record].Cells["select"].Value.ToString();
                    if (selected == "1" & Contractlist.Rows[record].Cells["R"].Value.ToString() == "1")
                    {
                        agreementid =  Contractlist.Rows[record].Cells["agreementid"].Value.ToString();
                        SqlQuery = SqlQuery +" "+ "EXEC LS_OWNERSHIPCONTRACT_M2 1," + agreementid + ","+General.Globalvariables.guserid+"";
                        /*-------------------------------------------------------------------------------------------------------*/
                    }

                }
                
                if (SqlQuery == "") { MessageBox.Show("No Contracts Selected Or is Not Hold", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (MessageBox.Show("Confirm Discard", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) { return; }
                /*-------------------------------------------------------------------------------------------------------------------------------------------------------------*/
                contractExecuter = SQLCMD.SQLdata(SqlQuery).DefaultView;
                bSearch.PerformClick();
                Checkall1.Checked = false;
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER"); }
            finally { wwt.Close(); }
        }

        private void Contractlist_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            ViewDTSPayments vvview = new ViewDTSPayments();
            int record = Contractlist.CurrentRow.Index;
            vvview.totalmembership = double.Parse(Contractlist.Rows[record].Cells["salesprice"].Value.ToString()) + double.Parse(Contractlist.Rows[record].Cells["closingcost"].Value.ToString()) + double.Parse(Contractlist.Rows[record].Cells["tax"].Value.ToString());
            vvview.datecreate = Contractdate2.Text;
            vvview.agreementid = Contractlist.Rows[record].Cells["agreementid"].Value.ToString();
            vvview.agreementnumber = Contractlist.Rows[record].Cells["agreementnumber"].Value.ToString();
            vvview.ShowDialog();
        }

        private void Salesfloorid_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox validar = new General.ValidarTexbox();
            validar.Solonumerosentero(e);
        }

        private void Propertyid_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Agreementnumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox validar = new General.ValidarTexbox();
            validar.Solonumerosentero(e);
        }

        private void Agreementnumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox validar = new General.ValidarTexbox();
            validar.Solonumerosentero(e);
        }

        private void LeadNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox validar = new General.ValidarTexbox();
            validar.Solonumerosentero(e);
        }

        private void Contractlist_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            
          
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            contractview = SQLCMD.SQLdata("LS_L_CUSTOMERSERVICE_2 null," + ((Salesfloorid.Text.Trim() == "") ? "null" : Salesfloor.SelectedValue.ToString()) + "," +
            ((Propertyid.Text.Trim() == "") ? "null" : "'" + Propertyid.Text.Trim() + "'") + ",'" + ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" +
            ((Contractdate2.Text == "") ? "01-01-3000" : Contractdate2.Text) + "'," +
            ((Agreementnumber1.Text.Trim() == "") ? "null" : Agreementnumber1.Text) + "," + ((Agreementnumber2.Text.Trim() == "") ? "null" : Agreementnumber2.Text) + ",null,null,null," +
            ((LeadNumber.Text.Trim() == "") ? "null" : LeadNumber.Text) + ",null," + ((bProcess.Checked == true) ? "1" : "null") + "," +
            ((SourceList.Text == "" || SourceList.SelectedValue == null) ? "null" : SourceList.SelectedValue.ToString()) + "").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGrid();
            radGroupBox2.Visible = true;
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x=> x.Name== "Wait");
            frm.Close();
        }

        private void Contractlist_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
           
            //e.Row.Cells["select"].Value = true;
        }
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
