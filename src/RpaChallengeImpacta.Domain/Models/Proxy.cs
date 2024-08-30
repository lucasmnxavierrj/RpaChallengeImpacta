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
