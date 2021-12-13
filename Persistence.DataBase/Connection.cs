using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerDataExt
{
    public class Connection
    {
        string cadenaDemo = @"Data Source=192.168.210.9;Initial Catalog=Ownerdemo;User ID=Demo;Password=Demo2021; TrustServerCertificate=True";
        private string connectionString = "RABhAHQAYQAgAFMAbwB1AHIAYwBlAD0AMQA5ADIALgAxADYAOAAuADIAMQAwAC4AOQA7AEkAbgBpAHQAaQBhAGwAIABDAGEAdABhAGwAbwBnAD0ATwB3AG4AZQByADsAVQBzAGUAcgAgAEkARAA9AHMAYQA7AFAAYQBzAHMAdwBvAHIAZAA9AGQAYgBFAHYAMgAwADkAOAA=";
        private string cadenaCon;
        public Connection(bool Swithdemo  = true)
        {
            //Globalvariables global = new Globalvariables();
            if (Swithdemo)
            {
                cadenaCon = cadenaDemo;
            }
            else
            {
                cadenaCon = CadenaConexion();
                
            }
            

        }
        public string GetConection { get { return cadenaCon; } }
        private string CadenaConexion()
        {
           
                byte[] decryted = Convert.FromBase64String(connectionString);

                string sqlstring = Encoding.Unicode.GetString(decryted);

                return sqlstring;
            

        }
    }
}
