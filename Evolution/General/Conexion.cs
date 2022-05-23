using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Evolution.General
{
  public   class Conexion
    {
        #region "Variables (Clases) de Conexion"
        private SqlConnection Conexions;
        #endregion
         string sqlstring = string.Empty;

        string xxx = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
        
        //public bool Swithdemo = true; //Swithdemo: TRUE = DEMO, FALSE= LIVE

        public string Getconection { get; set; }

        public Conexion()
        {
            //Globalvariables global = new Globalvariables();
            
            
            if (Program.SwichDemo)
            {
                Conexions = new SqlConnection(CadenaConexionDemo);
            }
            else
            {
                Conexions = new SqlConnection(CadenaConexion);
            }
          

        }

        private string CadenaConexion
        { 
            get
            {
                byte[] decryted = Convert.FromBase64String(xxx);

                sqlstring = Encoding.Unicode.GetString(decryted);

                return sqlstring;
            }

        }
        private string CadenaConexionDemo
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConexionDemo"].ToString();
            }

        }


        public SqlConnection SQL()
        {
            return Conexions;
        }

    }
}
