using Newtonsoft.Json;

namespace XamarinCI.Core.BusinessServices.Dtos.Apps
{
    public class DistributionGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}
