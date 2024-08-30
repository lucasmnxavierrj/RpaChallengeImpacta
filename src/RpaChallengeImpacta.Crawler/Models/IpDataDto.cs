using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RpaChallengeImpacta.Crawler.Models
{
    public class IpDataDto
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
