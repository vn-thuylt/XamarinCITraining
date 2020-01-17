using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XamarinCI.Core.BusinessServices.Dtos.Orgs
{
    public class OrgsDistributionGroupMemberDto
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
    }

    public class MembersInGroup
    {
        [JsonProperty("user_emails")]
        public IList<string> UserEmails { get; set; }
    }

    public class AcceptUserResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("invite_pending")]
        public bool InvitePending { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("user_email")]
        public string UserEmail { get; set; }
    }
}
