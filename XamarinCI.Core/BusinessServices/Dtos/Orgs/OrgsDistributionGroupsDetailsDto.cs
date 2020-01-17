using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    public class App
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("app_secret")]
        public string AppSecret { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

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
        public object IconUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("release_type")]
        public object ReleaseType { get; set; }
    }

    public class OrgsDistributionGroupsDetailsDto
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

        [JsonProperty("total_apps_count")]
        public int TotalAppsCount { get; set; }

        [JsonProperty("total_users_count")]
        public int TotalUsersCount { get; set; }

        [JsonProperty("apps")]
        public IList<App> Apps { get; set; }
    }
}
