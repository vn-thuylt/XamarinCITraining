using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinCI.Core.BusinessServices.Dtos.Apps
{
    public class AppsInvitation
    {
        public string user_email { get; set; }
        public string role { get; set; }
    }

    public class AllUserEmails
    {
        [JsonProperty("user_emails")]
        public IList<string> user_emails { get; set; }
    }

    public class InvitationPermission
    {
        [JsonProperty("permissions")]
        public IList<string> Permissions { get; set; }
    }
}
