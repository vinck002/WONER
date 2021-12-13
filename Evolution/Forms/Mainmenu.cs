using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Collections.Generic;
using Telerik.WinControls.UI;
using System.Reflection;


namespace Evolution.Forms
{
    public partial class Mainmenu : Form
    {
        public DataView Useraccess = new DataView();
        public DataView Userprofile = new DataView();
        DataView DVTransfer = new DataView();
        General.Sqlcommandexecuter Sqlcmd = new General.Sqlcommandexecuter();
        bool CloseForm = false;
        public Mainmenu()
        {
            InitializeComponent();
        }

        private void Mainmenu_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            foreach (Control ctl in this.Controls)
            {
                if(ctl is MdiClient)
                { 
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
            }
            
            Login log = new Login();
            if(log.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            { radStatusStrip1.Visible = false; radRibbonBar1.Visible = false; Application.Exit(); return; }
            /*------------------*/
            this.Text = General.Globalvariables.AppName;
            CloseForm = true;
            radStatusStrip1.Visible = true; radRibbonBar1.Visible = true;
            Wait wwt = new Wait();
            backgroundWorker1.RunWorkerAsync();
            wwt.ShowDialog();
            bgwTransfer.RunWorkerAsync(); /*sincronizar financiamiento */
        }
        private void Mainmenu_optiom()
        { 
                /*========================crear las demas tab del RadRibbonBar=========================*/
                string itemorder1 = "";
            foreach (DataRowView fila in Useraccess)
            {
                RibbonTab ribo = new RibbonTab();
               
                
                itemorder1 = fila.Row["ItemOrder1"].ToString();
                if (fila.Row["ItemOrder2"].ToString() == "0" & fila.Row["ItemOrder3"].ToString() == "0")
                {
                    ribo.Text = fila.Row["Description"].ToString();
                    ribo.Name = fila.Row["menuitemID"].ToString();

                    /*==================================Crear Grupos en cada RibbonTab======================================================*/
                    
                    Useraccess.RowFilter = string.Format("  ItemOrder1 = '" + itemorder1 +"'");
                    foreach (DataRowView fila1 in Useraccess)
                    {
                        RadRibbonBarGroup grupo = new RadRibbonBarGroup();
                        string grupoitemID = ""; /*Variable para agrupar los botones*/
                        if (fila1.Row["ItemOrder3"].ToString() == "0" & fila1.Row["THIRD_LEVEL"].ToString() != "0")
                        {
                            grupo.Text = fila1.Row["Description"].ToString();
                            grupo.Name = fila1.Row["menuitemID"].ToString();
                            ribo.Items.Add(grupo);
                            grupoitemID = fila1.Row["itemorder2"].ToString(); /*Asignar el order de los botones para que el siguente foreach lo agrupe*/
                           // grupo.Click += RadButtonElementOnClick;
                        }
                        /*======================Crear lo botones en cada RadRibbonBarGroup==================================*/
                        foreach (DataRowView fila2 in Useraccess)
                        {
                            if (fila2.Row["ItemOrder3"].ToString() != "0" & fila2.Row["ItemOrder2"].ToString() == grupoitemID)
                            {
                                RadButtonElement boton = new RadButtonElement();

                                boton.Text = fila2.Row["Description"].ToString();
                                boton.AutoSize = false;
                                boton.Size = new Size(80, 60);
                                boton.TextWrap = true;
                                boton.Name = fila2.Row["formname"].ToString();
                                boton.Click += RadButtonElementOnClick;
                                grupo.Items.AddRange(boton);
                           }
                        }
                    }
                    /*========================================================================================*/
                    radRibbonBar1.CommandTabs.Add(ribo); /*Asignarlo cada Tab al Control radRibbonBar1 */
                }
               
             }
         }
        private void RadButtonElementOnClick(object sender, EventArgs e)
        {

            try
            {
                RadButtonElement botonclick = (RadButtonElement)sender;
                /*----------------------------------------------------------------------------------*/
                string formTypeFullName = string.Format("{0}.{1}", this.GetType().Namespace, botonclick.Name);
                Type type = Type.GetType(formTypeFullName, true);
                Form FrmName = (Form)Activator.CreateInstance(type);
                Form OpenFrmName = this.MdiChildren.FirstOrDefault(x => x.Name == FrmName.Name);
                if (OpenFrmName != null) { OpenFrmName.BringToFront(); return; }
                FrmName.MdiParent = this;
                FrmName.Show();
            }
            catch (Exception ecx) { MessageBox.Show("It Could Not find Form \n"+ ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            /*----------------------------------------------------------------------------------*/

        }
        /*-----------------------------------------------------------------------------------------------------------------------------*/

        private void Mainmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseForm == false) { return; }

            if (MessageBox.Show("Do You Want Exit","OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                
                e.Cancel = false;
            }
            else
            {

                e.Cancel = true;

            }
        }

        private void Mainmenu_Activated(object sender, EventArgs e)
        {

        }

        private void radButtonElement3_Click(object sender, EventArgs e)
        {
            ChangePassword cambio = new ChangePassword();
            cambio.MdiParent = this;
            cambio.Show();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Useraccess = Sqlcmd.SQLdata("LS_USERACCESSDETAIL_L 1," + General.Globalvariables.guserid + "").DefaultView;
            Userprofile = Sqlcmd.SQLdata("LS_USERPROFILEDETAIL_L 2," + General.Globalvariables.UserprofileID + "").DefaultView;
            General.Globalvariables.DVpermit = Userprofile;
            General.Globalvariables.DataBaseInfo = Sqlcmd.SQLdata("LS_DATABASEINFORMATION_L").DefaultView;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mainmenu_optiom();
            if (Useraccess.Count > 0) { radRibbonBar1.Expanded = false; }/*aqui quito el espandido para que salgan las tabs minimizadas*/
            radLabelElement2.Text = General.Globalvariables.Userfullname;
            radLabelElement4.Text = Convert.ToDateTime(General.Globalvariables.Systemdate).ToString("MM/dd/yyyy");

            radLabelElement10.Text = General.Globalvariables.DataBaseInfo.Table.Rows[0]["Currentdatabase"].ToString();
            radLabelElement12.Text = General.Globalvariables.DataBaseInfo.Table.Rows[0]["Server"].ToString();
            /*------------------------------------------------------------------------------------------------------*/
            if (General.Globalvariables.UserprofileID != 8)
            {
                radLabelElement9.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                radLabelElement10.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                radLabelElement11.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                radLabelElement12.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            }
            /*------------------------------------------------------------------------------------------------------*/
            ckbMode.Text = General.Globalvariables.DataBaseInfo.Table.Rows[0]["Mode"].ToString();
            radLabelElement6.Text = General.Globalvariables.DataBaseInfo.Table.Rows[0]["Terminal"].ToString();
            radLabelElement8.Text = Application.ProductVersion;
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x=> x.Name =="Wait");
            frm.Close();
            /*--------------------------------------------------------------*/
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgwTransfer_DoWork(object sender, DoWorkEventArgs e)
        {
            lblProcess.Text = "Synchronizing Financing";
            DVTransfer = Sqlcmd.SQLdata("LS_FinancingTransfer_SPM ").DefaultView;
        }

        private void bgwTransfer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProcess.Text = "....";
        }
        /*================================Fin===========================================================*/
    }
}
