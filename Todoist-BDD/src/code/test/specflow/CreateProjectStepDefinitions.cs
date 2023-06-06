using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Todoist_BDD.src.code.session;

namespace Todoist_BDD.src.code.test.specflow
{
    [Binding]
    [Scope(Tag = "project-creation")]
    public class CreateProjectStepDefinitions : BaseSteps
    {
        [Given(@"I am correctly logged in")]
        public void GivenIAmCorrectlyLoggedIn()
        {
            OpenBrowser();
            LogIn("willcorreos@gmail.com", "todoisttest");
        }

        [When(@"I navigate to Projects")]
        public void WhenINavigateToProjects()
        {
            IWebDriver driver = Session.Instance().GetBrowser();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Define the condition function
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

            // Wait until the condition is met
            wait.Until(overlayCondition);

            // Wait for the projects button to become clickable
            wait.Until((d) =>
            {
                try
                {
                    // Check if the projects button is clickable
                    return projectsSection.projectsButton.IsEnabled() && projectsSection.projectsButton.IsControlDisplayed();
                }
                catch (StaleElementReferenceException)
                {
                    // If the projects button is no longer attached to the DOM, consider it as not clickable
                    return false;
                }
            });


            projectsSection.projectsButton.Click();
            projectsSection.addProjectButton.Click();
            Thread.Sleep(1000);

        }

        [When(@"I try to add a new project with name ""([^""]*)""")]
        public void WhenITryToAddANewProjectWithName(string projectName)
        {
            projectsSection.projectNameTxtbox.SetText(projectName);
        }

        [Then(@"I expect the Add button to be enabled")]
        public void ThenIExpectTheAddButtonToBeEnabled()
        {
            Assert.That(projectsSection.submitButton.IsEnabled(), Is.True, "Add Button is not enabled. Empty Fields");
        }

        [When(@"I click on Add button")]
        public void WhenIClickOnAddButton()
        {
            projectsSection.submitButton.Click();
            Thread.Sleep(1000);
        }

        [Then(@"I expect project to be displayed")]
        public void ThenIExpectProjectToBeDisplayed()
        {
            Assert.That(projectsSection.ProjectNameDisplayed("MojixProject"), Is.True, "Error! Project was not successfully created");
            CloseBrowser();
        }
    }
}
