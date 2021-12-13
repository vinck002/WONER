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
    public partial class Percentdistribution : Form
    {
        public Percentdistribution()
        {
            InitializeComponent();
        }
        DataView salesfloorview = new DataView();
        DataView Grdview = new DataView();
        DataView ownerpercent = new DataView();
        int ID_distribution = 0;
        General.Sqlcommandexecuter SQLcmd = new General.Sqlcommandexecuter();
        int IDdistribution = 0;
        double propertydistribution = 0;
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
           
          
         }

        private void Percentdistribution_Load(object sender, EventArgs e)
        {
            
            
            Fillcomboandgrid();
            General.GlobalAccess permiso = new General.GlobalAccess();
            //permiso.specialpermit(this);
            permiso.groubox(radGroupBox2);
        }
        private void Fillcomboandgrid()
        {    /*====================cargar salas de ventas===================*/
            salesfloorview = SQLcmd.SQLdata("sp_l_salesfloor '2','0',''").DefaultView;
            Salesfloor.DataSource = salesfloorview;
            Salesfloor.DisplayMember = "name";
            Salesfloor.ValueMember = "Id";
            /*==============Cargar datos en el datagrid view=====================*/
            Grdview = SQLcmd.SQLdata("LS_OWNERDISTRIBUTION_L2").DefaultView;
            FillGrid(Grdview);
            /*----------cargar las distribucion de ownerpecent-------------------------*/
            ownerpercent = SQLcmd.SQLdata("LS_OWNERPERCENTAGE_ML 0").DefaultView;

        }
        private void FillGrid( DataView DV)
        {
            Grdviewdistribution.DataSource = DV;
           
        }
        private void Percentdistribution_FormClosing(object sender, FormClosingEventArgs e)
        {
       
        }

        private void Percentdistribution_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { BtnExit.PerformClick(); }
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            /*====================Insertar o actualizar distribucion==================================== */
            int option=0, opttaxpercent=0, optclosingpercent=0;
            /*-----------------------------Validaciones-----------------------------------------------------------------------------------------------------------*/
            if (Salesfloor.Text.Trim() == "") { MessageBox.Show("Select Salesfloor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Salesfloor.Focus(); return; }
            if (Amountax.IsChecked == false & Percentax.IsChecked == false)
            { MessageBox.Show("Missing Tax Value Option","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (Amountclosing.IsChecked == false & Percentclosing.IsChecked == false)
            {
                MessageBox.Show("Missing Closing Cost Value Option", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            if (Propertypecent.Text.Trim() == "") { MessageBox.Show("Type Property Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Propertypecent.Focus(); return; }
            if (Taxvalue.Text.Trim() == "") { MessageBox.Show("Type Tax Value", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Taxvalue.Focus(); return; }
            if (Taxsettlepencent.Text.Trim() == "") { MessageBox.Show("Type Tax Settlement", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Taxsettlepencent.Focus(); return; }
            if (Closingcostvalue.Text.Trim() == "") { MessageBox.Show("Type Closing Cost Value", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Closingcostvalue.Focus(); return; }
            if (Closingcostsettlepercent.Text.Trim() == "") { MessageBox.Show("Type Closing Cost Settlement", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);Closingcostsettlepercent.Focus(); return; }
            /*--------------------------------------------------------------------------------------------------------------------------------*/
            if (double.Parse( Propertypecent.Text) > 100 || double.Parse(Propertypecent.Text) < 0) { MessageBox.Show("Property Percent is bigger then 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Propertypecent.Focus(); return; }
            if ((double.Parse(Taxvalue.Text)>100 || double.Parse(Taxvalue.Text) < 0) & Percentax.IsChecked == true) { MessageBox.Show("Tax Percent is bigger than 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Taxvalue.Focus(); return; }
            if (double.Parse(Taxsettlepencent.Text)>100 || double.Parse(Taxsettlepencent.Text) < 0) { MessageBox.Show("Tax Settlement is bigger than 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Taxsettlepencent.Focus(); return; }
            if ((double.Parse(Closingcostvalue.Text)>100 || double.Parse(Closingcostvalue.Text) < 0) & Percentclosing.IsChecked ==true) { MessageBox.Show("Closing Cost Percent is bigger than 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Closingcostvalue.Focus(); return; }
            if (double.Parse(Closingcostsettlepercent.Text)>100 || double.Parse(Closingcostsettlepercent.Text) < 0) { MessageBox.Show("Closing Cost Settlement is bigger than 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Closingcostsettlepercent.Focus(); return; }
            /*----------------------------------------------------------------------------------------------------------------------------------*/
            if (IDdistribution != 0 ) { option = 1; }
            if(!Amountax.IsChecked) { opttaxpercent = 1; }
            if (!Amountclosing.IsChecked) { optclosingpercent = 1; }
            /*----------------Guardar dist sales settlement %----------------------------------------*/
            if(Distsalessettlement.RowCount < 1) { MessageBox.Show("Please Add A Sales Settlement Distribution %", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); From.Focus(); return; }
            propertydistribution_Calc();
            if(propertydistribution != double.Parse(Propertypecent.Text)) { MessageBox.Show("Property Distribution % is Diferente Than Sales Distribution %", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  return; }
            string Sqlquery = "";
            for(int record1=0; record1 <= Distsalessettlement.RowCount -1; record1++)
            {
                Sqlquery = Sqlquery + " " + "EXEC LS_OWNERPERCENTAGE_ML 1, "+ int.Parse(Distsalessettlement.Rows[record1].Cells["ID"].Value.ToString())+ ","+ Salesfloor.SelectedValue + ","+ double.Parse(Distsalessettlement.Rows[record1].Cells["from"].Value.ToString()) + ","+
                    double.Parse(Distsalessettlement.Rows[record1].Cells["until"].Value.ToString()) + ",'"+ Distsalessettlement.Rows[record1].Cells["name"].Value.ToString() + "'";
            }
            /*------------------------------------------------------*/
            Grdview = SQLcmd.SQLdata("LS_OWNERDISTRIBUTION_M2 " + option + "," + IDdistribution + "," + Salesfloor.SelectedValue + ",'" + Applydate.Text + "'," + Propertypecent.Text + ",1,null," +
              Taxvalue.Text + "," + opttaxpercent + "," + Taxsettlepencent.Text + "," + Closingcostvalue.Text + "," + optclosingpercent + "," + Closingcostsettlepercent.Text + " ").DefaultView;
            /*-----------------------------------------------*/
            ownerpercent = SQLcmd.SQLdata(Sqlquery).DefaultView;
            Distsalessettlement.Rows.Clear();
            Btnnew.PerformClick();
            FillGrid(Grdview);
            MessageBox.Show("Done ","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Information);
           
            /*--------------------------------------------------------------------------------------------*/
        }

        private void Grdviewdistribution_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {/*==============llenar campos desde el gridview===================================================*/
            IDdistribution = Convert.ToInt32(Grdviewdistribution.CurrentRow.Cells["ID"].Value);
            Salesfloor.SelectedValue = Convert.ToInt32 ( Grdviewdistribution.CurrentRow.Cells["salefloorID"].Value);
            Propertypecent.Text = Grdviewdistribution.CurrentRow.Cells["propertydist"].Value.ToString();
            Taxvalue.Text = Grdviewdistribution.CurrentRow.Cells["taxvalue"].Value.ToString();
            Taxsettlepencent.Text = Grdviewdistribution.CurrentRow.Cells["taxsettlement"].Value.ToString();
            Closingcostvalue.Text = Grdviewdistribution.CurrentRow.Cells["cc_value"].Value.ToString();
            Closingcostsettlepercent.Text = Grdviewdistribution.CurrentRow.Cells["cc_settlement"].Value.ToString();
            
            Applydate.Text = Grdviewdistribution.CurrentRow.Cells["applic_date"].Value.ToString();
            /*---------------------------------------------------------------------------------------------*/
            if (Grdviewdistribution.CurrentRow.Cells["TAXPERCENT"].Value.ToString() == "0")
            {
                Amountax.IsChecked = true;
                
            }
            else { Percentax.IsChecked = true; }
            /*-----------------------------------------------------------------------------------------------------*/
            if (Grdviewdistribution.CurrentRow.Cells["CC_PERCENT"].Value.ToString() == "0")
            {
                Amountclosing.IsChecked = true;
            }
            else { Percentclosing.IsChecked = true; }
            /*--------------------------------------------------------------------------------*/
            CliearFields(0);
            Fillgriddistsalesettlement(int.Parse(Grdviewdistribution.CurrentRow.Cells["salefloorID"].Value.ToString()));
            /*-----------------------------------------------------------------------------------------------------*/
        }
        private void CliearFields(int Options) 
        {
            ID_distribution = 0; From.Text = ""; Until.Text = "";
            Name.SelectedIndex = ((Options ==0)? 0 : (Name.SelectedIndex ==0)? 1 : 0);
            if(Options == 1) { From.Focus(); }
        }
        private void Btnnew_Click(object sender, EventArgs e)
        {
            Distsalessettlement.Rows.Clear();
            CliearFields(0);
            IDdistribution = 0;
            Salesfloor.Text = "";
            Propertypecent.Text = "";
            Taxvalue.Text = "";
            Taxsettlepencent.Text = "";
            Closingcostvalue.Text = "";
            Closingcostsettlepercent.Text = "";
            Applydate.Text = DateTime.Now.ToShortDateString(); 
            Amountax.IsChecked = false;
            Percentax.IsChecked = false;
            Amountclosing.IsChecked = false;
            Percentclosing.IsChecked = false;

        }

        private void Btndelete_Click(object sender, EventArgs e)
        {/*=================eliminar distribucion===================================*/
            if (Amountclosing.IsChecked == false & Percentclosing.IsChecked == false)
            {
                MessageBox.Show("Please Select A Transaction ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(MessageBox.Show("Confirm Delete  ", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Grdview = SQLcmd.SQLdata("LS_OWNERDISTRIBUTION_M2 2," + IDdistribution + "," + Salesfloor.SelectedValue + ",'" + Applydate.Text + "'," + Propertypecent.Text + ",1,null," +
              Taxvalue.Text + ",0," + Taxsettlepencent.Text + "," + Closingcostvalue.Text + ",0," + Closingcostsettlepercent.Text + " ").DefaultView;
                //deleterecord();
                Btnnew.PerformClick();
                FillGrid(Grdview);
                MessageBox.Show("Done ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Btnnew.PerformClick();
            }
        }

        private void Grdviewdistribution_Click(object sender, EventArgs e)
        {

        }

        private void Propertypecent_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Taxvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Taxsettlepencent_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Closingcostvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Closingcostsettlepercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Percentdistribution_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Name.SelectedIndex = 0;
            Salesfloor.Text = "";
            
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            /*------------------Validar-------------------------------------*/
            if (Salesfloor.Text.Trim() == "") { MessageBox.Show("Select a Salesfloor", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Salesfloor.Focus(); return; }
            if (From.Text.Trim()=="") { MessageBox.Show("Type From Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); From.Focus(); return; }
            if (double.Parse(From.Text) < 0 || double.Parse(From.Text) > 100) { MessageBox.Show("From Percent Must Be Between 0% And 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); From.Focus(); return; }
            if (Until.Text.Trim() == "") { MessageBox.Show("Type Until Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Until.Focus(); return; }
            if (double.Parse(Until.Text) < 0 || double.Parse(Until.Text) >100) { MessageBox.Show("Until Percent Must Be Between 0% And 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Until.Focus(); return; }
            /*--------------------------------------------------------------------------------------------------------*/
            if (ID_distribution == 0)
            {
                Distsalessettlement.Rows.Add(From.Text, Until.Text, Name.Text, ID_distribution);
                CliearFields(1);
            }
            else
            {
                Distsalessettlement.CurrentRow.Cells["from"].Value = From.Text;
                Distsalessettlement.CurrentRow.Cells["until"].Value = Until.Text;
                Distsalessettlement.CurrentRow.Cells["name"].Value = Name.Text;
                CliearFields(1);
            }
        }

        private void From_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Until_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Distsalessettlement_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            From.Text = Distsalessettlement.CurrentRow.Cells["from"].Value.ToString();
            Until.Text = Distsalessettlement.CurrentRow.Cells["until"].Value.ToString();
             Name.SelectedIndex = ((Distsalessettlement.CurrentRow.Cells["Name"].Value.ToString()=="Club")? 0 :1);
            ID_distribution = ((int.Parse(Distsalessettlement.CurrentRow.Cells["ID"].Value.ToString())==0)? 1 : int.Parse(Distsalessettlement.CurrentRow.Cells["ID"].Value.ToString()));
        }
        private void Fillgriddistsalesettlement(int salesfloor)
        {
            Distsalessettlement.Rows.Clear();
            ownerpercent.RowFilter = "";
            ownerpercent.RowFilter = string.Format("salesfloorid =" + salesfloor + "");
            if (ownerpercent.Count < 1) { return; }
           
            foreach (DataRowView record in ownerpercent)
            {
                Distsalessettlement.Rows.Add(record["since"], record["until"], record["name"], record["ID"]);
            }
            Distsalessettlement.Rows[0].IsCurrent = true;
        }
        private void propertydistribution_Calc()
        { double percentclub=0, percentproperty=0,percent;
            string name = "";
            for (int record2 = 0; record2 <= Distsalessettlement.RowCount - 1; record2++)
            { 
                percent = double.Parse(Distsalessettlement.Rows[record2].Cells["Until"].Value.ToString());
                name = Distsalessettlement.Rows[record2].Cells["name"].Value.ToString();
                if (percent < 100 & name =="Club")
                { 
                    percentclub = percentclub + double.Parse(Distsalessettlement.Rows[record2].Cells["Until"].Value.ToString());
                }
                else if(percent <= 100 & name == "Property")
                { 
                    percentproperty = percentproperty + double.Parse(Distsalessettlement.Rows[record2].Cells["Until"].Value.ToString());
                }

            }
            propertydistribution = 0;
            propertydistribution = percentproperty - percentclub;
        }
        /*==========================================================================================*/
    }
}
