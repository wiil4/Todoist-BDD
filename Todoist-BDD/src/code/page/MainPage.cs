using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoist_BDD.src.code.control;

namespace Todoist_BDD.src.code.page
{
    public class MainPage
    {
        public Button logInButton = new Button(By.XPath("//li/a[contains(@href,'login')]"));
    }
}
