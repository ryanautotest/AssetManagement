using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace SeleniumFramework.APICore
{
    public class APIResponse 
    {
        public HttpWebResponse response;

        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }
        public APIResponse(HttpWebResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }

        private string GetResponseBody()
        {
            responseBody = "";
            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
            return responseBody;
            }
        }
        
        private string GetResponseStatusCode()
        {
            try
            {
                HttpStatusCode statusCode = ((HttpWebResponse)response).StatusCode;
                responseStatusCode = statusCode.ToString();
            }
            catch (WebException we)
            {
                responseStatusCode = ((HttpWebResponse)we.Response).StatusCode.ToString();

            }
            return responseStatusCode;
        }
    }
}
