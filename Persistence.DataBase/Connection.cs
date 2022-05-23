using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OwnerDataExt
{
    public class Connection
    {
        string cadenaDemo = @"Data Source=192.168.210.9;Initial Catalog=Ownerdemo;User ID=Demo;Password=Demo2021; TrustServerCertificate=True";
        private string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
        private string cadenaCon;
        public Connection(bool Swithdemo = true)
        {
            //Globalvariables global = new Globalvariables();
            if (Swithdemo)
            {
                cadenaCon = cadenaDemo;
            }
            else
            {
                cadenaCon = DesEncript(connectionString);

            }

        }
        public string GetConection { get { return cadenaCon; } }

        //public string Encript(string _cadenaAencriptar)
        //{
        //    string result = string.Empty;
        //    byte[] encryted = Encoding.Unicode.GetBytes(_cadenaAencriptar);
        //    result = Convert.ToBase64String(encryted);
        //    return result;
        //}

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncript(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = Encoding.Unicode.GetString(decryted);
            return result;
        }



    }
}
