using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoist_BDD.src.code.page;

namespace Todoist_BDD.src.code.test.rawTests
{
    public class TodoistCRUDTest : BaseTest
    {
        MainPage mainPage = new MainPage();
        LogInPage logInPage = new LogInPage();
        ProjectsSection projectsSection = new ProjectsSection();

        private readonly string email = "willcorreos@gmail.com";
        private readonly string password = "todoisttest";

        //[Test]
        public void LoginTest()
        {
            LogInFeature();
            Assert.IsTrue(logInPage.IsInboxDisplayed(), "Error! Log In was not successful!");
        }

        //[Test]
        public void ProjectCreationTest()
        {
            LogInFeature();
            projectsSection.projectsButton.Click();
            projectsSection.addProjectButton.Click();
            Thread.Sleep(2000);
            projectsSection.projectNameTxtbox.SetText("MojixProject");
            Assert.That(projectsSection.submitButton.IsEnabled(), Is.True, "Error! Empty Fields");
            projectsSection.submitButton.Click();
            Thread.Sleep(2000);
            Assert.That(projectsSection.ProjectNameDisplayed("MojixProject"), Is.True, "Error! Project was not successfully created");
        }

        //[Test]
        public void UpdatingProjectNameTest()
        {
            LogInFeature();
            projectsSection.HoverOnCreatedProject("MojixProject");
            Thread.Sleep(2000);
            projectsSection.optionsButton.RightClick();
            projectsSection.editProjectButton.Click();
            projectsSection.projectNameTxtbox.SetText("Mojix1234");
            projectsSection.submitButton.Click();
            Thread.Sleep(2000);
            Assert.That(projectsSection.ProjectNameDisplayed("Mojix1234"), Is.True, "Error! project name was not changed");
        }

        //[Test]
        public void ZDeleteProjectTest()
        {
            LogInFeature();
            //Thread.Sleep(2000);
            projectsSection.HoverOnCreatedProject("Mojix1234");
            Thread.Sleep(2000);
            projectsSection.optionsButton.RightClick();
            projectsSection.deleteButton.Click();
            projectsSection.submitButton.Click();
            Assert.That(projectsSection.ProjectNameDisplayed("Mojix1234"), Is.False, "ERROR! project was not deleted");
        }

        private void LogInFeature()
        {
            mainPage.logInButton.Click();
            logInPage.LogIn(email, password);
        }
    }
}
