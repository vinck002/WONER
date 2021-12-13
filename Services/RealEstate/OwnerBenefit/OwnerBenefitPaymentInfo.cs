using Microsoft.EntityFrameworkCore;
using OwnerDataExt;
using Persistence.DataBase.RealEstateMoldels;
using Persistence.DataBase.RealEstateMoldels.Dto;
using Services.RealEstate.OwnerBenefit.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.OwnerBenefit
{
    public class OwnerBenefitPaymentInfo
    {
        public PaymentMethodFrequency PaymentMethodFrequency;
       

        //------------------------methods for OWNER BENEFIT ComboS
        public PaymentMethodFrequency GetPaymentMethodFrequency()
        {
            using (var ctx = new OwneDbContext())
            {
                PaymentMethodFrequency = new PaymentMethodFrequency();
                PaymentMethodFrequency.PaymentMethod = ctx.PaymentMethod.ToList();
                PaymentMethodFrequency.RealEstatePaymentFrecuency = ctx.RealEstatePaymentFrecuency.ToList();
                return PaymentMethodFrequency;
            }
        }


        public Prop_Proj_Loc_Dto GetPropertyAndType()
        {
            using (var ctx = new OwneDbContext())
            {
                var lstproperties = new Prop_Proj_Loc_Dto();
                lstproperties.lstRealEstateProjectType = ctx.RealEstateProjectType.ToList();
                lstproperties.lstRealEstateLocation = ctx.RealEstateLocation.ToList();
                lstproperties.lstRealEstateProperty = ctx.RealEstateProperty.ToList();
                lstproperties.lstRealEstatePropertyType = ctx.RealEstatePropertyType.ToList();
                
                return lstproperties;
            }
        }
        public List<RealEstateProjectTypeModel> GetPropertyAndTypeByID(int Id)
        {
            using (var ctx = new OwneDbContext())
            {

                var properties = ctx.RealEstateProjectType
                    .Include(pt => pt.RealEstatePropertyType)
                     .ThenInclude(pro => pro.RealEstateProperty)
                      .ThenInclude(loc => loc.RealEstateLocation)
                     .Where(x=>x.RealEstateProjectTypeID == Id)   
                    .ToList();

                return properties;
            }
        }

    }
}
