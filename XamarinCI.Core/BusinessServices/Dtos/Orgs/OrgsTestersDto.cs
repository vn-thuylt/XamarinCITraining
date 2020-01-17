using Newtonsoft.Json;
using System;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    public class OrgsTestersDto
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
