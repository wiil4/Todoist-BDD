using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoist_BDD.src.code.control;

namespace Todoist_BDD.src.code.page
{
    public class ProjectsSection
    {
        //CREATE PROJECT
        //public Button projectsButton = new Button(By.XPath("//div[@id='left_menu_inner']//a[contains(@href,'projects')]"));
        public Button projectsButton = new Button(By.XPath("//div[@id='left_menu_inner']/div//a[1]"));
        public Button addProjectButton = new Button(By.XPath("(//div[@id='left_menu_inner']//div/button)[1]"));
        public TextBox projectNameTxtbox = new TextBox(By.Id("edit_project_modal_field_name"));
        public Button submitButton = new Button(By.XPath("//form//button[@type='submit']"));

        //UPDATING PROJECT NAME
        public Button optionsButton = new Button(By.XPath("(//ul[@id='projects_list']/li//button)[last()]"));
        public Button editProjectButton = new Button(By.XPath("//ul[@role='menu']/li[4]"));

        //DELETING PROJECT
        public Button deleteButton = new Button(By.XPath("(//ul[@role='menu']/li)[last()]"));

        public void HoverOnCreatedProject(string pjName)
        {
            Button newProject = new Button(By.XPath($"(//ul[@id='projects_list']/li//span[text()='{pjName}'])[last()]"));
            newProject.HoverOnButton();
        }
        public bool ProjectNameDisplayed(string pjName)
        {
            Label pjLabel = new Label(By.XPath($"(//ul[@id='projects_list']/li//span[text()='{pjName}'])[last()]"));
            return pjLabel.IsControlDisplayed();
        }
    }
}
