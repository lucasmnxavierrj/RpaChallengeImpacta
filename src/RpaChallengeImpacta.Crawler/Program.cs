using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.Json;
using RpaChallengeImpacta.Crawler.Models;


using var driver = new ChromeDriver();

driver.Navigate().GoToUrl("https://pt-br.proxyscrape.com/lista-de-procuradores-gratuitos");

var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

var jsonButton = wait.Until(driver =>
    driver.FindElement(By.XPath("//button[small[text()='json']]"))
);

// Scroll the element into view
IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
js.ExecuteScript("arguments[0].scrollIntoView(true);", jsonButton);

await Task.Delay(3000);

jsonButton.Click();

var downloadButton = wait.Until(driver =>
    driver.FindElement(By.XPath("//button[small[text()='Download']]")));
downloadButton.Click();

var downloadDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
    
var directoryInfo = new DirectoryInfo(downloadDir);

var downloadedFile = directoryInfo
    .GetFiles()
    .Where(file => file.Name.Contains("proxies"))
    .OrderByDescending(x => x.LastWriteTime)
    .FirstOrDefault();

var fileContentString = File.ReadAllText(downloadedFile.FullName);

JsonElement proxiesElement = JsonDocument.Parse(fileContentString).RootElement.GetProperty("proxies");

var fileContentDto = JsonSerializer.Deserialize<List<ProxyDto>>(proxiesElement.GetRawText());

