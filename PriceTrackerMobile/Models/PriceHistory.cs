using System;
using System.Collections.Generic;

namespace PriceTrackerMobile.Models
{
    public class PriceHistory
    {
        public string _id { get; set; }
        public int steam_appid { get; set; }
        public List<int> priceInitial { get; set; }
        public List<DateTime> dateInitial { get; set; }
        public List<int> priceFinal { get; set; }
        public List<DateTime> dateFinal { get; set; }
    }
}
