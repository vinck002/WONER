using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateRegOwneInfoModel
    {
        [Key]
        public Int64 RealEstateRegOwneInfoID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Address { get; set; }

        [MaxLength(30)]
        public string DocumentID { get; set; }

        public Int64 RealEstateRegistryID { get; set; }
        public RealEstateRegistryModel RealEstateRegistry { get; set; }




    }
}
