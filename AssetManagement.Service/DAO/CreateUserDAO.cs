using Newtonsoft.Json;

namespace AssetManagement.Service.DAO
{
    public partial class CreateUserDAO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("dob")]
        public DateTimeOffset Dob { get; set; }

        [JsonProperty("joinedDate")]
        public DateTimeOffset JoinedDate { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
