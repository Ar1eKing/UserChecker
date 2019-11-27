using Newtonsoft.Json;

namespace UserChecker.Models
{
    public class SignatureRenderItem
    {
        [JsonProperty(PropertyName = "signature_id")]
        public string SignatureId { get; set; }

        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}