using OpenQA.Selenium;
using SauceDemoProject.Actions;

namespace SauceDemoProject.PageObjects
{
    public class LoginPageLocators : BasePage
    {
        public LoginPageLocators(IWebDriver driver)
        {
            Driver = driver;
        }

        //Page elements for interaction
        public IWebElement UsernameField => Driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordField => Driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => Driver.FindElement(By.Id("login-button"));
        public IWebElement EmptyFormError => Driver.FindElement(By.CssSelector("h3[data-test='error']"));
        public IWebElement ErrorButton => Driver.FindElement(By.CssSelector(".error-button"));
        public IWebElement UserRedCross => Driver.FindElements(By.CssSelector("svg[class='svg-inline--fa fa-times-circle fa-w-16 error_icon'"))[0];
        public IWebElement PassRedCross => Driver.FindElements(By.CssSelector("svg[class='svg-inline--fa fa-times-circle fa-w-16 error_icon'"))[1];

    }
    public class LoginPage : LoginPageLocators
    {
        public static IWebDriver loginDriver;
       
        public LoginPage(IWebDriver driver) : base(driver)
        {
            loginDriver = driver;
        }

        public UserActions userActs = new UserActions(loginDriver);

        public void LogIn(string user, string pass)
        { 
            userActs.write(user, UsernameField);
            userActs.sleep();
            userActs.write(pass, PasswordField);
            userActs.clickOn(LoginButton);
        }

        public string EmptyErrorMessage()
        {
            return EmptyFormError.Text;
        }



    }

    
}
