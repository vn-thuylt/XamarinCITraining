using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    #region GET Methods
    public class Owner
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class OrgsAppsDto
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

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("azure_subscription")]
        public object AzureSubscription { get; set; }

        [JsonProperty("member_permissions")]
        public IList<string> MemberPermissions { get; set; }
    }
    #endregion GET Methods

    #region POST Methods
    public class AppsModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("release_type")]
        public string ReleaseType { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }
    }

    public class CreateAppsModel
    {
        public string description { get; set; }
        public string release_type { get; set; }
        public string display_name { get; set; }
        public string name { get; set; }
        public string os { get; set; }
        public string platform { get; set; }
    }
    #endregion POST Methods
}
