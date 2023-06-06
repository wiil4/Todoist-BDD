# Todoist-BDD

Todoist-BDD is a C# project that utilizes Selenium and SpecFlow for behavior-driven development. It also generates an Allure report.

##Allure report page
The Allure report for this project can be accessed at the following URL:
- [Todoist-BDD Allure Report](https://wiil4.github.io/Todoist-BDD/)

##About the functionality:
1. Update and Delete test cases are not currently working as CI due to unreachable elements:
  - To update an element, it is necessary to open a pop-up menu by right-clicking on the created project, but that pop-up menu is just reachable in some situations.

2. Please note that all test cases will work correctly if the project is cloned and the following changes are made in the code:
   - Comment out the GITHUBACTIONS REGION.
   - Uncomment the LOCALLY REGION.

```csharp
public class Chrome : IBrowser
    {
        public IWebDriver Create()
        {
            string chromeDriverPath = string.Empty;
            #region //GITHUBACTIONS
            chromeDriverPath = $"/usr/local/bin";
            #endregion

            #region //LOCALLY
            //chromeDriverPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            #endregion

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--headless");            
            IWebDriver driver = new ChromeDriver(chromeDriverPath, chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //driver.Manage().Window.Maximize();
            return driver;
        }
    }
```


