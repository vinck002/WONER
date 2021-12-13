
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
namespace Evolution.General
{
    public class ExportToThirdGlobaliaCom
    {
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        List<ColumnExportModel> lstCollums;
        ColumnExportFx CollumnExport = new ColumnExportFx();
        int _FormId = 1;
        public ExportToThirdGlobaliaCom(int FormID = 1)
        {
            _FormId = FormID;
            lstCollums = CollumnExport.CollumnExpor(_FormId);
        }
        //0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
        public void ExportarGridview(Telerik.WinControls.UI.RadGridView DV, string SalesFloor, string DateRange1, string DateRange2, int Option1, System.Data.DataView DAV)
        {/*----------------------------------------------------------------------------------------*/
            int CountCollums = lstCollums.Where(x => x.DefaultColumns == true || x.Visible == 1).ToList().Count();

            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajoX;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();

            var xlSheets = WBook.Sheets as Microsoft.Office.Interop.Excel.Sheets;
            var xlNewSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing);
            hoja_trabajoX = xlNewSheet2;

            hoja_trabajo = /*(Microsoft.Office.Interop.Excel.Worksheet)*/WBook.Worksheets.get_Item(1);
            hoja_trabajoX = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(2);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A7", "A" + DV.RowCount + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos

            double Percent = 0, TotalDistCCTax = 0;

            //*-------------------------******************************trabajando aqui**-----------------------------------**
            object[,] ArrayContratos = new object[DV.Rows.Count + 7, CountCollums+2];

            //*-------------------------******************************trabajando aqui arriba**-----------------------------------**

            int ContractRowCount = 6;
            var A = DV.Columns.Count;
            int Contcollum = 1;


            int colcount = 0;
            var ArrayFormatCell = new List<int>();
            List<string> lstHEADER = lstCollums.Where(x => x.DefaultColumns == true || x.Visible == 1).Select(x => x.ColumnName).ToList();

            for (int i = 0; i < DV.RowCount; i++)
            {
                 Percent = double.Parse(DV.Rows[i].Cells["paymentpercent"].Value.ToString()); /*iniciarlizar el porciento para validar distribution sales*/
                TotalDistCCTax = ((Percent >= 25) ? 0 : double.Parse(DV.Rows[i].Cells["settledsales"].Value.ToString()) + double.Parse(DV.Rows[i].Cells["settledtaxclosing"].Value.ToString())
                    + double.Parse(DV.Rows[i].Cells["tosettlesales"].Value.ToString()) + double.Parse(DV.Rows[i].Cells["tosettletaxclosing"].Value.ToString()));

 
                foreach (string HEADER in lstHEADER)
                {               
                    //****************************insertando en Array***********************************************
                    ArrayContratos[ContractRowCount, colcount] = HEADER.Trim() != "" ? DV.Rows[i].Cells[HEADER].Value.ToString() : "";
                    //***************************************************recorrer * ******************************** 
                    if (DV.Rows[i].Cells["NCGuarantee"].Value.ToString() == "1")/*cuando tiene nota de credito de garantia pintar la celda del contracto*/
                    {
                        ArrayFormatCell.Add(ContractRowCount);
                    }

                    /*-------------------------------------------------------------------------------------------------------*/

                    colcount++;
                }

                ArrayContratos[ContractRowCount, 6] = ((Option1 == 1) ? DV.Rows[i].Cells["distsales"].Value.ToString() : ((Percent >= 25) ? DV.Rows[i].Cells["distsales"].Value.ToString() : "0"));

                ArrayContratos[ContractRowCount, 7] = ((Option1 == 1) ? DV.Rows[i].Cells["distclosingtax"].Value.ToString() : ((Percent >= 25) ? DV.Rows[i].Cells["distclosingtax"].Value.ToString() : TotalDistCCTax.ToString()));


                ArrayContratos[ContractRowCount, 17] = ((Option1 == 1) ? DV.Rows[i].Cells["pendingtosales"].Value.ToString() : ((Percent >= 25) ? DV.Rows[i].Cells["pendingtosales"].Value.ToString() : "0"));

                ArrayContratos[ContractRowCount, 18] = ((Option1 == 1) ? DV.Rows[i].Cells["pendingtotaxclosing"].Value.ToString() : ((Percent >= 25) ? DV.Rows[i].Cells["pendingtotaxclosing"].Value.ToString() : "0"));

                //ArrayContratos[ContractRowCount, 20] = DV.Rows[i].Cells["Arrears"].Value.ToString();
                //ArrayContratos[ContractRowCount, 21] = DV.Rows[i].Cells["TransactionTypeArrears"].Value.ToString();
                colcount = 0;
                ContractRowCount++;
            }

            hoja_trabajo.Cells[6, Contcollum + 2] = "Comentario";

            Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["D" + (7) + "", "S" + (ContractRowCount) + ""];
            rango3.NumberFormat = "#,##0.00";
            //Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (i + 6) + "", $"{RetornaLetraABC(CountCollums)}" + (i + 6) + ""];
            //rango4.Borders.LineStyle = BorderStyle.FixedSingle;

            //**************************** pintar celda: cuando tiene nota de credito de garantia pintar la celda del contracto 
            if (ArrayFormatCell.Count > 0)
            {
                foreach (var item in ArrayFormatCell)
                {
                    Microsoft.Office.Interop.Excel.Range RngColorNCG = aplicacion.Range[$"A{item}"];
                    RngColorNCG.Font.Color = Color.FromArgb(5, 195, 10);
                }
            }


            Microsoft.Office.Interop.Excel.Range rngcontratos = hoja_trabajo.Cells.get_Resize(ContractRowCount, CountCollums+2);
            rngcontratos.Value2 = ArrayContratos; // pone el array en todas las celdas

            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A6", $"{RetornaLetraABC(CountCollums)}6"];
            rangos.Columns.ColumnWidth = 12;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.LightGoldenrodYellow;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["A" + (ContractRowCount + 2) + "", $"{RetornaLetraABC(CountCollums)}" + (ContractRowCount + 2) + ""];
            rango2.Interior.Color = Color.LightGoldenrodYellow;
            rango2.Font.Bold = true;
            rango2.NumberFormat = "#,##0.00";
            rango2.Borders.LineStyle = BorderStyle.FixedSingle;


            Microsoft.Office.Interop.Excel.Range RGNeXPAND = aplicacion.Range["C6"];
            RGNeXPAND.Cells.EntireColumn.AutoFit();

            //******************************************autofit de las nuevas columnas agregadas*******************************
            Microsoft.Office.Interop.Excel.Range RGNeXPAND2 = aplicacion.Range["U6", $"{RetornaLetraABC(CountCollums+2)}6"];
            RGNeXPAND2.Cells.EntireColumn.AutoFit();
            //******************************************HEADER*******************************
            foreach (var item in lstCollums.Where(x => x.DefaultColumns == true || x.Visible == 1).ToList())
            {
                hoja_trabajo.Cells[6, Contcollum] = item.Description;
                Contcollum++;
            }
            //hoja_trabajo.Cells[6, 21] = "Arrears";
            //hoja_trabajo.Cells[6, 22] = "TransactionType";
            //hoja_trabajo.Cells[6, 23] = "Comentario";

            //hoja_trabajo.Cells[6, Contcollum] = "Comentario";
            /*-----------------------Formaro Merge de cada Grupo------------------------------------------*/
            //*****************************FORMATO DE HEADER*************************************************//
            /*-----------------------Parametro--------------------------------------*/
            hoja_trabajo.Cells[1, 1] = "Reporte";
            hoja_trabajo.Cells[2, 1] = "Sala De Ventas";
            hoja_trabajo.Cells[3, 1] = "Rango De Fecha";
            hoja_trabajo.Cells[1, 2] = "LIQUIDACION MENSUALIDADES Y VENTAS";
            hoja_trabajo.Cells[2, 2] = SalesFloor;
            hoja_trabajo.Cells[3, 2] = DateRange1;
            hoja_trabajo.Cells[3, 3] = DateRange2;
            /*-----------------------Formaro Merge de cada Grupo------------------------------------------*/
            hoja_trabajo.Cells[5, 7] = "Propietario";
            hoja_trabajo.Cells[5, 14] = "Liquidado";
            hoja_trabajo.Cells[5, 16] = "A Liquidar";
            hoja_trabajo.Cells[5, 18] = "Por Liquidar";
            Microsoft.Office.Interop.Excel.Range rangoG1 = aplicacion.Range["G5", "H5"];
            rangoG1.MergeCells = true;
            rangoG1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG1.Font.Bold = true;
            rangoG1.Font.Size = 14;
            rangoG1.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoG2 = aplicacion.Range["N5", "O5"];
            rangoG2.MergeCells = true;
            rangoG2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG2.Font.Bold = true;
            rangoG2.Font.Size = 14;
            rangoG2.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoG3 = aplicacion.Range["P5", "Q5"];
            rangoG3.MergeCells = true;
            rangoG3.Interior.Color = Color.LightGreen;
            rangoG3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG3.Font.Bold = true;
            rangoG3.Font.Size = 14;
            rangoG3.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoG4 = aplicacion.Range["R5", "S5"];
            rangoG4.MergeCells = true;
            rangoG4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG4.Font.Bold = true;
            rangoG4.Font.Size = 14;
            rangoG4.Borders.LineStyle = BorderStyle.FixedSingle;
            //*******************************</HEADER>*********************************************************//
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[ContractRowCount + 2, 1] = "TOTAL";
            hoja_trabajo.Cells[ContractRowCount + 2, 4] = "=sum(D7:D" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 5] = "=sum(E7:E" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 6] = "=sum(F7:F" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 7] = "=sum(G7:G" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 8] = "=sum(H7:H" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 10] = "=sum(I7:I" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 11] = "=sum(J7:J" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 12] = "=sum(L7:L" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 14] = "=sum(N7:N" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 15] = "=sum(O7:O" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 16] = "=sum(P7:P" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 17] = "=sum(Q7:Q" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 18] = "=sum(R7:R" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 19] = "=sum(S7:S" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 3, 14] = "TOTAL A PAGAR PROPIETARIA USD";
            hoja_trabajo.Cells[ContractRowCount + 3, 16] = "=sum(P" + (ContractRowCount + 2) + ":Q" + (ContractRowCount + 2) + ")";
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoG5 = aplicacion.Range["P6", "Q6"];
            rangoG5.Interior.Color = Color.FromArgb(185, 253, 187);
            rangoG5.Font.Color = Color.FromArgb(5, 195, 10);

            Microsoft.Office.Interop.Excel.Range rangoG6 = aplicacion.Range["N" + (ContractRowCount + 3) + ", O" + (ContractRowCount + 3) + ""];
            rangoG6.MergeCells = true;
            rangoG6.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG6.Font.Bold = true;
            rangoG6.Font.Size = 12;
            rangoG6.Borders.LineStyle = BorderStyle.FixedSingle;


            /*-------------------------------------------------------------------------------------*/
           
            /*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
            /*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
            /*------Otra Hoja de detalle de pagos--------------------------------*/
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = DAV.Table;



            Microsoft.Office.Interop.Excel.Range formatcolunAD = aplicacion.Worksheets.get_Item(2).Range["A1:D2"];
            formatcolunAD.Font.Bold = true;
            formatcolunAD.Font.Size = 11;
            formatcolunAD.Interior.Color = Color.FromArgb(185, 253, 187);

            //************************************modificado para el nuevo procedimiento

            Microsoft.Office.Interop.Excel.Range formatcolunD = aplicacion.Worksheets.get_Item(2).Range["D3", $"D{DAV.Count + 20}"];
            formatcolunD.NumberFormat = "#,##0.00";

            Microsoft.Office.Interop.Excel.Range formatcolunA = aplicacion.Worksheets.get_Item(2).Range["A3", $"A{DAV.Count + 20}"];
            formatcolunA.NumberFormat = "@";

            object[,] myArray = new object[DAV.Count + 2, 4]; //4 columnas y las cantidad de filas de la consulta

            var rowTotales = new List<int>();

            myArray[0, 0] = "Period"; myArray[0, 1] = DateRange1; myArray[0, 2] = DateRange2; myArray[0, 3] = "Amount";
            myArray[1, 0] = "Agreement #"; myArray[1, 1] = "Member Name"; myArray[1, 2] = "Reference"; myArray[1, 3] = "TOTAL";
            int rowcoun = 2;
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                for (int y = 0; y < dt.Columns.Count; y++)
                {
                    myArray[rowcoun, y] = dt.Rows[x][y];

                    if (dt.Rows[x][y].ToString().Contains("MEMBERSHIP PRICE"))
                    {
                        rowTotales.Add(rowcoun);
                    }
                }
                rowcoun++;
            }

            Range rng = hoja_trabajoX.Cells.get_Resize(dt.Rows.Count + 2, 4); //4 columnas y las cantidad de filas de la consulta
            rng.Value2 = myArray; // pone el array en todas las celdas
            hoja_trabajoX.Name = "Detalle";

            hoja_trabajoX.Cells.EntireColumn.AutoFit();

            //formatcolunD.Style = "Currency";
            ///////////////////////////////////////////**PINTAR LAS FILAS QUE CONTIENE LA PALABRA "MEMBERSHIP PRICE"**////////////////////////////////////////////////////
            foreach (var item in rowTotales)
            {
                Range RngMemberShipPrice = aplicacion.Worksheets.get_Item(2).Range[$"A{item + 1}:D{item + 1}"];
                RngMemberShipPrice.Interior.Color = Color.FromArgb(248, 212, 11);
                RngMemberShipPrice.Borders.LineStyle = BorderStyle.FixedSingle;
                RngMemberShipPrice.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //RngMemberShipPrice.WrapText = true;
                RngMemberShipPrice.RowHeight = 25.50;

            }

            //////////////////////////////////////////////////////////////////////////////////////////

            FormatCondition condition1 = (FormatCondition)rng.FormatConditions.Add(XlFormatConditionType.xlCellValue, XlFormatConditionOperator.xlEqual, "TOTAL");
            condition1.Font.Bold = true;

            //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        string RetornaLetraABC(int index)
        {
            return CollumnExport.RetornaLetraABC(index);

        }
        //0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
    }
}

