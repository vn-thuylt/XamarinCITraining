using Newtonsoft.Json;
using System;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    public class OrgsUserDto
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class RoleChanged
    {
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
