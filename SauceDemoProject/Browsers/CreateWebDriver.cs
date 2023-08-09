using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SauceDemoProject.Browsers
{
    internal class CreateWebDriver
    {
        internal IWebDriver CreateBrowser(BrowserType name)
        {
            return name switch
            {
                BrowserType.Chrome => GetChromeDriver(),
                BrowserType.Edge => GetEdgeDriver(),
                BrowserType.Firefox => GetFirefoxDriver(),
                _ => throw new ArgumentOutOfRangeException(name.ToString(), $"No such browser {name.ToString()}")
            };
               
        }

        private IWebDriver GetFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized");

            new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
            return new FirefoxDriver(options);
        }

        private IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            return new ChromeDriver(options);
        }

        private IWebDriver GetEdgeDriver()
        {
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");

            new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
            return new EdgeDriver(options);
        }

    }
}
