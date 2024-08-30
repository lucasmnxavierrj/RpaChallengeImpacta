using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RpaChallengeImpacta.Crawler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http.Json;

namespace RpaChallengeImpacta.Crawler.UseCases.ProxyCases
{
    internal static class GetProxyDataFromProxyScape
    {
        private static readonly string _siteUrl = "https://pt-br.proxyscrape.com/lista-de-procuradores-gratuitos";
        public static async Task<List<ProxyDto>> Run()
        {
            try
            {
                using var driver = new ChromeDriver();

                driver.Navigate().GoToUrl(_siteUrl);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                var jsonButton = wait.Until(driver =>
                    driver.FindElement(By.XPath("//button[small[text()='json']]"))
                );

                ScrollToElement(driver, jsonButton);

                jsonButton.Click();

                var downloadButton = wait.Until(driver =>
                    driver.FindElement(By.XPath("//button[small[text()='Download']]")));
                downloadButton.Click();

                await Task.Delay(3000);

                var fileData = GetFileData();

                return fileData;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        #region Private Methods
        private static List<ProxyDto> GetFileData()
        {
            try
            {
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

                return fileContentDto;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        private static void ScrollToElement(IWebDriver driver, IWebElement webElement)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }
        #endregion
    }
}
