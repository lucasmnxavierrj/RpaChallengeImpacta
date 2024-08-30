using RpaChallengeImpacta.Crawler.UseCases.ProxyCases;

var proxyData = await GetProxyDataFromProxyScape.Run();

await SaveProxyDataIntoDatabase.Save(proxyData);



