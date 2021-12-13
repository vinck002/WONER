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


namespace Evolution.Forms
{
    public partial class ChoosExportColumns : Form
    {
        //DataTable dtSearch = new DataTable();
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        List<ColumnExportModel> lstCollums;
        private int _FormID;
        //Globalvariables globalvariables = new Globalvariables();
        //public ChoosExportCollums()
        //{
        //    InitializeComponent();
        //}
        public ChoosExportColumns(int FormID)
        {
            InitializeComponent();
            _FormID = FormID;
            
            Ejecutar();
     
            //Collumns_To_Export
        }
        public void Ejecutar()
        {
            try
            {
                lstCollums = SQLCMD.SQLdata($"Sp_ChoosExportColumsPerUsers {Globalvariables.guserid} ,{_FormID}").AsEnumerable().Select(x =>
                                                          new ColumnExportModel
                                                          {
                                                              Id = x.Field<Int64>("Id"),
                                                              FormCode = x.Field<int>("FormCode"),
                                                              ColumnName = x.Field<string>("ColumnName"),
                                                              Description = x.Field<string>("Description"),
                                                              Visible = x.Field<int>("Visible"),
                                                              ColumnNumber = x.Field<int>("ColumnNumber")
                                                              ,
                                                              DefaultColumns = x.Field<bool>("DefaultColumns")
                                                          }).ToList();
                grvCollumsCheck.DataSource = lstCollums.Where(x => x.DefaultColumns != true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           


            //lstCollums = SQLCMD.SQLdata($"Sp_ChoosExportCollums {_FormID}").AsEnumerable().Select(x =>
            //                                               new CollumnExportModel
            //                                               {
            //                                                   Id = x.Field<Int64>("Id"),
            //                                                   FormCode = x.Field<int>("FormCode"),
            //                                                   CollumName = x.Field<string>("CollumName"),
            //                                                   Description = x.Field<string>("Description"),
            //                                                   Visibl = x.Field<bool>("Visibl"),
            //                                                   ColumNumber = x.Field<int>("ColumNumber")
            //                                                   ,
            //                                                   DefaultCollumns = x.Field<bool>("DefaultCollumns")
            //                                               }).ToList();
            //grvCollumsCheck.DataSource = lstCollums.Where(x => x.DefaultCollumns != true);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvCollumsCheck_Click(object sender, EventArgs e)
        {

        }

        private void bProccess_Click(object sender, EventArgs e)
        {
            try
            {
                string DataColums = "";
                foreach (var item in grvCollumsCheck.Rows)
                {
                    DataColums += $" exec Sp_ChoosExportColumsPerUsers {Globalvariables.guserid}, {_FormID},2,{item.Cells["Id"].Value.ToString()}, {item.Cells["ColumnNumber"].Value.ToString()},{item.Cells["Visible"].Value} ;";
                }
                SQLCMD.SQLdata(DataColums);
                grvCollumsCheck.DataSource = null;
                Ejecutar();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

        }

        private void grvCollumsCheck_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                if (Convert.ToBoolean(e.Row.Cells[0].Value) )
                {
                    e.Row.Cells[0].Value = false;
                }
                else
                {
                    e.Row.Cells[0].Value = true;
                }
            }
        }
    }
}
