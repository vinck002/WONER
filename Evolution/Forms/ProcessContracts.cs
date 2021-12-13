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
    public partial class ProcessContracts : Form
    {
        public ProcessContracts()
        {
            InitializeComponent();
        }
        public string agrementnumber, reference, paymentmethod,salesfloorid,contractdate1,contractdate2, agreementid;
       public Double sales, closing_tax,xsales,xcctax,SettlementValidation;
        DataView paymethod = new DataView();
        DataView contractproccess = new DataView();
        string currentdate = DateTime.Now.ToShortDateString();

        private void ProcessContracts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { DialogResult = DialogResult.Cancel; }
        }

        private void ProcessContracts_Activated(object sender, EventArgs e)
        {
            Applicationdate.SetToNullValue();
        }

        private void Sales_TextChanged(object sender, EventArgs e)
        {
            double x1 = ((Sales.Text.Trim() =="")? 0 : double.Parse(Sales.Text)), x2 = ((Closingtax.Text.Trim() == "") ? 0 : double.Parse(Closingtax.Text)), x3 = 0;
            x3 = x1 + x2;
            Total.Text = x3.ToString("#,##0.00");
        }

        private void Closingtax_TextChanged(object sender, EventArgs e)
        {
            double x1 = ((Sales.Text.Trim() == "") ? 0 : double.Parse(Sales.Text)), x2 = ((Closingtax.Text.Trim()=="")? 0 : double.Parse(Closingtax.Text)), x3 = 0;
            x3 = x1 + x2;
            Total.Text = x3.ToString("#,##0.00");
        }

        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        General.ValidarTexbox validartextbox = new General.ValidarTexbox();

        private void Closingtax_KeyPress(object sender, KeyPressEventArgs e)
        {
            validartextbox.Solonumeros(e);
        }

        private void bProcess_Click(object sender, EventArgs e)
        {
            /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            String AppDate = "";
            if (Sales.Text.Trim() == "") { Sales.Text = "0"; }
            if (Closingtax.Text.Trim() == "") { Closingtax.Text = "0"; }
            if (double.Parse(Sales.Text)+double.Parse(Closingtax.Text)==0) { MessageBox.Show("Nothing To Process","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning);return; }
            if (sales + closing_tax == 0) { MessageBox.Show("Nothing To Process", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Paymentmethod.Text.Trim() == "") { MessageBox.Show("Select Payment Method", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Paymentmethod.Focus(); return; }
            if(Reference.Text.Trim()=="") { MessageBox.Show("Type Reference", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Reference.Focus(); return; }
            if (Applicationdate.Text.Trim() == "") { MessageBox.Show("Select Application Date","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            if (DateTime.Parse(Applicationdate.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(sales < double.Parse(Sales.Text)) { MessageBox.Show("amount to settle is bigger than available","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            if (closing_tax < double.Parse(Closingtax.Text)) { MessageBox.Show("amount to settle is bigger than available", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            AppDate = Applicationdate.Text;
            if (DateTime.Parse(Applicationdate.Text) > DateTime.Parse(contractdate2) || DateTime.Parse(Applicationdate.Text) <  DateTime.Parse(contractdate1) )
            {
                if (MessageBox.Show("Application Date is Out Of Searching Date Range \n Do you Want To Continue ?  ", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) { return; }
            }
            /*------------------Validar Para no procesar a una fecha menor al pago que se liquidara------------------------------------------*/
            //ValidateProcessPay = SQLCMD.SQLdata("LS_ValidateProcessPay_L '"+Applicationdate.Text+"',"+ agreementid + "").DefaultView;
            //if(PaymentReceived != double.Parse(ValidateProcessPay.Table.Rows[0]["PaymentSum"].ToString()))
            //{
            //    MessageBox.Show("Cannot Process When Application Date is Less than Payment Date ", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Applicationdate.Focus(); return;
            //}
            //se decidio dejarlo como estaba ya que el proceso toma la el ultimo parametro de fecha
            /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            if(SettlementValidation > 0)
            {
                if (MessageBox.Show("This Payment has been Processed.\n Do you want to continue ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            }
            if (MessageBox.Show("Confirm Process ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            if (contractdate1 == "") { contractdate1 = contractdate2; }
            contractproccess = SQLCMD.SQLdata("LS_M_CHECKHISTORY_2 " + salesfloorid + ",'" + contractdate1 + "','" + contractdate2 + "',0, 0,'" + 
                Reference.Text + "',0,0," + Paymentmethod.SelectedValue + "," + General.Globalvariables.guserid + ",0," +
                   double.Parse(Sales.Text) + "," + double.Parse(Closingtax.Text) + ",0,0,'" + AppDate + "'").DefaultView;
            /*------------------------------------------------------------------------------------------------------------*/
            if (contractproccess.Count < 1) { return; }
            int checkhistoryID = Convert.ToInt32(contractproccess.Table.Rows[0]["ID_CHECKHISTORY"].ToString());
            contractproccess = SQLCMD.SQLdata("LS_M_CHECKHISTORYDETAIL1 " + checkhistoryID + "," + double.Parse(Sales.Text) + "," + double.Parse(Closingtax.Text) + "," + agreementid + "").DefaultView;
            xsales = double.Parse(Sales.Text);
            xcctax = double.Parse(Closingtax.Text);
             DialogResult = DialogResult.OK;
            //radButton1.PerformClick();
        }

        private void Sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            validartextbox.Solonumeros(e);
        }

       
        private void radButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ProcessContracts_Load(object sender, EventArgs e)
        {
            paymethod = SQLCMD.SQLdata("SP_L_paymenttype 1,0,null").DefaultView;
            Paymentmethod.DataSource = paymethod;
            Paymentmethod.DisplayMember = "Description";
            Paymentmethod.ValueMember = "ID";
            /*-------------------------------------------------------------*/
            if(paymentmethod == "0") { Paymentmethod.Text = ""; }
            else { Paymentmethod.SelectedValue = int.Parse(paymentmethod); }
            agreementnumber.Text = agrementnumber;
            Reference.Text = reference;
            Sales.Text = sales.ToString("#,##0.00");
            Closingtax.Text = closing_tax.ToString("#,##0.00");
            double totalsum = sales + closing_tax;
            Total.Text = totalsum.ToString("#,##0.00");
            /*-------------------------------------------------------------*/
        }
    }
}
