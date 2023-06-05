using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoist_BDD.src.code.control;

namespace Todoist_BDD.src.code.page
{
    public class LogInPage
    {
        public TextBox userTxtBox = new TextBox(By.XPath("//input[@id='element-0']"));
        public TextBox pwdTxtBox = new TextBox(By.XPath("//input[@id='element-3']"));
        public Button logInButton = new Button(By.XPath("//form/button"));

        public void LogIn(string user, string pwd)
        {
            userTxtBox.SetText(user);
            pwdTxtBox.SetText(pwd);
            logInButton.Click();
        }

        public bool IsInboxDisplayed()
        {
            Button inboxButton = new Button(By.XPath("//li[@id='filter_inbox']//a"));
            return inboxButton.IsControlDisplayed();
        }
            
    }
}
