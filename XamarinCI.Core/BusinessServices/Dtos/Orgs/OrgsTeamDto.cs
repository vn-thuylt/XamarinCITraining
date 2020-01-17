using Newtonsoft.Json;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    public class OrgsTeamDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }
    }
}
