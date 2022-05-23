using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels.Dto
{
    public class PropertyBenefitDto
    {
        public Int64 RealEstateAnualBenefitID { get; set; }
        public Int64 RealEstatePropertyID { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public int AnualbenefitActive { get; set; }
        public int RealEstateLocationID { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime EfectiveDate { get; set; }
        public RealEstateLocationModel RealEstateLocation { get; set; }
        public int RealEstatePropertyTypeID { get; set; }
        public RealEstatePropertyTypeModel RealEstatePropertyType { get; set; }

    }
}
