using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SauceDemoProject.Actions
{
    public class UserActions
    {
        public IWebDriver driver;
        public UserActions(IWebDriver d )
        {
            driver = d;
        }


        /// <summary>
        /// Stops the execution for the amount of seconds specified. By default it waits one second.
        /// </summary>
        public void sleep(double waitTime = 1) => Thread.Sleep(Convert.ToInt32(waitTime * 1000));

        public void WaitForTextToBePresent(IWebElement element, string text, int duration = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(duration));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }


        /// <summary>
        /// Erases the text on an element and writes parameter text on it.
        /// If forceClear is set to true, it will use alternative way to erase the data of
        /// the field.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="element"></param>
        public void write(string text, IWebElement element, bool forceClear = false)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    if (forceClear)
                    {
                        element.Click();
                        element.SendKeys(Keys.Control + "a");
                        element.SendKeys(Keys.Delete);
                    }
                    else
                    {
                        element.Clear();
                    }
                    element.SendKeys(text);
                    break;
                }
                catch (Exception ex)
                {
                    if (i < 9)
                    {
                        sleep();
                    }
                    else { throw ex; }
                }
            }
        }

        public void Go(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void clickOn(IWebElement element)
        {
            element.Click();
        }

    }
}

