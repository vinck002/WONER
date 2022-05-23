using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels.Dto
{
   public class AnualBPropertiesDto
    {
        public Int64 RealEstateAnualBenefitID { get; set; }
        public decimal AnnualBenefit { get; set; }
        public decimal Amount { get; set; }
        public int Active { get; set; }
        public string RealEstateProperty { get; set; }
        public string FrecuencyPayment { get; set; }
        public string PaymentMethod { get; set; }
        public Int64 RealEstatePropertyID { get; set; }
        public DateTime EfectiveDate { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUserID { get; set; }
        public string CreatedBY { get; set; }
        public int Status { get; set; }
        public string UpdatedBy { get; set; }
        public Int64 PaymentMethodID { get; set; }
        public string InstallmentHoldStatus { get; set; }
        public Int64 PrevieusAnualBenefitdID { get; set; }
        public int Secuence { get; set; }
        public int ModifiedUserID { get; set; }
        public int hold { get; set; }
        public int TempAnualproID { get; set; }
    }
}
