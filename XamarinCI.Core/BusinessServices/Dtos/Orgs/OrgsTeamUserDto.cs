using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    public class OrgsTeamUserDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
