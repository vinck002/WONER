using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class ExchangeRateDayModel
    {
        [Key]
        public int IdCurrency { get; set; }
        public string CurrencyName { get; set; }
        public DateTime DateUpdate { get; set; }
        public decimal CurrencyPrice { get; set; }
    }
}
