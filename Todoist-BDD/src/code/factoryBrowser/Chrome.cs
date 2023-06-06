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
            //github actions
            string chromeDriverPath = $"/usr/local/bin";
            //locally
            //string chromeDriverPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--window-size=1366,768");
            //chromeOptions.AddArgument("--no-sandbox");
            IWebDriver driver = new ChromeDriver(chromeDriverPath, chromeOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
