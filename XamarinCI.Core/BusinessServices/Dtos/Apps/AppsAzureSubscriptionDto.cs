using Newtonsoft.Json;

namespace XamarinCI.Core.BusinessServices.Dtos.Apps
{
    public class AppsAzureSubscriptionDto
    {
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        [JsonProperty("tenant_id")]
        public string TenantId { get; set; }

        [JsonProperty("subscription_name")]
        public string SubscriptionName { get; set; }

        [JsonProperty("is_billing")]
        public bool IsBilling { get; set; }

        [JsonProperty("is_billable")]
        public bool IsBillable { get; set; }

        [JsonProperty("is_microsoft_internal")]
        public bool IsMicrosoftInternal { get; set; }
    }
}
