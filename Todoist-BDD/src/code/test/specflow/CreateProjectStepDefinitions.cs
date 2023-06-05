using System;
using TechTalk.SpecFlow;

namespace Todoist_BDD.src.code.test.specflow
{
    [Binding]
    [Scope(Tag = "project-creation")]
    public class CreateProjectStepDefinitions : BaseSteps
    {
        [Given(@"I am correctly logged in")]
        public void GivenIAmCorrectlyLoggedIn()
        {
            LogIn("willcorreos@gmail.com", "todoisttest");
        }

        [When(@"I navigate to Projects")]
        public void WhenINavigateToProjects()
        {
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

        [When(@"I expect project to be displayed")]
        public void WhenIExpectProjectToBeDisplayed()
        {
            Assert.That(projectsSection.ProjectNameDisplayed("MojixProject"), Is.True, "Error! Project was not successfully created");
        }
    }
}
