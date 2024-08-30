using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RpaChallengeImpacta.Crawler.Models
{
    public class ProxyDto
    {
        [JsonPropertyName("protocol")]
        public string ProtocolType { get; set; }

        [JsonPropertyName("ip")]
        public string IpAddress { get; set; }

        [JsonPropertyName("port")]
        public int Port { get; set; }

        [JsonPropertyName("ip_data.country")]
        public string Country { get; set; }

        [JsonPropertyName("anonymity")]
        public string Anonymity { get; set; }

        [JsonPropertyName("ssl")]
        public bool IsHttps { get; set; }
        
        [JsonPropertyName("timeout")]
        public double Latency { get; set; }

        [JsonPropertyName("last_seen")]
        public double LastChecked { get; set; }
    }
}
