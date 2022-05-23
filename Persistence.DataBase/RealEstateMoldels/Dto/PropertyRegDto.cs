using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels.Dto
{
    public class PropertyRegDto
    {
       public Int64 RealEstateAnualBenefitID { get; set; }
       public decimal AnnualBenefit { get; set; } 
       public decimal Amount { get; set; }
       public DateTime EfectiveDate { get; set; }
       public DateTime ContracDate { get; set; }
       public string PaymentMethod { get; set; }
       public Int64 RealEstatePropertyID { get; set; }

          
    }
}
