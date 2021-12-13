using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Evolution.General
{
    public class ColumnExportFx
    {
         Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
  
        //private int _FormId = 1;
    
        public List<ColumnExportModel> CollumnExpor(int _FormId)
        {
            return SQLCMD.SQLdata($"Sp_ChoosExportColumsPerUsers {Globalvariables.guserid}, {_FormId}").AsEnumerable().Select(x =>
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

        }
        public string RetornaLetraABC(int index)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string value = "";
            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];
            return value;
        }
    }
}
