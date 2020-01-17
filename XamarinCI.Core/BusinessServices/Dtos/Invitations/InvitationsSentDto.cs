using Newtonsoft.Json;

namespace XamarinCI.Core.BusinessServices.Dtos.Invitations
{
    public class InvitationsSentDto
    {
        [JsonProperty("invitation_date")]
        public string InvitationDate { get; set; }

        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("sent_to")]
        public string SentTo { get; set; }
    }
}
