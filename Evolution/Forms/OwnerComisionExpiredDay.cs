using Evolution.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms
{
    public partial class OwnerComisionExpiredDay : Form
    {
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        DataTable DTSearch = new DataTable();
        int beforeMonth;
        string[] months = {"Current","January", "February", "March",
                              "April","May","June",
                              "July","August","September",
                              "October","November","December"
                             };
    public OwnerComisionExpiredDay()
        {
            InitializeComponent();
            LoadMonth();
        }

        void LoadMonth()
        {
            
            CbMonth.Items.AddRange(months);
            CbMonth.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
            try
            {
           
                string mes = CbMonth.SelectedIndex != 0? $"0{CbMonth.SelectedIndex}-01-{DateTime.Now.Year}" : DateTime.Now.ToString("MM-dd-yyyy");
                    //Convert.ToString(DateTime.Now.ToString("MM")));

                DTSearch = SQLCMD.SQLdata($"Sp_OwnerServiceFeeCommision '{(PropertyID.Text == string.Empty ? "OC" : PropertyID.Text)}' ," +
                                            $" {(rdExpired.IsChecked? 1:2)}, '{mes}'");
                Foundrecords.Text = DTSearch.Rows.Count.ToString();

                ContractList.DataSource = DTSearch;

            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdNextToRequest_CheckStateChanged(object sender, EventArgs e)
        {   
           
            if (rdNextToRequest.IsChecked)
            {
                beforeMonth = CbMonth.SelectedIndex;
                //CbMonth.Enabled = false;
                CbMonth.SelectedIndex = 0;
            }
            else
            {
                //CbMonth.Enabled = true;
                CbMonth.SelectedIndex = beforeMonth;
            }
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            ReportToOwnerFeeComisionExp eXPORTOeXCELL = new ReportToOwnerFeeComisionExp();
            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;



            string nombreMes;

            string monthSelected;
            string OwnerfeeExpired;
            if (rdExpired.IsChecked)
            {
                nombreMes = formatoFecha.GetMonthName(Convert.ToInt32(DateTime.Now.ToString("MM")));
                monthSelected = CbMonth.SelectedIndex == 0 ? nombreMes : CbMonth.Text;
                OwnerfeeExpired = "OC EXPIRED WEEKLY PERIOD ";
            }
            else
            {
                nombreMes = formatoFecha.GetMonthName(Convert.ToInt32(DateTime.Now.ToString("MM"))+4);
                monthSelected = nombreMes;
                OwnerfeeExpired = "OC TO EXPIRE WEEKLY PERIOD";
            }
             

            eXPORTOeXCELL.ExportarGridview(DTSearch, monthSelected, OwnerfeeExpired);
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (DTSearch.Rows.Count < 1) { return; }
            ReportViewer repo = new ReportViewer();
           
            string path = "Reports\\OcOwnerFeeComexpired.rpt";
            repo.reportpath = path;
            repo.Inforeport = DTSearch.DefaultView;
            repo.Exportar = false;
            repo.ShowDialog();
        }
    }
}
