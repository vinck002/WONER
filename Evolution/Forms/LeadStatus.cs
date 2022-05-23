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
    public partial class LeadStatus : Form
    {

        Int64 _CompanyReportHistoryID = 0;
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataTable dt;
        int CantLeadToPay = 0;
        DataTable savetransaction;
        public LeadStatus()
        {
            InitializeComponent();
            
        }

        public LeadStatus(Int64 CompanyReportHistoryID): this()
        {
          dt= SQLCMD.SQLdata($"Sp_ChackLeadPaidStatus {CompanyReportHistoryID},'01-01-2022'");
            dtgLead.DataSource = dt;

            lblLeadQty.Text = dt.Rows.Count.ToString();
            CantLeadToPay = dt.AsEnumerable().Where(x => x.Field<int>("Selected") == 1).Count();
            lblLeadToPay.Text = CantLeadToPay.ToString();
            Amount.Text = (CantLeadToPay * 100).ToString("C2");
            RealPaymentDate.Value = DateTime.Today;
            CreationDate1.Value = DateTime.Today;
            lblSource.Text = dt.Rows[0]["SourceName"].ToString();
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if (RealPaymentDate.Text == "") { MessageBox.Show("Missing Real Payment Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); RealPaymentDate.Focus(); return; }
            if (CreationDate1.Text == "") { MessageBox.Show("Please Type Application Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); CreationDate1.Focus(); return; }
            /*-----------------------------------------------------------------------*/
            string LeadPayment = "";
            int HasLead = 0;

            if (CantLeadToPay > 0)
            {
                LeadPayment = $"Lead-Q Payment Qty Lead:{CantLeadToPay}";
                HasLead = 1; //si existe lead para pagar  entonces indicamos 1 para guadar este estado en la transaccion

            }
            savetransaction = SQLCMD.SQLdata("LS_CompanyReportHistory_M 0,1,'" + LeadPayment + "'," + "''" + "," + double.Parse(Amount.Text.Trim().Replace("$","")) + "," + 14 + "," +   General.Globalvariables.guserid + ",'" + CreationDate1.Text + "','" + RealPaymentDate.Text + "'," + HasLead.ToString()+"");

           int HistoryID1 =Convert.ToInt32(savetransaction.Rows[0]["CompanyReportHistoryID"]);

            if (CantLeadToPay > 0)
            {
                StringBuilder LeadQPaying = new StringBuilder("");

                foreach (DataRow item in dt.AsEnumerable().Where(x => x.Field<int>("Selected") == 1 && x.Field<int>("StatusPaid") == 0).CopyToDataTable().Rows)
                {
                    LeadQPaying.Append($"exec Sp_CompanyReportPaidLeadDetail {HistoryID1},{item[2]};");
                }
                SQLCMD.SQLdata(LeadQPaying.ToString());
                MessageBox.Show("Done!");
            }
        }
    }
}
