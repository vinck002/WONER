using System.ComponentModel.DataAnnotations;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateTransactionTypeModel
    {
        [Key]
        public int RealEstateTransactionTypeID { get; set; }
        public string Description { get; set; }

        [MaxLength(2)]
        public string Type { get; set; }
        public int Active { get; set; }


    }
}
