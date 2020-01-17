using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XamarinCI.Core.BusinessServices.Dtos.Apps
{
    public class AppsUserDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public object AvatarUrl { get; set; }

        [JsonProperty("can_change_password")]
        public bool CanChangePassword { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("permissions")]
        public IList<string> Permissions { get; set; }
    }
}
