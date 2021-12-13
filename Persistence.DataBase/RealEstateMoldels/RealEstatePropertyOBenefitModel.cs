using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstatePropertyOBenefitModel
    {
        [Key]
        public Int64 RealEstateAnualBenefitID { get; set; }
        public RealEstateAnualBenefitModel RealEstateAnualBenefit { get; set; }


        public Int64 RealEstatePropertyID { get; set; }
        public RealEstatePropertyModel RealEstateProperty { get; set; }
        public int Active { get; set;}
        public DateTime CreationDate { get; set; }

    }
}
