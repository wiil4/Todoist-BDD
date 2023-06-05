using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todoist_BDD.src.code.factoryBrowser
{
    public class FactoryBrowser
    {
        public static IBrowser Make(string type)
        {
            IBrowser browser = null;
            switch (type)
            {
                case "chrome":
                    browser = new Chrome();
                    break;
                case "edge":
                    browser = new Edge();
                    break;
                case "firefox":
                    browser = new Firefox();
                    break;
            }
            return browser;
        }
    }
}
