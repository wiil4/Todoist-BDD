using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Todoist_BDD.src.code.session;

namespace Todoist_BDD.src.code.control
{
    public class Button : Control
    {
        public Button(By locator) : base(locator)
        {
        }

        public bool IsEnabled()
        {
            FindControl();
            return control.Enabled;
        }

        public void HoverOnButton()
        {
            FindControl();
            Actions hover = new Actions(Session.Instance().GetBrowser());
            hover.MoveToElement(control).Perform();
        }

        public void RightClick()
        {
            FindControl();
            Actions rightClick = new Actions(Session.Instance().GetBrowser());
            rightClick.ContextClick(control).Perform();
        }
    }
}
