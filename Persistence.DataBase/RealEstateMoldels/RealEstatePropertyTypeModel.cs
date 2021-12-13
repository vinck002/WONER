using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstatePropertyTypeModel
    {
        [Key]
        public int RealEstatePropertyTypeID{ get; set; }
        public string Description { get; set; }
        public int Active { get; set; }

        public Int64 RealEstateProjectTypeID { get; set; }
        public RealEstateProjectTypeModel RealEstateProjectType { get; set; }
        public ICollection<RealEstatePropertyModel> RealEstateProperty { get; set; }

    }
}
