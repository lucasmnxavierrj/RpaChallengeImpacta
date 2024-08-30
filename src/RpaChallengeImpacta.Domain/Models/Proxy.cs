using RpaChallengeImpacta.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RpaChallengeImpacta.Domain.Models
{
    public class Proxy
    {
        public Proxy()
        {
            Id = Guid.NewGuid();
        }
        public Proxy(
            string protocolType, 
            string ipAddress, 
            int port, 
            string country, 
            string anonymity, 
            bool isHttps, 
            double latency, 
            double lastChecked)
        {
            Id = Guid.NewGuid();
            ProtocolType = protocolType switch
            {
                "http" => EProtocolType.Http,
                "socks4" => EProtocolType.Socks4,
                _ => throw new Exception("Unexpected protocol type")
            };
            IpAddress = ipAddress;
            Port = port.ToString();
            Country = country;
            Anonymity = anonymity switch
            {
                "elite" => EAnonymity.Elite,
                "anonymous" => EAnonymity.Anonymous,
                "transparent" => EAnonymity.Transparent,
                _ => throw new Exception("Unexpected anonymity type")
            };
            IsHttps = isHttps switch
            {
                true => ETrueFalse.True,
                false => ETrueFalse.False,
            };
            Latency = $"{double.Round(latency)}ms" ;
            LastChecked = 0;
        }
        public Guid Id { get; set; }
        public EProtocolType ProtocolType { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string Country { get; set; }
        public EAnonymity Anonymity { get; set; }
        public ETrueFalse IsHttps { get; set; }
        public string Latency { get; set; }
        public int LastChecked {  get; set; }
    }
}
