using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstatePaymentFrecuencyModel
    {
     [Key]
     public Int64 RealEstatePaymentFrecuencyID { get; set; }
     public string description { get; set; }
     public int FrecuenceValue { get; set; }
     public int Active { get; set; }

     //public ICollection<RealEstateRegistryModel> RealEstateRegistrys { get; set; }
     //public ICollection<RealEstateAnualBenefitModel> RealEstateAnualBenefit { get; set; }




    }
}
