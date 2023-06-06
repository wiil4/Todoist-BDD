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
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string chromeDriverPath = $"{path}/Todoist-BDD/Todoist-BDD/src/resources/driver/chromedriver.exe";
            //string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var chromeOptions = new ChromeOptions();
            /*chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--no-sandbox");*/
            IWebDriver driver = new ChromeDriver(chromeDriverPath, chromeOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
