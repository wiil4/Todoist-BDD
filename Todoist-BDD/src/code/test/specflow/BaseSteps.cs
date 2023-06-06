
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Todoist_BDD.src.code.page;
using Todoist_BDD.src.code.session;

namespace Todoist_BDD.src.code.test.specflow
{
    [Binding]
    public class BaseSteps
    {
        protected MainPage mainPage = new MainPage();
        protected LogInPage logInPage = new LogInPage();
        protected ProjectsSection projectsSection = new ProjectsSection();

        protected void LogIn(string email, string password)
        {            
            mainPage.logInButton.Click();
            logInPage.LogIn(email, password);
            Thread.Sleep(5000);
        }

        public void OpenBrowser()
        {
            Session.Instance().GetBrowser().Navigate().GoToUrl("https://todoist.com/");
            Thread.Sleep(1000);
        }

        public void CloseBrowser()
        {
            Session.Instance().CloseBrowser();
        }

        public void RemoveOverlay()
        {
            /*IWebDriver driver = Session.Instance().GetBrowser();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Define the condition function to check if the overlay is present
            Func<IWebDriver, bool> overlayCondition = (d) =>
            {
                try
                {
                    // Locate the overlay element
                    IWebElement overlay = driver.FindElement(By.CssSelector("div.GB_overlay"));
                    // Check if the overlay element is visible or not present
                    return !overlay.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // If the overlay element is not found, consider it as not present
                    return true;
                }
            };

            // Wait until the overlay is not present (disappeared)
            wait.Until(overlayCondition);*/

            IWebElement overlay = Session.Instance().GetBrowser().FindElement(By.CssSelector("div.GB_overlay"));

            // Execute JavaScript to remove the overlay element from the DOM
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Session.Instance().GetBrowser();
            jsExecutor.ExecuteScript("arguments[0].remove();", overlay);
        }
    }
}
