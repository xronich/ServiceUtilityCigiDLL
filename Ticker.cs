using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceUtilityCigiDLL
{
    public static class Ticker
    {
        private static double endTime = 0.0;
        public static bool NeedUpdate
        {
            get
            {
                return endTime == nowTime();
            }
        } 

        private static double nowTime()
        {
            return Math.Round(DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds);
        }
    }
}
