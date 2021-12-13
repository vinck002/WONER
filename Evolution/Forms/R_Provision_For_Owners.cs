using Evolution.General;
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
    public partial class R_Provision_For_Owners : Form
    {

        public DataTable contractview = new DataTable();

        ToolTip toolt = new ToolTip();
        public R_Provision_For_Owners()
        {
            InitializeComponent();
            Contractdate2.MaxDate = DateTime.Today;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            ReportViewer repo = new ReportViewer();
            string path = "Reports\\ThirdReport.rpt";
            repo.reportpath = path;
            //repo.Inforeport = DVReport;
            repo.ShowDialog();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = ""; PropertyID.Text = "";
            Contract1.Text = ""; Contract2.Text = "";
            Contractdate1.SetToNullValue(); Contractdate2.Text = DateTime.Now.ToShortDateString();
            SalesfloorID.Focus();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bExport1_Click(object sender, EventArgs e)
        {
            Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
            try
            {

                ReportProvisionOwner reportEx = new ReportProvisionOwner();
                //ExportToExcel exporttoexcel = new ExportToExcel();
                DateTime dateT2 = new DateTime();
                contractview = SQLCMD.SQLdata($"exec LS_REPORT_PROVISION_OWNER '{(Contractdate1.Text == "" ? "01-01-1990": Contractdate1.Text)}','{(Contractdate2.Text == "" ? dateT2.Date.ToString() /*"12-31-2050"*/ : Contractdate2.Text)}'," +
                    $"{(Contract1.Text == string.Empty ? 0 : Convert.ToInt32(Contract1.Text))},{(Contract2.Text == string.Empty ? 99999 : Convert.ToInt32(Contract1.Text))},{(SalesfloorID.Text == string.Empty ? 0 : Convert.ToInt32(SalesfloorID.Text) )}," +
                    $"{(PropertyID.Text == string.Empty ? 0 : Convert.ToInt32(PropertyID.Text))}");
                if (contractview.Rows.Count < 1) { MessageBox.Show("No Contracts Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
               
                string SaleFloorDescr = contractview.Rows[0]["SALESFLOORDESCRI"].ToString();
                if (contractview.AsEnumerable().GroupBy(x => x.Field<string>("SALESFLOORDESCRI")).ToList().Count() > 1)
                {
                    SaleFloorDescr = "ALL...";
                }
                reportEx.ExportarEXCELL(contractview, SaleFloorDescr, (Contractdate1.Text == "" ? "01-01-1990" : Contractdate1.Text), (Contractdate2.Text == "" ? "12-31-2050" : Contractdate2.Text));
                //exporttoexcel.ExportaraExcel(contractview.AsDataView());



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             
            }
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Length >= 2)
            {
                PropertyID.Focus();
            }
        }

        private void SalesfloorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumericDigit(sender, e);
        }
        void OnlyNumericDigit(object sender, KeyPressEventArgs e)
        {
          
            if (char.IsDigit(e.KeyChar))
            {
              
                e.Handled = false;
                
            }
            else if (Char.IsControl(e.KeyChar))
            {
                
                e.Handled = false;
             
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
              
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
    
            }
        }
        private void PropertyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumericDigit(sender, e);
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumericDigit(sender, e);

        }
        private void Contract2_KeyPress(object sender, KeyPressEventArgs e)
        {
                OnlyNumericDigit(sender, e);
           
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
          
        }
        private void tooltipfunc(Control control)
        {
          
            toolt.Show("Only Numbers!", control, 0, 200, 3000);
        }
        private void R_Provision_For_Owners_Load(object sender, EventArgs e)
        {
            
        }

        private void PropertyID_Enter(object sender, EventArgs e)
        {
            tooltipfunc(PropertyID);
        }
    }
}
