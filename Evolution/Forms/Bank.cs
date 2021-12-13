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
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();
        }
        DataView DVSave = new DataView();
        DataView DV = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        string BankID = "0";
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FillGrid()
        {
            DV = SQLCMD.SQLdata("LS_Bank_ML 3").DefaultView;
            GRD.DataSource = DV;
        }
        private void Bank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void Btnnew_Click(object sender, EventArgs e)
        {
            BankID = "0";
            BankName.Text = ""; Address.Text = "";
            SwiftCode.Text = ""; RoutingCode.Text = "";
            BankName.Focus();
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {   
            if (BankName.Text.Trim() == "") { MessageBox.Show("Missing Bank Name", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); BankName.Focus(); return; }
            if (Address.Text.Trim() == "") { MessageBox.Show("Missing Address", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Address.Focus(); return; }
            if (SwiftCode.Text.Trim() == "") { MessageBox.Show("Missing Swift Code", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); SwiftCode.Focus(); return; }
            if (RoutingCode.Text.Trim() == "") { MessageBox.Show("Missing Routing Code", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); RoutingCode.Focus(); return; }
            /*----------------------------------------------------------------------------------*/
            try
            {
                DVSave = SQLCMD.SQLdata("LS_Bank_ML " + ((BankID == "0") ? "0" : "1") + "," + BankID + ",'" + BankName.Text.Trim().Replace("'","''") + "','" + Address.Text.Trim().Replace("'", "''") + "','" +
                 SwiftCode.Text.Trim().Replace("'", "''") + "','" + RoutingCode.Text.Trim().Replace("'", "''") + "'").DefaultView;
                FillGrid();
                Btnnew.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            /*------------------------------------------------------------------------------------*/
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            if (GRD.RowCount < 1) { MessageBox.Show("No Bank In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Confirm Delete", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {   return; }
            BankID = ((BankID =="0")? GRD.CurrentRow.Cells["BankID"].Value.ToString() : BankID);
            /*----------------------------------------------------------------------------------*/
            try
            {
                DVSave = SQLCMD.SQLdata("LS_Bank_ML 2," + BankID + ",'x','x','x','x'").DefaultView;
                FillGrid();
                Btnnew.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            /*------------------------------------------------------------------------------------*/
        }

        private void GRD_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRD.RowCount < 1) { return; }
            BankID = GRD.CurrentRow.Cells["BankID"].Value.ToString();
            BankName.Text = GRD.CurrentRow.Cells["bankname"].Value.ToString();
            Address.Text = GRD.CurrentRow.Cells["address"].Value.ToString();
            SwiftCode.Text = GRD.CurrentRow.Cells["swiftcode"].Value.ToString();
            RoutingCode.Text = GRD.CurrentRow.Cells["routingcode"].Value.ToString();
        }

        private void Bank_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
