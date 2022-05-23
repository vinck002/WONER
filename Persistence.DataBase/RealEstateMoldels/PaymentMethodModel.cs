using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
   public class PaymentMethodModel
    {
        [Key]
      public Int64 PaymentMethodID { get; set; }
      public string  Description { get; set; }
      public int Active { get; set; }


    }
}
