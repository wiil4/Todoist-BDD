using System;
using TechTalk.SpecFlow;

namespace Todoist_BDD.src.code.test.specflow
{
    [Binding]
    [Scope(Tag = "update-project-name")]
    public class UpdateProjectNameStepDefinitions : BaseSteps
    {
        string newProjectName = string.Empty;

        [Given(@"I am correctly logged in")]
        public void GivenIAmCorrectlyLoggedIn()
        {
            OpenBrowser();
            LogIn("willcorreos@gmail.com", "todoisttest");
        }

        [When(@"I hover on project with name ""([^""]*)""")]
        public void WhenIHoverOnProjectWithName(string projectName)
        {
            projectsSection.HoverOnCreatedProject("MojixProject");
            Thread.Sleep(1000);
        }

        [When(@"I right click on it")]
        public void WhenIRightClickOnIt()
        {
            projectsSection.optionsButton.RightClick();
        }

        [When(@"I click on edit project button")]
        public void WhenIClickOnEditProjectButton()
        {
            projectsSection.editProjectButton.Click();
        }

        [When(@"I change the project name to ""([^""]*)""")]
        public void WhenIChangeTheProjectNameTo(string projectName)
        {
            newProjectName = projectName;
            projectsSection.projectNameTxtbox.SetText(newProjectName);
            projectsSection.submitButton.Click();
            Thread.Sleep(1000);
        }

        [Then(@"I expect the project name changed in projects list")]
        public void ThenIExpectTheProjectNameChangedInProjectsList()
        {
            Assert.That(projectsSection.ProjectNameDisplayed(newProjectName), Is.True, "Error! project name was not changed");
            CloseBrowser(); 
        }
    }
}
