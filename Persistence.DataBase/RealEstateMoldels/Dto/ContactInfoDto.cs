using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels.Dto
{
    public class ContactInfoDto
    {
        public Int64 RealEstateContactInfoID { get; set; }
      public string Description { get; set; }
      public int Extension { get; set; }
        public string Type { get; set; }
      public Int64 RealEstateContactTypeID { get; set; }
      public Int64 RealEstateRegistryID { get; set; }

    }
}
