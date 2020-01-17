using Newtonsoft.Json;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    public class OrgsDistributionGroupDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }
    }

    public class DistributionGroupModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}
