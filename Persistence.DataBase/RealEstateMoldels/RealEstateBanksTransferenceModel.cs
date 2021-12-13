using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateBanksTransferenceModel
    {
        [Key]
       public Int64 RealEstateBanksTransferenceID { get; set; }
       public string AccountName { get; set; }
       public Int64 AccountNumber { get; set; }
        public string BeneficiaryAddress { get; set; }
        public Int64 RealStateRegistryID { get; set; }
        public RealEstateRegistryModel RealEstateRegistry { get; set; }
        public int RealEstatedBankID { get; set; }
        public RealEstatedBankModel RealEstatedBank { get; set; }
        public string IntermediaryBank { get; set; }

    }
}
