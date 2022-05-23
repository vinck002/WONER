using Persistence.DataBase.RealEstateMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.Owner.Dto
{
   public  class PaymentMethodFrequency
    {
        public List<RealEstatePaymentFrecuencyModel> RealEstatePaymentFrecuency { get; set; }
        public List<PaymentMethodModel> PaymentMethod { get; set; }
        public List<RealEstateContactTypeModel> RealEstateContactType { get; set; }


    }
}
