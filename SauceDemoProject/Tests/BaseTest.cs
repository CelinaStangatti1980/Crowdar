using OpenQA.Selenium;
using SauceDemoProject.Browsers;
using SauceDemoProject.Actions;
using SauceDemoProject.PageObjects;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;



namespace SauceDemoProject.Tests
{
    public  class BaseTest
    {
        protected IWebDriver Driver;

        protected string Url = "https://www.saucedemo.com";
        protected UserActions userActs;
        protected LoginPageLocators loginFields;
        protected string user;
        protected string pass;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void BeforeAll()
        {

        }

        [SetUp]
         public void BeforeBaseTest()
         {

               test = ReportManager.Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            
                Driver = (new CreateWebDriver()).CreateBrowser(BrowserType.Chrome);
                userActs = new UserActions(Driver);
                
                userActs.Go(Url);
                userActs.sleep(2);
                
         }
         [TearDown]
         public void AfterBaseTest()
         {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";

               switch (status)
                {
                    case TestStatus.Failed:
                        test.Fail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        test.AddScreenCaptureFromPath(Image.TakeScreenShot(Driver));
                        break;
                    case TestStatus.Skipped:
                        test.Skip("Test skipped!");
                        break;
                    default:
                        test.Pass("Test Executed Sucessfully!");
                        break;
                }
                if (Driver != null)
                {
                     Driver.Close();
                }
          }
        [OneTimeTearDown]
         public void CloseAll()
         {
             Driver.Quit();
             try
             {
                 ReportManager.Extent.Flush();
             }
             catch (Exception e)
             {
                 throw (e);
             }
         }
    }

}
