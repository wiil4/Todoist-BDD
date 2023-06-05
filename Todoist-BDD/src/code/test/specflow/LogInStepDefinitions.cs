using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Todoist_BDD.src.code.models;

namespace Todoist_BDD.src.code.test.specflow
{
    [Binding]
    public class LogInStepDefinitions : BaseSteps
    {
        string email = string.Empty;
        string password = string.Empty;
        LogInData logInData;

        [Given(@"A valid email and password")]
        public void GivenAValidEmailAndPassword(Table table)
        {
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
        }
    }
}
