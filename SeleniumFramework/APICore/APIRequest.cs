using System;
using System.IO;
using System.Net;
using System.Text;
using SeleniumFramework.APICore;
using SeleniumFramework.Reporter;

namespace SeleniumFramework.APICore
{
    public class APIRequest
    {
        public HttpWebRequest request;
        public string url { get; set; }
        public string requestBody { get; set; }
        public string formData { get; set; }

        public APIRequest SetUrl(string url)
        {
            this.url = url;
            request = (HttpWebRequest)WebRequest.Create(url);
            return this;
        }

        public APIRequest()
        {
            url = "";
            requestBody = "";
            formData = "";
        }
        public APIRequest(string baseUrl)
        {
            this.url = baseUrl;
            requestBody = "";
            formData = "";
        }

        public APIRequest AddHeader(string key, string value)
        {
            request.Headers.Add(key, value);
            return this;
        }

        public APIRequest SetRequestParameter(string key, string value)
        {
            if (url.Contains("?"))
            {
                url += "?" + key + "=" + value;
            }
            else
            {
                url += "&" + key + "=" + value;
            }
            return this;
        }

        public APIRequest AddFormData(string key, string value)
        {
            if (formData.Equals("") || formData == null)
            {
                formData += key + "=" + value;
            }
            else if (!formData.Equals(""))
            {
                formData += "&" + key + "=" + value;
            }
            return this;
        }

        public APIRequest SetBody(string body)
        {
            this.requestBody = body;
            return this;
        }

        /*-------------------HTTP CLIENT
        private HttpMethod CreateHttpMethod(string method)
        {
            switch (method.ToUpper())
            {
                case "GET":
                    return HttpMethod.Get;
                case "POST":
                    return HttpMethod.Post;
                case "HEAD":
                    return HttpMethod.Head;
                case "DELETE":
                    return HttpMethod.Delete;
                case "OPTIONS":
                    return HttpMethod.Options;
                default:
                    throw new NotImplementedException();
            }
        }
        */

        /*-------SEND REQUEST------*/

        public APIResponse Get()
        {
            request.Method = "GET";
            APIResponse response = SendRequest();
            return response;
        }

        public APIResponse Post()
        {
            request.Method = "POST";
            APIResponse response = SendRequest();
            return response;
        }

        public APIResponse Put()
        {
            request.Method = "PUT";
            APIResponse response = SendRequest();
            return response;
        }

        public APIResponse Head()
        {
            request.Method = "HEAD";
            APIResponse response = SendRequest();
            return response;
        }

        public APIResponse Delete()
        {
            request.Method = "DELETE";
            APIResponse response = SendRequest();
            return response;
        }
        public APIResponse SendRequest()
        {
            if (request.Method == "GET")
            {
                requestBody = null;
            }
            else
            {
                if (requestBody != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
                if (!formData.Equals("."))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
            }
            try
            {
                IAsyncResult asyncResult = request.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                var httpResponse = (HttpWebResponse)request.EndGetResponse(asyncResult);
                APIResponse response = new APIResponse(httpResponse);
                HtmlReport.CreateAPIRequestLog(this, response);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}