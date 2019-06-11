using System;
using System.Collections.Generic;
using System.Text;

namespace EtherScanAPI.JSONModel
{
    public class APIStats: APIBASIC
    {

                 
        public Result result { get; set; }
        

        public class Result
        {
            public double ethbtc { get; set; }
            public int ethbtc_timestamp { get; set; }
            public double ethusd { get; set; }
            public int ethusd_timestamp { get; set; }
        }

    }
}
