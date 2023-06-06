using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todoist_BDD.src.code.factoryBrowser
{
    public class Chrome : IBrowser
    {
        public IWebDriver Create()
        {
            string chromeDriverPath = string.Empty;
            #region //GITHUBACTIONS
            chromeDriverPath = $"/usr/local/bin";
            #endregion

            #region //LOCALLY
            //chromeDriverPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            #endregion

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--headless");            
            IWebDriver driver = new ChromeDriver(chromeDriverPath, chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
