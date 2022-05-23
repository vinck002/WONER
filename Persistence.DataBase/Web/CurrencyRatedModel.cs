using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.Web
{
    public  class CurrencyRatedModel
    {

        [Key]
        public int ID { get; set; }
        public string CurrencyName { get; set; }
        public decimal Price { get; set; }
        public DateTime dateCheck { get; set; } 


         
    }
}
