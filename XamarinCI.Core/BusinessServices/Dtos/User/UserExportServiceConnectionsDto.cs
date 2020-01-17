using Newtonsoft.Json;

namespace XamarinCI.Core.BusinessServices.Dtos.User
{
    public class UserExportServiceConnectionsDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("credentialType")]
        public string CredentialType { get; set; }

        [JsonProperty("isValid")]
        public bool IsValid { get; set; }

        [JsonProperty("is2FA")]
        public bool Is2FA { get; set; }
    }
}
