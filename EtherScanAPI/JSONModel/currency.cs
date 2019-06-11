using System;
using System.Collections.Generic;
using System.Text;

namespace EtherScanAPI.JSONModel
{
    public class Currency
    {
        public bool success { get; set; }
        public int timestamp { get; set; }
        public string _base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }

        public class Rates
        {
            public double USD { get; set; }
            public double GBP { get; set; }
            public double CAD { get; set; }
            public double CNY { get; set; }
            public double AUD { get; set; }
            public double JPY { get; set; }
        }



    }
}
