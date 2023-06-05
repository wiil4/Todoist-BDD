using System;
using TechTalk.SpecFlow;

namespace Todoist_BDD.src.code.test.specflow
{
    [Binding]
    [Scope(Tag = "project-deletion")]
    public class ZDeleteProjectStepDefinitions : BaseSteps
    {
        string projectName = string.Empty;

        [Given(@"I am correctly logged in")]
        public void GivenIAmCorrectlyLoggedIn()
        {
            LogIn("willcorreos@gmail.com", "todoisttest");
        }

        [When(@"I hover on project with name ""([^""]*)""")]
        public void WhenIHoverOnProjectWithName(string projectName)
        {
            this.projectName = projectName;
            projectsSection.HoverOnCreatedProject(this.projectName);
            Thread.Sleep(1000);
        }

        [When(@"I right click on it")]
        public void WhenIRightClickOnIt()
        {
            projectsSection.optionsButton.RightClick();
        }

        [When(@"I click on delete project button")]
        public void WhenIClickOnDeleteProjectButton()
        {
            projectsSection.deleteButton.Click();
        }

        [When(@"I confirm the project deletion")]
        public void WhenIConfirmTheProjectDeletion()
        {
            projectsSection.submitButton.Click();
        }

        [Then(@"I expect the project to be deleted")]
        public void ThenIExpectTheProjectToBeDeleted()
        {
            Assert.That(projectsSection.ProjectNameDisplayed(projectName), Is.False, "ERROR! project was not deleted");
        }
    }
}
