using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstatePropertyModel
    {
        [Key]
        public Int64 RealEstatePropertyID { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }

        public int RealEstateLocationID { get; set; }
        public RealEstateLocationModel RealEstateLocation { get; set; }
        public int RealEstatePropertyTypeID { get; set; }
        public RealEstatePropertyTypeModel RealEstatePropertyType { get; set; }
       
        public IList<RealEstatePropertyOBenefitModel> RealEstatePropertyOBenefit { get; set; }



    }
}
