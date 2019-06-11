using System;
using System.Collections.Generic;
using System.Text;

namespace EtherScanAPI.JSONModel
{
    // represents the JSON received from the transactions API 
    public class APINormalTransactionsModel : APIBASIC
    {
        public List<res> result {get;set;}

        public class res
        {
            public int blockNumber { get; set; }
            public long timeStamp { get; set; }
            public string hash { get; set; }
            public string nonce { get; set; }
            public string blockHash { get; set; }
            public string transactionIndex { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string value { get; set;  }
            public string gas { get; set; }
            public string gasPrice { get; set; }
            public int isError { get; set; }
            public int? txreceipt_status { get; set; }
            public string input { get; set; }
            public string contractAddress { get; set; }
            public string cumulativeGasUsed { get; set; }
            public string gasUsed { get; set; }
            public int confirmations { get; set; }
        }
    }
}
