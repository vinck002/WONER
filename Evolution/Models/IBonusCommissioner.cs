using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Models
{
   public interface IBonusCommissioner
    {
        void CommissionerInfo(List<BonusCommissionerModel> ListCommissionerInfo);

        void TemplateBathAgreement(DataTable BathAgreement,int Procesed,Int64 BonusCommissionID, string datefrom, string dateTo,string Code);
    }
}
