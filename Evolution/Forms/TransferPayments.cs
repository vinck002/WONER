using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms
{
    public partial class TransferPayments : Form
    {
        public TransferPayments()
        {
            InitializeComponent();
        }
        General.OpenExcelFile openexcel = new General.OpenExcelFile();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView viewexcel = new DataView();
        DataView transfertoexcel = new DataView();

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void bLoadexcel_Click(object sender, EventArgs e)
        {

            if (sheetname.Text.Trim() == "") { MessageBox.Show("Missing Sheet Name", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait wwt = new Wait();

            try
            {
                wwt.Show(); wwt.Refresh();
                openexcel.OpenExcelData(sheetname.Text);

                viewexcel = openexcel.DV;
                if (viewexcel.Count < 1) { return; }
                Paymentlist.Columns.Clear();
                Paymentlist.DataSource = viewexcel;
            }
             catch (Exception ) { MessageBox.Show("Could Not Open the File"); }
            finally { wwt.Close(); }
        }

        private void bTransfer_Click(object sender, EventArgs e)
        {
            string referenceid = "";
            referenceid = DateTime.Now.ToString("yyyy") + "" + DateTime.Now.ToString("MM") + "" + DateTime.Now.ToString("dd") + "" + DateTime.Now.ToString("HH") + "" + DateTime.Now.ToString("mm");
           
            if (Paymentlist.RowCount < 1) { MessageBox.Show("No Payments In The List", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                string hold = "", Sqlquery = ""; DateTime datecreate; double amount = 0;
             for (int record = 0; record <= Paymentlist.RowCount - 1; record++)
             {
                hold = Paymentlist.Rows[record].Cells[8].Value.ToString();
                datecreate = DateTime.Parse(Paymentlist.Rows[record].Cells[1].Value.ToString());
                amount = ((double.Parse(Paymentlist.Rows[record].Cells[5].Value.ToString()) < 0) ? double.Parse(Paymentlist.Rows[record].Cells[5].Value.ToString()) * -1 : double.Parse(Paymentlist.Rows[record].Cells[5].Value.ToString()));
                Sqlquery = Sqlquery + " " + "EXEC LS_PAYMENTSTRANSFER_L '" + Paymentlist.Rows[record].Cells[7].Value.ToString() + "','" + datecreate + "','" +
                    Paymentlist.Rows[record].Cells[4].Value.ToString() + "'," + General.Globalvariables.guserid + "," + amount + ",'" +
                    Paymentlist.Rows[record].Cells[6].Value.ToString() + "','" + hold + "',"+referenceid+"";

                
             }
                if (MessageBox.Show("Confirm Transference","OWNER",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) { return; }
                transfertoexcel = SQLCMD.SQLdata("LS_GenerationPayments_M "+referenceid+","+ General.Globalvariables.guserid + "").DefaultView;
                 transfertoexcel = SQLCMD.SQLdata(Sqlquery).DefaultView;
                //Sqlquery = Sqlquery + "x1";
                AddColumns();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void TransferPayments_Load(object sender, EventArgs e)
        {
            AddColumns();
            General.GlobalAccess permiso = new General.GlobalAccess();
            permiso.groubox(radGroupBox1);
        }
        private void AddColumns()
        {
            Paymentlist.Columns.Clear();
            Paymentlist.Columns.Add("Type");
            Paymentlist.Columns.Add("Date");
            Paymentlist.Columns.Add("Num");
            Paymentlist.Columns.Add("Name");
            Paymentlist.Columns.Add("Memo");
            Paymentlist.Columns.Add("Amount");
            Paymentlist.Columns.Add("Code");
            Paymentlist.Columns.Add("Codigo DTS / Owner");
            Paymentlist.Columns.Add("X(cargar con cotejo en Owner)");
        }

        private void TransferPayments_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
        }
        /*--------------------------------------------------------------------------------------*/
    }
}
