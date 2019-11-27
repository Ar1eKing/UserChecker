using Newtonsoft.Json;

namespace UserChecker.Models
{
    public class UserDetail
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}