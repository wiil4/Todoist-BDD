using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Todoist_BDD.src.code.models;

namespace Todoist_BDD.src.code.test.specflow
{
    [Binding]
    [Scope(Tag ="logIn")]
    public class LogInStepDefinitions : BaseSteps
    {
        LogInData logInData = new LogInData();

        [Given(@"A valid email and password")]
        public void GivenAValidEmailAndPassword(Table table)
        {
            OpenBrowser();
            logInData = table.CreateInstance<LogInData>();
        }

        [When(@"I try to logIn")]
        public void WhenITryToLogIn()
        {
            LogIn(logInData.Email, logInData.Password);
        }

        [Then(@"I expect to be successfully LogedIn")]
        public void ThenIExpectToBeSuccessfullyLogedIn()
        {
            Assert.IsTrue(logInPage.IsInboxDisplayed(), "Error! Log In was not successful!");
            CloseBrowser();
        }
    }
}
