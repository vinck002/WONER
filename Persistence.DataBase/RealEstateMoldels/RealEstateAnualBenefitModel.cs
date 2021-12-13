using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateAnualBenefitModel
    {
        [Key]
        public Int64 RealEstateAnualBenefitID { get; set; }
        public decimal AnnualBenefit { get; set; }
        public decimal Amount { get; set; }
        public int Active { get; set; }
        public DateTime EfectiveDate { get; set; }
       
        public Int64 RealEstateRegistryID {get;set;}
        public RealEstateRegistryModel RealEstateRegistry { get; set; }

        public Int64 RealEstatePaymentFrecuencyID { get; set; }
        public RealEstatePaymentFrecuencyModel RealEstatePaymentFrecuency { get; set; }
        public IList<RealEstatePropertyOBenefitModel> RealEstatePropertyOBenefit { get; set; }

    }
}
