using Persistence.DataBase.RealEstateMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.Owner.Dto
{
    public class InitialConfigProcessDto
    {
        public IList<RealEstatePropertyTypeModel> realEstatePropertyTypeModels { get; set; }
        public RealEstateConfig RealEstateConfig { get; set; }
    }
}
