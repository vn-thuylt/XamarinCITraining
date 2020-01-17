using Newtonsoft.Json;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    public class OrgsAadGroupsDto
    {
        [JsonProperty("aad_group_id")]
        public string AadGroupId { get; set; }

        [JsonProperty("azure_aad_group_id")]
        public string AzureAadGroupId { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}
