using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todoist_BDD.src.code.factoryBrowser
{
    public interface IBrowser
    {
        IWebDriver Create();
    }
}
