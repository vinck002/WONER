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
    public partial class AgreementsTransfer : Form
    {
        public AgreementsTransfer()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView contractview = new DataView();
        DataView salesfloors = new DataView();
        DataView propertys = new DataView();
       
        
        private void Salesfloorid_TextChanged(object sender, EventArgs e)
        {
            if(Salesfloorid.TextLength >= 2)
            { Propertyid.Focus(); Salesfloor.SelectedValue = Convert.ToInt32(Salesfloorid.Text);  }
        }

        private void Propertyid_TextChanged(object sender, EventArgs e)
        {
            if (Propertyid.TextLength >=2)
            { Agreementnumber1.Focus(); Property.SelectedValue = Convert.ToInt32(Propertyid.Text); }
        }

        private void Agreementid1_TextChanged(object sender, EventArgs e)
        {
            Agreementnumber2.Text = Agreementnumber1.Text;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Salesfloorid.Text = "";
            Propertyid.Text = "";
            Agreementnumber1.Text = "";
            Agreementnumber2.Text = "";
            Contractdate1.Text = DateTime.Now.ToShortDateString();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            Salesfloor.Text = "";
            Property.Text = "";
            Salesfloorid.Focus();
        }

        private void AgreementsTransfer_Load(object sender, EventArgs e)
        {
            Fillcombos();
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
            /*--------------------------------------------------------*/
           
            Databasefrom.Text = General.Globalvariables.DataBaseInfo.Table.Rows[0]["Databaseto"].ToString(); 
            Databaseto.Text = General.Globalvariables.DataBaseInfo.Table.Rows[0]["Currentdatabase"].ToString();
           
            /*-------------------------------------------------------*/
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
             int salesfloorID, propertyID;
                if (Salesfloor.Text.Trim() == "") { salesfloorID = 0; } else { salesfloorID = int.Parse(Salesfloor.SelectedValue.ToString()); }
             if (Property.Text.Trim() == "") { propertyID = 0; } else { propertyID = int.Parse(Property.SelectedValue.ToString()); }
                contractview = SQLCMD.SQLdata("LS_AGREEMENTSTRANSFER_L 0,'" + Agreementnumber1.Text + "','" + Agreementnumber2.Text + "','" +
                Contractdate1.Text + "','" + Contractdate2.Text + "'," + salesfloorID + "," + propertyID + "").DefaultView;

             FillGrid();
            }catch(Exception ecx) { MessageBox.Show(ecx.Message,"OWNER"); }
            finally { wwt.Close(); }
        }
        private void FillGrid()
        {
            agreementlist.Rows.Clear();
            if (contractview.Count < 1) { MessageBox.Show("No Record Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            foreach (DataRowView record in contractview)
            {
                agreementlist.Rows.Add(record[0], record["agreementnumber"], record["contractdate"], record["salesfloor"], record["propertyid"], record["status"], record["week"], 0);
            }
            agreementlist.Rows[0].IsCurrent = true;
        }
        private void bTransfer_Click(object sender, EventArgs e)
        { if(agreementlist.RowCount < 1) { MessageBox.Show("No Contract In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            Wait wwt = new Wait();
            try
            {
                string agreementid = "0", selected = "";
                for (int record = 0; record <= agreementlist.RowCount - 1; record++)
                {
                    selected = agreementlist.Rows[record].Cells["select"].Value.ToString();
                    if (selected == "1")
                    {
                        agreementid = agreementid + "," + agreementlist.Rows[record].Cells["agreementid"].Value.ToString();
                    }
                }
                if (agreementid == "0") { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                contractview = SQLCMD.SQLdata("LS_AGREEMENTSTRANSFER_L 1,null,null,null,null,null,null,'"+agreementid+"'").DefaultView;
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ecx) { MessageBox.Show(ecx.Message,"OWNER"); }
            finally { wwt.Close(); }
        }

        private void AgreementsTransfer_Activated(object sender, EventArgs e)
        {
            bClear.PerformClick();
        }

        private void Checkall1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (agreementlist.RowCount < 1) { return; }


            for (int record = 0; record <= agreementlist.Rows.Count - 1; record++)
            {
                agreementlist.Rows[record].Cells["Select"].Value = 1;
            }

            if (Checkall1.Checked == false)
            {
                for (int record = 0; record <= agreementlist.Rows.Count - 1; record++)
                {
                    agreementlist.Rows[record].Cells["Select"].Value = 0;
                }

            }
        }
        /*==================================================================================================================================*/
    }
}
