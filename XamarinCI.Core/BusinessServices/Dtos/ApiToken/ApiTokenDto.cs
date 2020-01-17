using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XamarinCI.Core.BusinessServices.Dtos.ApiToken
{
    public class ApiTokenDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("scope")]
        public IList<string> Scope { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public class ApiTokenResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("api_token")]
        public string ApiToken { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("scope")]
        public IList<string> Scope { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public class ApiTokenModel
    {
        public string description { get; set; }
        public IList<string> scope { get; set; }
    }
}
