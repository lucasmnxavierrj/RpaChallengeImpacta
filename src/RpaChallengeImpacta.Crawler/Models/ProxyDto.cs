using RpaChallengeImpacta.Domain.Enumerators;
using RpaChallengeImpacta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        [JsonPropertyName("ip_data")]
        public IpDataDto IpData { get; set; }

        [JsonPropertyName("anonymity")]
        public string Anonymity { get; set; }

        [JsonPropertyName("ssl")]
        public bool IsHttps { get; set; }
        
        [JsonPropertyName("timeout")]
        public double Latency { get; set; }

        [JsonPropertyName("last_seen")]
        public double LastChecked { get; set; }

        public Proxy DtoToEntity()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                ProtocolType = ProtocolType switch
                {
                    "http" => EProtocolType.Http,
                    "socks4" => EProtocolType.Socks4,
                    "socks5" => EProtocolType.Socks5,
                    _ => throw new Exception("Unexpected protocol type")
                },
                IpAddress = IpAddress,
                Port = Port.ToString(),
                Country = IpData?.Country ?? "Unknown",
                Anonymity = Anonymity switch
                {
                    "elite" => EAnonymity.Elite,
                    "anonymous" => EAnonymity.Anonymous,
                    "transparent" => EAnonymity.Transparent,
                    _ => throw new Exception("Unexpected anonymity type")
                },
                IsHttps = IsHttps switch
                {
                    true => ETrueFalse.True,
                    false => ETrueFalse.False,
                },
                Latency = $"{double.Round(Latency)}ms",
                LastChecked = 0,
            };
        }

    }
}
