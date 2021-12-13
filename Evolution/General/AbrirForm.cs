using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.General
{
  public   class AbrirForm
    {
        Dictionary<string, Form> Ins = new Dictionary<string, Form>(); 
        public void OpenForm(String NombreForm)
        {
            try
            {
                Form Frm;
                if (!Ins.TryGetValue(NombreForm, out Frm) || Frm.IsDisposed)
                {
                    Frm = (Form)Activator.CreateInstance(null, NombreForm).Unwrap();
                    Ins[NombreForm] = Frm;
                }
                Frm.Show();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
            /*-----------------------------------------------------------------------------------------------*/
        }
}
