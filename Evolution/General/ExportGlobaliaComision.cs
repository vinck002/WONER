using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
namespace Evolution.General
{
    public static class ExportGlobaliaComision
    {
        //0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
        public static void ExportarGridview(Telerik.WinControls.UI.RadGridView DV, string SalesFloor, string DateRange1, string DateRange2, int Option1, System.Data.DataView DAV)
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook WBook;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajoX;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            WBook = aplicacion.Workbooks.Add();
            /*----------------------------------------------------*/
            var xlSheets = WBook.Sheets as Microsoft.Office.Interop.Excel.Sheets;
            var xlNewSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing);
            hoja_trabajoX = xlNewSheet2;
            /*----------------------------------------------------*/
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(1);

            hoja_trabajoX = (Microsoft.Office.Interop.Excel.Worksheet)WBook.Worksheets.get_Item(2);
            /*----------------------------------------------------------------------------------------*/

            /*--------------------------------------------------------------------------------------------*/
            double Percent = 0, TotalDistCCTax = 0;
            object[,] ArrayContratos = new object[DV.Rows.Count + 14, 23];

            var ArrayFormatCell = new List<int>();



            int ContractRowCount = 6;
            var A = DV.Columns.Count;
            for (int i = 0; i < DV.Rows.Count; i++)
            {
                Percent = double.Parse(DV.Rows[i].Cells["paymentpercent"].Value.ToString()); /*iniciarlizar el porciento para validar distribution sales*/
                TotalDistCCTax = ((Percent >= 25) ? 0 : double.Parse(DV.Rows[i].Cells["settledsales"].Value.ToString()) + double.Parse(DV.Rows[i].Cells["settledtaxclosing"].Value.ToString())
                    + double.Parse(DV.Rows[i].Cells["tosettlesales"].Value.ToString()) + double.Parse(DV.Rows[i].Cells["tosettletaxclosing"].Value.ToString()));

                ArrayContratos[ContractRowCount, 0] = DV.Rows[i].Cells["AgreementNumber"].Value.ToString();
                ArrayContratos[ContractRowCount, 1] = DV.Rows[i].Cells["contractdate"].Value.ToString();
                ArrayContratos[ContractRowCount, 2] = DV.Rows[i].Cells["name"].Value.ToString();
                ArrayContratos[ContractRowCount, 3] = DV.Rows[i].Cells["netsales"].Value;
                ArrayContratos[ContractRowCount, 4] = DV.Rows[i].Cells["closingcost"].Value.ToString();
                ArrayContratos[ContractRowCount, 5] = DV.Rows[i].Cells["tax"].Value.ToString();
                ArrayContratos[ContractRowCount, 6] = ((Option1 == 1) ? DV.Rows[i].Cells["distsales"].Value.ToString() : ((Percent >= 25) ? DV.Rows[i].Cells["distsales"].Value.ToString() : "0"));
                ArrayContratos[ContractRowCount, 7] = ((Option1 == 1) ? DV.Rows[i].Cells["distclosingtax"].Value.ToString() : ((Percent >= 25) ? DV.Rows[i].Cells["distclosingtax"].Value.ToString() : TotalDistCCTax.ToString()));
                ArrayContratos[ContractRowCount, 8] = "";
                ArrayContratos[ContractRowCount, 9] = DV.Rows[i].Cells["paymentreceived"].Value.ToString();
                ArrayContratos[ContractRowCount, 10] = DV.Rows[i].Cells["paymentpercent"].Value.ToString();
                ArrayContratos[ContractRowCount, 11] = DV.Rows[i].Cells["accountreceive"].Value.ToString();
                ArrayContratos[ContractRowCount, 12] = "";//DV.Rows[R1].Cells[""].Value.ToString();
                ArrayContratos[ContractRowCount, 13] = DV.Rows[i].Cells["settledsales"].Value.ToString();
                ArrayContratos[ContractRowCount, 14] = DV.Rows[i].Cells["settledtaxclosing"].Value.ToString();
                ArrayContratos[ContractRowCount, 15] = DV.Rows[i].Cells["tosettlesales"].Value.ToString();
                ArrayContratos[ContractRowCount, 16] = DV.Rows[i].Cells["tosettletaxclosing"].Value.ToString();
                ArrayContratos[ContractRowCount, 17] = ((Option1 == 1) ? DV.Rows[i].Cells["pendingtosales"].Value.ToString() : ((Percent >= 25) ? DV.Rows[i].Cells["pendingtosales"].Value.ToString() : "0"));
                ArrayContratos[ContractRowCount, 18] = ((Option1 == 1) ? DV.Rows[i].Cells["pendingtotaxclosing"].Value.ToString() : ((Percent >= 25) ? DV.Rows[i].Cells["pendingtotaxclosing"].Value.ToString() : "0"));
                ArrayContratos[ContractRowCount, 19] = DV.Rows[i].Cells["AccountStatus"].Value.ToString();
                ArrayContratos[ContractRowCount, 20] = DV.Rows[i].Cells["Arrears"].Value.ToString();
                ArrayContratos[ContractRowCount, 21] = DV.Rows[i].Cells["TransactionTypeArrears"].Value.ToString();
                ArrayContratos[ContractRowCount, 22] = "";//DV.Rows[R1].Cells[""].Value.ToString();

                /*--------------Formato por cada linea----------------------------------------------------*/
                if (DV.Rows[i].Cells["NCGuarantee"].Value.ToString() == "1")/*cuando tiene nota de credito de garantia pintar la celda del contracto*/
                {
                    ArrayFormatCell.Add(ContractRowCount);
                }


                ContractRowCount++;
            }
            //*************************colores cuando tiene nota de credito de garantia
            foreach (var item in ArrayFormatCell)
            {
                Microsoft.Office.Interop.Excel.Range RngColorNCG = aplicacion.Range[$"A{item}"];
                RngColorNCG.Font.Color = Color.FromArgb(5, 195, 10);
            }
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A7", "A" + ContractRowCount + ""];
            rango1.NumberFormat = "@";

            Range rngcontratos = hoja_trabajo.Cells.get_Resize(DV.Rows.Count + 7, 22); //4 columnas y las cantidad de filas de la consulta
            rngcontratos.Value2 = ArrayContratos; // pone el array en todas las celdas

            Microsoft.Office.Interop.Excel.Range rangofecha = aplicacion.Range["D7", "R" + DV.RowCount + 7 + ""];
            rangofecha.NumberFormat = "#,##0.00";

            //solo texto en los contractos
            //hoja_trabajo.Cells.EntireColumn.AutoFit();
            //************************************************************************HEADERS*************************
            hoja_trabajo.Cells[6, 1] = "Contracto No";
            hoja_trabajo.Cells[6, 2] = "Fecha";
            hoja_trabajo.Cells[6, 3] = "Nombre Del Cliente";
            hoja_trabajo.Cells[6, 4] = "Ventas Netas";
            hoja_trabajo.Cells[6, 5] = "CC";
            hoja_trabajo.Cells[6, 6] = "ADM";
            hoja_trabajo.Cells[6, 7] = "Ventas";
            hoja_trabajo.Cells[6, 8] = "CC /ADM";
            hoja_trabajo.Cells[6, 9] = "Ajustes Prop. Cancelacion/Nulo";
            hoja_trabajo.Cells[6, 10] = "Pagos Recibidos";
            hoja_trabajo.Cells[6, 11] = "%";
            hoja_trabajo.Cells[6, 12] = "CxC Clientes";
            hoja_trabajo.Cells[6, 13] = "Ajuste CxC Cancelacion/Nulo";
            hoja_trabajo.Cells[6, 14] = "Venta";
            hoja_trabajo.Cells[6, 15] = "ADM";
            hoja_trabajo.Cells[6, 16] = "Venta";
            hoja_trabajo.Cells[6, 17] = "ADM";
            hoja_trabajo.Cells[6, 18] = "Venta";
            hoja_trabajo.Cells[6, 19] = "ADM";
            hoja_trabajo.Cells[6, 20] = "Status";
            hoja_trabajo.Cells[6, 21] = "Arrears";
            hoja_trabajo.Cells[6, 22] = "TransactionType";
            hoja_trabajo.Cells[6, 23] = "Comentario";

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
            rangoG1.Font.Size = 11;
            rangoG1.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoG2 = aplicacion.Range["N5", "O5"];
            rangoG2.MergeCells = true;
            rangoG2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG2.Font.Bold = true;
            rangoG2.Font.Size = 11;
            rangoG2.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoG3 = aplicacion.Range["P5", "Q5"];
            rangoG3.MergeCells = true;
            rangoG3.Interior.Color = Color.FromArgb(185, 253, 187);
            rangoG3.Font.Color = Color.FromArgb(5, 195, 10);
            rangoG3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG3.Font.Bold = true;
            rangoG3.Font.Size = 11;
            rangoG3.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoGx1 = aplicacion.Range["R5", "S5"];
            rangoGx1.MergeCells = true;
            rangoGx1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoGx1.Font.Bold = true;
            rangoGx1.Font.Size = 11;
            rangoGx1.Borders.LineStyle = BorderStyle.FixedSingle;
            Microsoft.Office.Interop.Excel.Range rangoG4 = aplicacion.Range["A6", "W6"];
            rangoG4.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoG4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG4.WrapText = true;
            rangoG4.RowHeight = 25.50;

            /*--------------------------Formato------------------------------------------------------------*/
            //Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["G7", "G" + (ContractRowCount) + ""];
            //rango3.NumberFormat = "#,##0.00";

            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["A" + (ContractRowCount + 1) + "", "V" + (ContractRowCount + 1) + ""];
            rango2.Font.Bold = true;
            rango2.NumberFormat = "#,##0.00";
            rango2.Borders.LineStyle = BorderStyle.FixedSingle;
            rango2.Columns.ColumnWidth = 16;
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[ContractRowCount + 1, 1] = "TOTAL";
            hoja_trabajo.Cells[ContractRowCount + 1, 4] = "=sum(D7:D" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 5] = "=sum(E7:E" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 6] = "=sum(F7:F" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 7] = "=sum(G7:G" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 8] = "=sum(H7:H" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 10] = "=sum(I7:I" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 11] = "=sum(J7:J" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 12] = "=sum(L7:L" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 14] = "=sum(N7:N" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 15] = "=sum(O7:O" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 16] = "=sum(P7:P" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 17] = "=sum(Q7:Q" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 18] = "=sum(R7:R" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 1, 19] = "=sum(S7:S" + (ContractRowCount) + ")";
            hoja_trabajo.Cells[ContractRowCount + 2, 14] = "TOTAL A PAGAR PROPIETARIA USD";
            hoja_trabajo.Cells[ContractRowCount + 2, 16] = "=sum(P" + (ContractRowCount + 1) + ":Q" + (ContractRowCount + 1) + ")";
            /*-------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangoG5 = aplicacion.Range["P6", "Q6"];
            rangoG5.Interior.Color = Color.FromArgb(185, 253, 187);
            rangoG5.Font.Color = Color.FromArgb(5, 195, 10);

            Microsoft.Office.Interop.Excel.Range rangoG7 = aplicacion.Range["N" + (ContractRowCount + 2) + ", P" + (ContractRowCount + 2) + ""];
            rangoG7.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangoG7.Font.Bold = true;
            rangoG7.Font.Size = 11;
            rangoG7.Interior.Color = Color.FromArgb(221, 235, 247);

            Microsoft.Office.Interop.Excel.Range rangoG71 = aplicacion.Range["M" + (ContractRowCount + 2) + ", O" + (ContractRowCount + 2) + ""];

            rangoG71.Borders.LineStyle = BorderStyle.FixedSingle;
            rangoG71.Interior.Color = Color.FromArgb(221, 235, 247);
            rangoG71.MergeCells = true;

            /*-------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells.Font.Name = "Calibri";
            hoja_trabajo.Name = SalesFloor;
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
        //0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
    }
}
