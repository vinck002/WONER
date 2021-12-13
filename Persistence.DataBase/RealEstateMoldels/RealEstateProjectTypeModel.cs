using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateProjectTypeModel
    {
        [Key]
        public Int64 RealEstateProjectTypeID { get; set; }
        public string Description {get;set;}
        public int Active { get; set; }
        public ICollection<RealEstatePropertyTypeModel> RealEstatePropertyType { get; set; }

    }
}
