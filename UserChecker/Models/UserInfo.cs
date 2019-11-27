using Newtonsoft.Json;
using System.Collections.Generic;

namespace UserChecker.Models
{
    public class UserInfo
    {
        [JsonProperty(PropertyName = "wisestamp_uid")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "user")]
        public UserDetail UserDetail { get; set; }

        [JsonProperty(PropertyName = "signatures")]
        public Dictionary<string, Signature> Signatures { get; set; }

        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}