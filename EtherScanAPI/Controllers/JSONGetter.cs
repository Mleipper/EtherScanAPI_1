using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EtherScanAPI.Controllers
{
    public class JSONGetter
    {

        public JSONGetter()
        {

        }
        public enum httpVerbs
        {
            GET,
            PUT,
            POST,
            DELETE
        }

        public httpVerbs httpMethod { get; set; }

        /// <summary>
        /// makes a http GET request to the provided endpoint 
        /// </summary>
        /// <param name="endPoint">The URI for the API method</param>
        /// <returns>String response value</returns>
        public string makeRequest(string endPoint)
        {
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code " + response.StatusCode.ToString());
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }// end of stream reader 
                    }
                }//end of use of responseStream 
            }
            return strResponseValue;
        }
    }
}
