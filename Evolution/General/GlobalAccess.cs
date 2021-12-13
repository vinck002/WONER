using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Telerik.WinControls.UI;
namespace Evolution.General
{
   public class GlobalAccess
    {
        DataView DVaccess = new DataView();

        public void specialpermit(Form frm)
        {
            DVaccess = General.Globalvariables.DVpermit;

            foreach (Control ctr in frm.Controls)
            {
                /*-------------------------------------------------------------------------*/
                if (Convert.ToInt32(ctr.Tag) != 0)
                {
                    DVaccess.RowFilter = string.Format("code = " + Convert.ToInt32(ctr.Tag) + " and value=1");


                    if (DVaccess.Count >= 1)
                    {
                        ctr.Enabled = true;
                    }
                    else
                    { ctr.Enabled = false; }
                }

            }
        }
 /*------------------------------------------------------------------------------------------*/
 public  void groubox(RadGroupBox grb)
        {
            DVaccess = General.Globalvariables.DVpermit;
            foreach (Control ctr in grb.Controls)
            {
                
                if (ctr.Tag !="" && Convert.ToInt32(ctr.Tag) != 0)
                {
                    int fila = DVaccess.Count;
                    DVaccess.RowFilter = string.Format("code = " + Convert.ToInt32(ctr.Tag) + " and value=1");

                    if (DVaccess.Count >= 1)
                    {
                        ctr.Enabled = true;
                    }
                    else
                    { ctr.Enabled = false; }
                }

            }

        }
        /*----------------------------------------------------------------------------------*/
        public void permisomenucontectual(ContextMenuStrip menu)
        {
           
            DVaccess = General.Globalvariables.DVpermit;
            foreach (ToolStripMenuItem ctr in menu.Items)
            {
              

                if (Convert.ToInt32(ctr.Tag) != 0)
                {
                    int fila = DVaccess.Count;
                    DVaccess.RowFilter = string.Format("code = " + Convert.ToInt32(ctr.Tag) + " and value=1");
                    if (DVaccess.Count >= 1)
                    {
                        ctr.Enabled = true;
                    }
                    else
                    { ctr.Enabled = false; }
                }

            }

        }
        public int AllowPermit(int PermitCode)
        {
            DVaccess = General.Globalvariables.DVpermit;
            DVaccess.RowFilter = string.Format("code = " + PermitCode + " and value=1");
            return DVaccess.Count;
        }
        /*======================================================================================*/
    }
}
