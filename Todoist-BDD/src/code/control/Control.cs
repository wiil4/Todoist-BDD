using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoist_BDD.src.code.session;

namespace Todoist_BDD.src.code.control
{
    public class Control
    {
        protected By locator;
        protected IWebElement control;

        public Control(By locator)
        {
            this.locator = locator;
        }

        protected void FindControl()
        {
            control = Session.Instance().GetBrowser().FindElement(locator);
        }

        public void Click()
        {
            FindControl();
            control.Click();
        }

        public bool IsControlDisplayed()
        {
            try
            {
                FindControl();
                return control.Displayed;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public string GetAttribute(string attributeName)
        {
            FindControl();
            return control.GetAttribute(attributeName);
        }
    }
}
