using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
   public class RealEstateContactTypeModel
    {
        [Key]
        public int RealEstateContactTypeID { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }

        public ICollection<RealEstateContactInfoModel> RealEstateContactInfo { get; set; }


    }
}
