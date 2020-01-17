using Newtonsoft.Json;
using System;

namespace XamarinCI.Core.BusinessServices.Dtos.Apps
{
    public class AppsTransferOwnership
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("app_secret")]
        public string AppSecret { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("release_type")]
        public string ReleaseType { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("azure_subscription")]
        public object AzureSubscription { get; set; }
    }

}
