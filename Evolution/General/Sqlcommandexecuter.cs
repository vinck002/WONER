using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Evolution.General
{
   
    public class Sqlcommandexecuter
    {
        General.Conexion conect = new General.Conexion();
        /*---------------Retornar datos de una consulta------------------------------------------------*/
        public DataTable SQLdata(string SQLSTR)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {
                
                conect.SQL() .Open();
                cmd.CommandText = SQLSTR;
                cmd.CommandTimeout = 0;
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = conect.SQL();
                da.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException ecx)
            {
                System.Windows.Forms.MessageBox.Show(ecx.Message, "Owner",MessageBoxButtons.OK,MessageBoxIcon.Error);           
            }
            finally { conect.SQL().Close(); } /*pusee finality para que no quede la conexion abierta*/
            
            return dt;
        }
        public DataSet SQLdataSet(string SQLSTR)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {

                conect.SQL().Open();
                cmd.CommandText = SQLSTR;
                cmd.CommandTimeout = 0;
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = conect.SQL();
                da.Fill(ds);
            }
            catch (System.Data.SqlClient.SqlException ecx)
            {
                System.Windows.Forms.MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conect.SQL().Close(); } /*pusee finality para que no quede la conexion abierta*/

            return ds;
        }

        /*===================================================Fin=========================================================*/
    }
}
