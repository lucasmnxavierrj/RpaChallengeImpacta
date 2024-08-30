using RpaChallengeImpacta.Crawler.UseCases.ProxyCases;

var proxyData = await GetProxyDataFromProxyScape.Run();

var success = await SaveProxyDataIntoDatabase.Save(proxyData);

if (success)
    Console.WriteLine("Data stored successfully");
else
    Console.WriteLine("Something went wrong, try debugging");



