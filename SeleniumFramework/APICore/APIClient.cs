using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace APICore.APIClient
{
    public class ApiClient
    {
        protected HttpClient httpClient;
        private JsonSerializerSettings settings;
        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
        public ApiClient()
        {
            this.httpClient = new HttpClient();
            this.settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
        public Uri BaseAddress
        {
            get { return httpClient.BaseAddress; }
            set { httpClient.BaseAddress = value; }
        }
        public TimeSpan Timeout
        {
            get { return httpClient.Timeout; }
            set { httpClient.Timeout = value; }
        }
        public void ClearHttpHeader(string headerName)
        {
            if (httpClient.DefaultRequestHeaders.Contains(headerName))
                httpClient.DefaultRequestHeaders.Remove(headerName);
        }
        public void SetHttpHeader(string headerName, string headerValue)
        {
            ClearHttpHeader(headerName);
            httpClient.DefaultRequestHeaders.Add(headerName, headerValue);
        }
        public void SetAuthorizationHeader(string authToken)
        {
            SetHttpHeader("Authorization", authToken);
        }
        public void SetBearerAuthorization(string authToken)
        {
            ClearHttpHeader("Authorization");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        }
       
        public async Task<HttpResponseMessage> Get(string requestUri)
        {
            HttpResponseMessage response = await this.httpClient.GetAsync(requestUri);
            return response;
        }
        public async Task<T> Get<T>(string requestUri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            string json = await response.Content.ReadAsStringAsync();
            var objectResult = JsonConvert.DeserializeObject<T>(json);
            return objectResult;
        }
        public async Task<T> Post<T>(string requestUri, object requestObj)
        {
            string json = JsonConvert.SerializeObject(requestObj, this.settings);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage response = await httpClient.PostAsync(requestUri, content);
            var result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), this.settings);
            return result;
        }

        public async Task<HttpResponseMessage> Delete(string requestUri, object requestObj)
        {
            string json = JsonConvert.SerializeObject(requestObj, this.settings);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri);
            requestMessage.Content = content;

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
            return response;
        }
        private void RemoveAuthHeader()
        {
            if (httpClient != null)
            {
                if (httpClient.DefaultRequestHeaders.Contains("auth"))
                    httpClient.DefaultRequestHeaders.Remove("auth");

                if (httpClient.DefaultRequestHeaders.Contains("Authorization"))
                    httpClient.DefaultRequestHeaders.Remove("Authorization");
            }
        }
        public async Task<T> Patch<T>(string requestUri, object requestObj)
        {
            string json = JsonConvert.SerializeObject(requestObj, this.settings);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage response = await httpClient.PatchAsync(requestUri, content);
            var result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), this.settings);
            return result;
        }
        public async Task<T> Put<T>(string requestUri, object requestObj)
        {
            string json = JsonConvert.SerializeObject(requestObj, this.settings);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage response = await httpClient.PutAsync(requestUri, content);
            var result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), this.settings);
            return result;
        }

       public async Task<HttpResponseMessage> Post(string requestUri, object requestObj)
        {
            string json = JsonConvert.SerializeObject(requestObj, this.settings);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            
            requestMessage.Content = content;
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
