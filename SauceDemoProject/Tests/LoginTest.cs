using SauceDemoProject.PageObjects;

namespace SauceDemoProject.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private string user = (Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
        private string pass = (Environment.GetEnvironmentVariable("SAUCE_CLAVE", EnvironmentVariableTarget.User));
        private LoginPage login;

        [Test]
        [Description("This test is going to fail")]
        public void LogIn()
        {
            login = new LoginPage(Driver);
            login.LogIn(user, pass);
            Assert.IsTrue((Driver.Title.Equals("Swag Labs")),"Error when trying to open the Inventory page");
            
        }

        [Test]
        public void SubmitEmptyForm()
        {
            login = new LoginPage(Driver);
            userActs.clickOn(login.LoginButton);
            Assert.IsTrue((login.EmptyErrorMessage().Equals("Epic sadface: Username is required")),"Error message espected is wrong");
        }
    }
}
