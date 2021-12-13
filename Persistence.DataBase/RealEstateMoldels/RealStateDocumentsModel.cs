using System;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealStateDocumentsModel
    {
        [Key]
        public Int64 RealStateDocumentsID { get; set; }
        public string FileName { get; set; }
        public string FilePath  { get; set; }
        public Int64 RealEstateRegistryID { get; set; }

        public Int64 ReferenceID{ get; set; }
        public RealEstateRegistryModel RealEstateRegistry { get; set; }

        public int RealStateDocumentsTypeID { get; set; }
        public RealStateDocumentsTypeModel RealStateDocumentsType { get; set; }
        public int RealEstateDocumentSourceID { get; set; }
        public RealEstateDocumentSource RealEstateDocumentSource { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
