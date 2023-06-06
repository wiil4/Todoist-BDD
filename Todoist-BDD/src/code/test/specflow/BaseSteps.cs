﻿
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
    }
}