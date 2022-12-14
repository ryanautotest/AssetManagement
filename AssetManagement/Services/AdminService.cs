using APICore.APIClient;
using AssetManagement.DAO;
using SeleniumFramework.Utilities;
using AssetManagement.Resources;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace AssetManagement.Services
{
    public class AdminService
    {
        public string loginAdminPath = "/v1/auth/login";
        public string createAdminPath = "/v1/users";
        public string deleteAdminPath = "/v1/users/{0}/disable";

        private ApiClient apiClient;

        public AdminService()
        {
            this.apiClient = new ApiClient();
        }

        public async Task<bool> LoginAdmin()
        {
            var listAccount = ReadData.GetListDataFromJsonFile<AdminDAO>($"\\Resources\\TestData\\AdminAccount.json");
        
             AdminDAO account = listAccount[0];

            AdminDAO adminLogin = new AdminDAO
            {
                UserName = account.UserName,
                Password = account.Password,
            };
            apiClient.SetBearerAuthorization(account.Token);

            HttpResponseMessage responseLoginToken = await apiClient.Post(Constants.API_HOST + loginAdminPath, adminLogin);
            if (responseLoginToken.IsSuccessStatusCode)
            {
                using (var contentStream = await responseLoginToken.Content.ReadAsStreamAsync())
                {
                    var jsonReader = new JsonTextReader(new StreamReader(contentStream));
                    LoginTokenDAO loginTokenDAO = new LoginTokenDAO();
                }
                return true;
            }
            return false;
        }


        //public async Task<List<LoginTokenDAO>> LoginAdminAndGetToken(string username, string password)
        //{
        //    var account = ReadData.GetListDataFromJsonFile<AdminDAO>("Resources\\TestData\\adminaccount.json");
        //    List<LoginTokenDAO> responseToken = await apiClient.Post<List<LoginTokenDAO>>(Constants.API_HOST + loginAdminPath, account);
        //    return responseToken;
        //}

        //public async Task CreateNewAdmin(string token, string firstName, string lastName, 
        //    DateTimeOffset dob, DateTimeOffset joinDate, string gender, string type)
        //{
        //    var newAdminAccount = ReadData.GetListDataFromJsonFile<AdminDAO>("Resources\\TestData\\adminaccount.json");
        //    apiClient.SetBearerAuthorization(token);
        //    var responseUser = await apiClient.Post(Constants.API_HOST + createAdminPath, newAdminAccount.Add);
        //    return responseUser;
        //}
    }
}
