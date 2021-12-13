using Persistence.DataBase.RealEstateMoldels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealStateDocumentsTypeModel
    {
        [Key]
        public int RealStateDocumentsTypeID { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }
        public int Active { get; set; }
        public ICollection<RealStateDocumentsModel> RealStateDocuments { get; set; }
    }
}
