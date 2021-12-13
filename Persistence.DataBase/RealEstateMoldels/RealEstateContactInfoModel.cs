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
        public string Phone { get; set; }
        public int Extension { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        

        public int RealEstatePhoneTypeID { get; set; }
        public RealEstatePhoneTypeModel RealEstatePhoneType { get; set; }
   

        public Int64 RealEstateRegistryID { get; set; }
        public RealEstateRegistryModel RealEstateRegistry { get; set; }
    }
}
