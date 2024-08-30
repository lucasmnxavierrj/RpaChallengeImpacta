using RpaChallengeImpacta.Crawler.Models;
using RpaChallengeImpacta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RpaChallengeImpacta.Crawler.UseCases.ProxyCases
{
    internal static class SaveProxyDataIntoDatabase
    {
        public static async Task<bool> Save(List<ProxyDto> proxyDtos)
        {
            try
            {
                var proxyEntities = new List<Proxy>();

                foreach (var proxyDto in proxyDtos)
                    proxyEntities.Add(proxyDto.DtoToEntity());

                using var client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:<API_PORT>");

                var response = await client.PostAsJsonAsync("/api/data", proxyEntities);

                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
    }
}
