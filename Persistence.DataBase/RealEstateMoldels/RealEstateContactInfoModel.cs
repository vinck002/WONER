using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateContactInfoModel
    {
        [Key]
        public Int64 RealEstateContactInfoID { get; set; }
        public string Description { get; set; }
        public int Extension { get; set; }
        public int Status { get; set; }
        

        public int RealEstateContactTypeID { get; set; }
        public RealEstateContactTypeModel RealEstateContactType { get; set; }
   

        public Int64 RealEstateRegistryID { get; set; }
        public RealEstateRegistryModel RealEstateRegistry { get; set; }
    }
}
