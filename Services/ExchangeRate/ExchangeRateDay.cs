using Persistence.DataBase.RealEstateMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExchangeRate
{
    public class ExchangeRateDay : IExchangeRateDay
    {
        public List<ExchangeRateDayModel> CurrencyList()
        {
            throw new NotImplementedException();
        }

        public List<ExchangeRateDayModel> CurrencyListByRange(DateTime start, DateTime End)
        {
            throw new NotImplementedException();
        }

        public decimal GetCurrency()
        {
            throw new NotImplementedException();
        }
    }
}
