using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todoist_BDD.src.code.session;

namespace Todoist_BDD.src.code.test.rawTests
{
    public class BaseTest
    {
        //[SetUp]
        public void OpenBrowser()
        {
            Session.Instance().GetBrowser().Navigate().GoToUrl("https://todoist.com/");
        }

        //[TearDown]
        public void CloseBrowser()
        {
            Session.Instance().CloseBrowser();
        }
    }
}
