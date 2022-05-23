using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{

    public class RealEstateBankTranferenceModel
    {
        [Key]
        public Int64 RealEstateBanksTransferenceID { get; set; }
        public string Description { get; set; }
        public string AccountName { get; set; }
        public Int64 AccountNumber { get; set; }
        public string BeneficiaryAddress { get; set; }
        
        public string IntermediaryBank { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string SwiftCode { get; set; }
        public string RoutingCode { get; set; }
        public string IBAN { get; set; }
        public DateTime CreationDate { get; set; }
        public int Active { get; set; }

        [NotMapped]
        public virtual int notSaveSecuence { get; set; }


        public Int64 RealEstateRegistryID { get; set; }
        public RealEstateRegistryModel RealEstateRegistry { get; set; }
    }
}
