using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Web
{
    public class BackCentralUsdDto
    {
     
            public Result result { get; set; }
            public IList<string> targetUrl { get; set; }
            public bool success { get; set; }
            public IList<string> error { get; set; }
            public bool unAuthorizedRequest { get; set; }
            public bool __abp { get; set; }

        
    }
    public class Result
    {
        public double actualPurchaseValue { get; set; }
        public double actualPurchaseInteranualValue { get; set; }
        public double actualPurchaseAccumulatedValue { get; set; }
        public double actualSellingValue { get; set; }
        public double actualSellingInteranualValue { get; set; }
        public double actualSellingAccumulatedValue { get; set; }
        public DateTime date { get; set; }
        public string actualPurchaseInteranualValueFormatted { get; set; }
        public string actualPurchaseAccumulatedValueFormatted { get; set; }
        public string actualPurchaseValueFormatted { get; set; }
        public string actualSellingInteranualValueFormatted { get; set; }
        public string actualSellingAccumulatedValueFormatted { get; set; }
        public string actualSellingValueFormatted { get; set; }

    }
}
