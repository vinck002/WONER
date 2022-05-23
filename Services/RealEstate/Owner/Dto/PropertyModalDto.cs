using Persistence.DataBase.RealEstateMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.Owner.Dto
{
   public class PropertyModalDto
    {
        //public List<RealEstateLocationModel> RealEstateLocation { get; set; }
       public List<RealEstatePropertyModel> RealEstateProperty { get; set; }
    }
}
