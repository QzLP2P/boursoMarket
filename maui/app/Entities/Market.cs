using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace app.Entities
{
    public class Market
    {
        [JsonPropertyName("codeSupport")]
        public string CodeSupport { get; set; }

        [JsonPropertyName("libelleSupport")]
        public string LibelleSupport { get; set; }

        [JsonPropertyName("codeISIN")]
        public string CodeISIN { get; set; }

        [JsonPropertyName("url")]
        public string URL { get; set; }
    }
}
