using APICore.APIClient;
using AssetManagement.Service.DAO;
using SeleniumFramework.Utilities;
using AssetManagement.Resources;

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
            var listAccount = ReadData.GetListDataFromJsonFile<AdminDAO>("Resources\\TestData\\adminAccount.json");
            AdminDAO account = listAccount[0];
            apiClient.SetBearerAuthorization(account.Token);

            AdminDAO adminDAO = new AdminDAO
            {
                UserName = account.UserName,
                Password = account.Password,
            };

            var response = await apiClient.Post(Constants.api_host + loginadminpath, admindao);

            if (response.statuscode != httpstatuscode.ok)
            {
                return false;
            }

            return true;
        }

        /*public APIResponse LoginAsAdminRequest(string username, string password)
        {
            APIResponse response = new APIRequest()
                .SetUrl(Constants.API_HOST + createAdminPath)
                .AddHeader("Content-Type", "application/json")
                .AddFormData("username", username)
                .AddFormData("password", password)
                .Post();
            return response;
        }*/

        /*
        public APIResponse DisableAdminAccount(string username)
        {
            string disablePath = string.Format(deleteAdminPath, username);
            APIResponse response = new APIRequest()
                .SetUrl(Constants.API_HOST + disablePath)
                .Post();
            return response;
        }*/

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
