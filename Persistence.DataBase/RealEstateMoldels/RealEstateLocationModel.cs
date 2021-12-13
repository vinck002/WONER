using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateLocationModel
    {
        [Key]
        public int RealEstateLocationID { get; set; }
        public string description { get; set; }
        public int Active { get; set; }
        public ICollection<RealEstatePropertyModel> RealEstateProperty { get; set; }

    }
}
