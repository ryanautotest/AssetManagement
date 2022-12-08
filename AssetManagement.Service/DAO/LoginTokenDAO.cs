using Newtonsoft.Json;

namespace AssetManagement.Service.DAO
{
    public class LoginTokenDAO
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("isFirstTimeLogin")]
        public bool IsFirstTimeLogin { get; set; }
    }
}
