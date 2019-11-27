using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserChecker.Models
{
    public class Signature
    {
        [JsonProperty(PropertyName = "sig_key")]
        public string SigKey { get; set; }

        [JsonProperty(PropertyName = "template_id")]
        public string TemplateId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "promo_id")]
        public string PromoId { get; set; }

        [JsonProperty(PropertyName = "date_created")]
        public string DateCreated { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}