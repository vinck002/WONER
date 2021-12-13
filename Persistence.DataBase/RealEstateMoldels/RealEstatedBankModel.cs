using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstatedBankModel
    {
        [Key]
        public int RealEstatedBankID { get; set; }
           public string BankName { get; set; }
           public string BankAddress { get; set; }
           public string SwiftCode { get; set; }
           public string RoutingCode { get; set; }
           public DateTime CretionDate { get; set; }
           public int Active { get; set; }

    }
}
