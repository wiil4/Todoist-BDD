using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoist_BDD.src.code.factoryBrowser;

namespace Todoist_BDD.src.code.session
{
    public class Session
    {
        public static Session instance;
        public IWebDriver browser;

        private string _browserName = "chrome";

        private Session()
        {
            browser = FactoryBrowser.Make(_browserName).Create();
        }

        public static Session Instance()
        {
            if(instance == null)
            {
                instance = new Session();
            }
            return instance;
        }

        public void CloseBrowser()
        {
            instance = null;
            browser.Quit();
        }

        public IWebDriver GetBrowser() => browser;
    }
}
