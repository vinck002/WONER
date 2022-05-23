using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels.Dto
{
    public class BankTranferenceDto
    {
        public Int64 RealEstateBanksTransferenceID { get; set; }
        public string AccountName { get; set; }
        public Int64 AccountNumber { get; set; }
        public string BeneficiaryAddress { get; set; }
        public int RealEstatedBankID { get; set; }
        public string IntermediaryBank { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string SwiftCode { get; set; }
        public string RoutingCode { get; set; }
        public DateTime CreationDate { get; set; }
        public int Active { get; set; }
    }
}
