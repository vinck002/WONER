using Evolution.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.General
{
    public class BonnusCommissionerSP
    {
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        List<BonusCommissionerModel> ListCommissionerInfo = new List<BonusCommissionerModel>();

        public List<BonusCommissionerModel> LoadCommissioner(int opc = 0,Int64 BonusCommissionID=0)
        {
            if (opc == 1) // para saber si buscar en commissioner o en BonusCommissionerDetail
            {
                ListCommissionerInfo = SQLCMD.SQLdata($"exec Sp_BONUSCOMMISSIONHISTORYDetail 0,'',0,0,{BonusCommissionID},'',0").AsEnumerable().Select(x => new BonusCommissionerModel()
                {
                    CommissionerID = x.Field<Int64>("CommissionerID"),
                    FullName = x.Field<string>("CommissionerName"),
                    Amount = x.Field<decimal>("CommissionAmount"),
                    ContractQuantity = x.Field<int>("ContractQuantity"),
                    Comment = x.Field<string>("Comment")
                }).ToList();
            }
            else
            {
                ListCommissionerInfo = SQLCMD.SQLdata($"exec Sp_BonusCommissioner {Globalvariables.guserid}").AsEnumerable().Select(x => new BonusCommissionerModel()
                {
                    CommissionerID = x.Field<Int64>("CommissionerID"),
                    FullName = x.Field<string>("FullName"),
                    Amount = x.Field<decimal>("Amount"),
                    Selected = x.Field<int>("Selected")
                }).ToList();
            }

            

            return ListCommissionerInfo;
        }

        public DataTable batchAgreements(int opc,string Date1,string Date2, string BathA = "")
        {
            DataTable batchAgreements = SQLCMD.SQLdata($"exec SP_BONUSTEMPLATECOMMISSION '{Date1}','{Date2}',{opc},'{BathA}'");

            return batchAgreements;
        }

    }
}
