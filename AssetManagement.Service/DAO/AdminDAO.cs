using Newtonsoft.Json;

namespace AssetManagement.Service.DAO
{
    public class AdminDAO
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
