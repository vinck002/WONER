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
    public partial class RealStateRegistry :Form
    {
        public RealStateRegistry()
        {
            InitializeComponent();
        }
        long RealStateRegistryID = 0, RealStateOwnerID = 0,OwnerID=0;
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSave = new DataView();
        DataView DV = new DataView();
        DataView DVOwner = new DataView();
        DataView DVPaymentMethod = new DataView();
        DataView DvRoomType = new DataView();
        DataView DvRoom = new DataView();
        bool _loaded = false;
        private void RealStateRegistry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void RealStateRegistry_Load(object sender, EventArgs e)
        {
            /*--------------------------------------------*/
            ddlDeductions.DataSource = SQLCMD.SQLdata("RealStateDeduction_SPL 1").DefaultView;
            ddlDeductions.DisplayMember = "Description";
            ddlDeductions.ValueMember = "RealStateDeductionID";
            ddlProjectName.DataSource = SQLCMD.SQLdata("RealStateProperty_SPL 1").DefaultView;
            ddlProjectName.DisplayMember = "Description";
            ddlProjectName.ValueMember = "RealStatePropertyID";
            ddlFrecuency.DataSource = SQLCMD.SQLdata("RealStateFrecuency_SPL 1").DefaultView;
            ddlFrecuency.DisplayMember = "Description";
            ddlFrecuency.ValueMember = "RealStateFrecuencyID";
            ddlLocation.DataSource = SQLCMD.SQLdata("RealStateLocation_SPL 1").DefaultView;
            ddlLocation.DisplayMember = "Description";
            ddlLocation.ValueMember = "RealStateLocationID";
            /*--------------------------------------------------------------*/
            DvRoomType = SQLCMD.SQLdata("RoomType_SPL 1").DefaultView;
            DvRoom = SQLCMD.SQLdata("RoomType_SPL 2").DefaultView;
            /*--------------------------------------------------------------*/
            ddlPaymentMethod.DataSource = SQLCMD.SQLdata("PaymentMethod_SPL 1").DefaultView;
            ddlPaymentMethod.DisplayMember = "Description";
            ddlPaymentMethod.ValueMember = "PaymentmethodID";
            DVPaymentMethod = SQLCMD.SQLdata("PaymentMethod_SPL 1").DefaultView;
            DVPaymentMethod.Sort = "PaymentMethodID";
            /*--------------------------------------------*/
            Btnnew.PerformClick();
            Screen panta = Screen.PrimaryScreen;
           //  MessageBox.Show(panta.Bounds.Height.ToString());
            if (panta.Bounds.Height - 180 >= 644) { this.Height = panta.Bounds.Height - 180; }
            this.Location = new Point(this.Location.X, 15);
            _loaded = true;
            General.GlobalAccess acceso = new General.GlobalAccess();
            acceso.groubox(radGroupBox2);
            acceso.groubox(radGroupBox3);
        }
        private void _fillOwnergrid()
        {
                DV = SQLCMD.SQLdata($"RealStateRegistry_SPL 1,{RealStateRegistryID},null").DefaultView;
            DV.Sort = "RealStateRegistryID";
            grdRegistry.DataSource = DV;
        }
        private void _fillgrid()
        {
            DVOwner = SQLCMD.SQLdata($"RealStateOwner_SPL 1,{RealStateRegistryID}").DefaultView;
            GRDOwner.DataSource = DVOwner;
        }
        private void Btnnew_Click(object sender, EventArgs e)
        {
            RealStateRegistryID = 0; dtpContractdate.Text= General.Globalvariables.Systemdate.ToShortDateString();
           dtpEfectiveDate.Text = General.Globalvariables.Systemdate.ToShortDateString();
            ddlRoomNo.Text = ""; ddlProjectName.SelectedValue = 0;
            ddlLocation.Text = ""; ddlUnitType.Text = "";
            mebAmount.Text = ""; mebPercent.Text = "";
            txtName.Text = ""; txtLastname.Text = "";
            txtEmail.Text = ""; txtPhone.Text = "";
            if (GRDOwner.RowCount > 0)
            {
                int record = GRDOwner.RowCount - 1;
                for (int i = 0; i <= record ; i++)
                {
                    GRDOwner.Rows.RemoveAt(0); 
                }
            }
            RealStateOwnerID = 0; ddlProjectName.Text = "";
            ddlPaymentMethod.Text = ""; ddlFrecuency.Text = "";
            txtAccountName.Text = ""; txtAddress.Text = "";
            txtBankName.Text = ""; txtBankAddress.Text = "";
            txtIntermediaryBank.Text = ""; txtAba.Text = "";
            txtSwiftCode.Text = ""; txtIban.Text = "";
            ddlDeductions.Text = ""; txtNote.Text = "";
            ddlPaymentMethod.Focus();
            _changebackcolor(1);
            _allowbankinfo(false);
        }
        private void _changebackcolor(int option)
        {
            foreach (Control item in radGroupBox1.Controls)
            {
                
                if (item is Telerik.WinControls.UI.RadLabel) { continue; }
                item.BackColor = ((option == 1) ? Color.White : Color.LightYellow);
            }
        }
        private bool _validation()
        {
            if (ddlPaymentMethod.Text.Trim() == "") { MessageBox.Show("Missing Payment Method", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlPaymentMethod.Focus(); return false; }
            if (txtAccountName.Enabled == true)
            {
                if (txtAccountName.Text.Trim() == "") { MessageBox.Show("Missing Account Name", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtAccountName.Focus(); return false; }
               /* if (txtAddress.Text.Trim() == "") { MessageBox.Show("Missing Address", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtAddress.Focus(); return false; }
                if (txtBankName.Text.Trim() == "") { MessageBox.Show("Missing Bank Name", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtBankName.Focus(); return false; }
                if (txtBankAddress.Text.Trim() == "") { MessageBox.Show("Missing Bank Address", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtBankAddress.Focus(); return false; }
                if (txtSwiftCode.Text.Trim() == "") { MessageBox.Show("Missing Swift", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtSwiftCode.Focus(); return false; }
                if (txtIban.Text.Trim() == "") { MessageBox.Show("Missing IBAN", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtIban.Focus(); return false; }
                if (txtAba.Text.Trim() == "") { MessageBox.Show("Missing ABA", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtAba.Focus(); return false; }
                if (txtIntermediaryBank.Text.Trim() == "") { MessageBox.Show("Missing Intermediary Bank", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtIntermediaryBank.Focus(); return false; }*/
            }
                if (decimal.Parse(mebAmount.Text) <=0) { MessageBox.Show("Invalid Amount", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); mebAmount.Focus(); return false; }
            if (decimal.Parse(mebPercent.Text) <=0 /*|| decimal.Parse(mebPercent.Text) >100*/) { MessageBox.Show("Invalid Total Investment", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); mebPercent.Focus(); return false; }
            /*----------------------------------*/
            if (dtpContractdate.Text == "") { MessageBox.Show("Missing Contract Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (dtpEfectiveDate.Text == "") { MessageBox.Show("Missing Efective Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (ddlProjectName.Text.Trim() == "") { MessageBox.Show("Missing Project Name", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlProjectName.Focus(); return false; }
            if (ddlLocation.Text.Trim() == "") { MessageBox.Show("Missing Location", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlLocation.Focus(); return false; }
            if (ddlUnitType.Text.Trim() == "") { MessageBox.Show("Missing Unit Type", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlUnitType.Focus(); return false; }
            if (ddlRoomNo.Text.Trim() == "") { MessageBox.Show("Missing Unit No.", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtUnitNo.Focus(); return false; }
            if (ddlFrecuency.Text.Trim() == "") { MessageBox.Show("Missing Frecuency", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlFrecuency.Focus(); return false; }
            if (ddlDeductions.Text.Trim() == "") { MessageBox.Show("Missing Deductions", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ddlDeductions.Focus(); return false; }
            if (GRDOwner.RowCount < 1) { MessageBox.Show("Add At Least An Owner Info", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtName.Focus(); return false; }
            return true;
        }
        private void _allowbankinfo(bool value)
        {
            txtAccountName.Enabled = value; txtBankName.Enabled = value;
            txtAddress.Enabled = value; txtBankAddress.Enabled = value;
            txtSwiftCode.Enabled = value; txtIban.Enabled = value;
            txtAba.Enabled = value; txtIntermediaryBank.Enabled = value;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            if (_validation() ==false) { return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                StringBuilder sqlquery = new StringBuilder();
                sqlquery.Append("set nocount on declare @RealStateRegistryID2 BIGINT=0"+" ");
                sqlquery.Append($"exec RealStateRegistry_SPM {((RealStateRegistryID==0)? 0 : 1)},{RealStateRegistryID},"+
               $" {ddlRoomNo.SelectedValue},'{txtAccountName.Text.Trim().Replace("'", "")}','{txtAddress.Text.Trim().Replace("'", "")}',"+
                $"'{txtBankName.Text.Trim().Replace("'", "")}','{txtBankAddress.Text.Trim().Replace("'", "")}','{txtSwiftCode.Text.Trim().Replace("'", "")}',"+
                $"'{txtIban.Text.Trim().Replace("'", "")}','{txtAba.Text.Trim().Replace("'", "")}','{txtIntermediaryBank.Text.Trim().Replace("'", "")}',"+
                $"'{dtpContractdate.Text}','{dtpEfectiveDate.Text}',{mebAmount.Text},{mebPercent.Text},{ddlProjectName.SelectedValue},"+
                $"{ddlLocation.SelectedValue},{ddlUnitType.SelectedValue},{ddlPaymentMethod.SelectedValue},{ddlFrecuency.SelectedValue},"+
                $"{ddlDeductions.SelectedValue},'{txtNote.Text.Trim().Replace("'", "")}',{General.Globalvariables.guserid}, @RealStateRegistryID2 OUTPUT"+" ");
                /*--------------------------------*/
                for (int row = 0; row <= GRDOwner.RowCount -1; row++)
                {
                    if (long.Parse(GRDOwner.Rows[row].Cells["Type"].Value.ToString()) == 0)
                    {
                        sqlquery.Append($"Exec RealStateOwner_SPM 0,0,'{GRDOwner.Rows[row].Cells["firstname"].Value}',"+
                            $"'{GRDOwner.Rows[row].Cells["lastname"].Value}','{GRDOwner.Rows[row].Cells["email"].Value}',"+
                            $"'{GRDOwner.Rows[row].Cells["phone"].Value}',@RealStateRegistryID2,{General.Globalvariables.guserid}"+" ");
                    }
                }
                sqlquery.Append("Select RealStateRegistryID=@RealStateRegistryID2");
                DVSave = SQLCMD.SQLdata(sqlquery.ToString()).DefaultView;
                /*------------------------------------------------------------*/
                if (DVSave.Table.Rows[0][0].ToString() =="0") { MessageBox.Show("Error Saving Data", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                RealStateRegistryID = long.Parse( DVSave.Table.Rows[0][0].ToString());
                _fillOwnergrid();
                Btnnew.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            if (grdRegistry.RowCount < 1) { return; }
            String Info = ((RealStateRegistryID == 0) ? grdRegistry.CurrentRow.Cells["FirstName"].Value.ToString()+" "+grdRegistry.CurrentRow.Cells["FirstName"].Value.ToString() : txtAccountName.Text);
            if (MessageBox.Show("Confirm Delete \n"+Info,"OWNER",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No) { return; }
            RealStateRegistryID = ((RealStateRegistryID == 0) ? long.Parse(grdRegistry.CurrentRow.Cells["RealStateRegistryID"].Value.ToString()) : RealStateRegistryID);
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                StringBuilder sqlquery = new StringBuilder();
                sqlquery.Append("set nocount on declare @RealStateRegistryID BIGINT=0" + " ");
                sqlquery.Append($"exec RealStateRegistry_SPM 2,{RealStateRegistryID}," +
                $"@userID={General.Globalvariables.guserid}, @RealStateRegistryID2=@RealStateRegistryID OUTPUT" + " ");
                /*--------------------------------*/
                sqlquery.Append("Select RealStateRegistryID=@RealStateRegistryID");
                DVSave = SQLCMD.SQLdata(sqlquery.ToString()).DefaultView;
                /*------------------------------------------------------------*/
                if (DVSave.Table.Rows[0][0].ToString() == "0") { MessageBox.Show("Error Deleting Data", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                Btnnew.PerformClick();
                bgwSearch.RunWorkerAsync();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
            if (txtName.Text.Trim() == "") { MessageBox.Show("Missing First Name", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtName.Focus(); return ; }
            if (txtLastname.Text.Trim() == "") { MessageBox.Show("Missing Last Name", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtLastname.Focus(); return ; }
            if (txtEmail.Text.Trim() == "") { MessageBox.Show("Missing Email", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtEmail.Focus(); return ; }
            if (txtPhone.Text.Trim() == "") { MessageBox.Show("Missing Phone", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtPhone.Focus(); return ; }
            /*------------------------------------------------*/
            if(OwnerID >0 && GRDOwner.RowCount > 0)
            {
                for (int row = 0; row <= GRDOwner.RowCount - 1; row++)
                {
                    if (long.Parse(GRDOwner.Rows[row].Cells["ID"].Value.ToString()) == OwnerID)
                    {
                        GRDOwner.Rows[row].Cells["firstname"].Value = txtName.Text.Trim().Replace("'", "''");
                        GRDOwner.Rows[row].Cells["lastname"].Value = txtLastname.Text.Trim().Replace("'", "''");
                        GRDOwner.Rows[row].Cells["email"].Value = txtEmail.Text.Trim().Replace("'", "''");
                        GRDOwner.Rows[row].Cells["phone"].Value = txtPhone.Text.Trim().Replace("'", "''");
                        break;
                    }
                }
            }
            /*-----------------------------------------------*/
            if ( RealStateRegistryID > 0)
            {
                StringBuilder sqlquery = new StringBuilder();
                sqlquery.Append($"Exec RealStateOwner_SPM {((RealStateOwnerID==0)? 0 : 1)},{RealStateOwnerID},'{txtName.Text.Trim().Replace("'", "''")}'," +
                           $"'{ txtLastname.Text.Trim().Replace("'", "''")}','{txtEmail.Text.Trim().Replace("'", "''")}'," +
                           $"'{txtPhone.Text.Trim().Replace("'", "''")}',{RealStateRegistryID},{General.Globalvariables.guserid}" + " ");
                DVSave = SQLCMD.SQLdata(sqlquery.ToString()).DefaultView;
                _fillgrid();
            }
            if (lblEditing.Visible == false && RealStateRegistryID == 0)
            {
                GRDOwner.Rows.Add(RealStateOwnerID, txtName.Text.Trim().Replace("'", "''"), txtLastname.Text.Trim().Replace("'", "''"),
                txtEmail.Text.Trim().Replace("'", "''"), txtPhone.Text.Trim().Replace("'", "''"), ((RealStateOwnerID == 0) ? GRDOwner.RowCount + 1 : RealStateOwnerID), 0);
            }
           
            _clearfields();


        }
        private void _clearfields()
        {
            txtName.Text = ""; txtLastname.Text = ""; lblEditing.Visible = false;
            txtEmail.Text = ""; txtPhone.Text = ""; RealStateOwnerID = 0; OwnerID = 0; txtName.Focus();
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DV = SQLCMD.SQLdata($"RealStateRegistry_SPL 1,null,{((txtSearch.Text.Trim() == "") ? "null" : "'" + txtSearch.Text.Trim().Replace("'", "") + "'")}").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           DV.Sort = "RealStateRegistryID";
            grdRegistry.DataSource = DV;
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            bgwSearch.RunWorkerAsync();
            wwt.ShowDialog();
        }

        private void grdRegistry_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (grdRegistry.RowCount < 1) { return; }
          var dt =  DV.FindRows(grdRegistry.CurrentRow.Cells["RealStateRegistryID"].Value).ToArray();
            RealStateRegistryID = long.Parse(dt[0]["RealStateRegistryID"].ToString());
            //txtUnitNo.Text = dt[0]["unitno"].ToString();
            txtAccountName.Text = dt[0]["accountname"].ToString();
            txtAddress.Text = dt[0]["address"].ToString();
            txtBankName.Text = dt[0]["bankname"].ToString();
            txtBankAddress.Text = dt[0]["bankaddress"].ToString();
            txtSwiftCode.Text = dt[0]["swift"].ToString();
            txtIban.Text = dt[0]["iban"].ToString();
            txtAba.Text = dt[0]["aba"].ToString();
            txtIntermediaryBank.Text = dt[0]["intermediarybank"].ToString();
            txtNote.Text = dt[0]["notes"].ToString();
            dtpContractdate.Text = dt[0]["contractdate"].ToString();
            dtpEfectiveDate.Text = dt[0]["efectivedate"].ToString();
            mebAmount.Text = dt[0]["amount"].ToString();
            mebPercent.Text = dt[0]["feepercent"].ToString();
            ddlProjectName.SelectedValue = int.Parse(dt[0]["RealStatePropertyID"].ToString());
            ddlLocation.SelectedValue = int.Parse(dt[0]["RealStatelocationID"].ToString());
            
            ddlUnitType.SelectedValue = int.Parse(dt[0]["RealStateroomtypeid"].ToString());
            ddlRoomNo.SelectedValue = int.Parse(dt[0]["RealStateroomid"].ToString());
            ddlPaymentMethod.SelectedValue = int.Parse(dt[0]["paymentmethodID"].ToString());
            ddlFrecuency.SelectedValue = int.Parse(dt[0]["RealStatefrecuencyID"].ToString());
            ddlDeductions.SelectedValue = int.Parse(dt[0]["RealStatedeductionID"].ToString());
            _changebackcolor(2);
            _fillgrid();
            // MessageBox.Show(DV.Table.Rows[0]["RealStateRegistryID"].ToString());
            // MessageBox.Show(dt[0][0].ToString());

        }

        private void ddlPaymentMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_loaded == false || ddlPaymentMethod.Text =="") { return; }
            var dt = DVPaymentMethod.FindRows(ddlPaymentMethod.SelectedValue);
            if(int.Parse(dt[0]["Type"].ToString()) == 0)
            { _allowbankinfo(false);
            }
            else
            { _allowbankinfo(true);
            }
            
        }

        private void RealStateRegistry_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
        }

        private void ddlProjectName_SelectedValueChanged(object sender, EventArgs e)
        {
            DvRoomType.RowFilter = "";
            DvRoomType.RowFilter = "RealStatePropertyID = " + ((ddlProjectName.SelectedValue == null) ? "0" : ddlProjectName.SelectedValue.ToString()) + "";
            ddlUnitType.DataSource = DvRoomType;
            ddlUnitType.DisplayMember = "Description";
            ddlUnitType.ValueMember = "RealStateRoomTypeID";
        }

        private void ddlUnitType_SelectedValueChanged(object sender, EventArgs e)
        {
            DvRoom.RowFilter = "";
            DvRoom.RowFilter = "RealStateRoomTypeID = " + ((ddlUnitType.SelectedValue == null) ? "0" : ddlUnitType.SelectedValue.ToString()) + "";
            ddlRoomNo.DataSource = DvRoom;
            ddlRoomNo.DisplayMember = "Description";
            ddlRoomNo.ValueMember = "RealStateRoomID";
        }

        private void GRDOwner_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDOwner.RowCount < 1) { return; }
            RealStateOwnerID = long.Parse(GRDOwner.CurrentRow.Cells["RealStateOwnerID"].Value.ToString());
            OwnerID = long.Parse(GRDOwner.CurrentRow.Cells["ID"].Value.ToString());
            txtName.Text = GRDOwner.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLastname.Text = GRDOwner.CurrentRow.Cells["Lastname"].Value.ToString();
            txtEmail.Text = GRDOwner.CurrentRow.Cells["email"].Value.ToString();
            txtPhone.Text = GRDOwner.CurrentRow.Cells["phone"].Value.ToString();
            lblEditing.Visible = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (GRDOwner.RowCount <= 0) { return; }
            string _info = "";
            if (lblEditing.Visible == false) { _info = GRDOwner.CurrentRow.Cells["Firstname"].Value + " " + GRDOwner.CurrentRow.Cells["Lastname"].Value; RealStateOwnerID = long.Parse(GRDOwner.CurrentRow.Cells["RealStateOwnerID"].Value.ToString()); }
            if (OwnerID > 0 && GRDOwner.RowCount > 0)
            {
                for (int row = 0; row <= GRDOwner.RowCount - 1; row++)
                {
                    if (long.Parse(GRDOwner.Rows[row].Cells["ID"].Value.ToString()) == OwnerID)
                    {
                        _info = txtName.Text + " " + txtLastname.Text;
                        GRDOwner.Rows[row].IsCurrent = true;
                        if (MessageBox.Show("Confirm Remove \n\n" + _info, "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return;  }
                        GRDOwner.Rows.RemoveAt(GRDOwner.CurrentRow.Index);
                        break;
                    }
                }
            }
            if (MessageBox.Show("Confirm Remove \n\n" + _info, "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            /*-------------------------------------------------------*/
            if (RealStateRegistryID > 0)
            {
                StringBuilder sqlquery = new StringBuilder();
                sqlquery.Append($"Exec RealStateOwner_SPM 2,{RealStateOwnerID},@UserID={General.Globalvariables.guserid}" + " ");
                DVSave = SQLCMD.SQLdata(sqlquery.ToString()).DefaultView;
                _fillgrid();
            }
            if (lblEditing.Visible == false && RealStateRegistryID == 0) { GRDOwner.Rows.RemoveAt(GRDOwner.CurrentRow.Index); }
            _clearfields();
        }
    }
}
