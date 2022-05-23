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
    public partial class ListPaidLead : Form
    {
        Int64 _CompanyReportHistoryID = 0;
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataTable dt;
        public ListPaidLead()
        {
            InitializeComponent();
        }
        public ListPaidLead(Int64 CompanyReportHistoryID):this()
        {

            dt = SQLCMD.SQLdata($"Sp_CompanyReportPaymentLead {CompanyReportHistoryID}");
            dtgLead.DataSource = dt;

        }
    }
}
