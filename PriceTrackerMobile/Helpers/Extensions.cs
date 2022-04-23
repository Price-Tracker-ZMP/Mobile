using System;
using System.Collections.Generic;

namespace PriceTrackerMobile.Helpers
{
    public static class Extensions
    {
        public static float[] ToArrayFloatPrices(this List<int> list)
        {
            float[] prices = new float[list.Count];

            for (int i = 0; i < list.Count; i++)
                prices[i] = (float)list[i] / 100;

            return prices;
        }

        public static string[] ToArrayStringDays(this List<DateTime> list)
        {
            string[] days = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
                days[i] = list[i].Day.ToString();

            return days;
        }
    }
}
