using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoProject.Actions
{
    public class Image
    {
        
        public  static string TakeScreenShot(IWebDriver driver)
        {
            string screenShots_path;
            screenShots_path = ScreenShots_path() + FileName()+".png";
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(screenShots_path, ScreenshotImageFormat.Png);
            return screenShots_path;
        }

        public static string ScreenShots_path()
        {
          string fullPath = AppDomain.CurrentDomain.BaseDirectory;
          string screenShots_path = fullPath.Substring(0, fullPath.LastIndexOf("bin")) + "ScreenShots\\";
          return screenShots_path;    
        }

        public static string FileName()
        {
            var testName = "TestName-" + TestContext.CurrentContext.Test.Name; string date = DateTime.Now.ToUniversalTime().ToString().Replace(":", "").Replace("/", "-");

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomString = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray()).ToLower();

            var fileName = testName + " " + date + "--" + randomString;
            return fileName;
        }

        public static void DeleteImages()
        {
            var screenshots_path = ScreenShots_path();
            
            foreach (FileInfo file in new DirectoryInfo(screenshots_path).GetFiles())
            {
                if (file.Name.Contains(TestContext.CurrentContext.Test.FullName))
                {
                     try
                     {
                         file.Delete();
                     }
                     catch (System.Exception) { }
                 }
            }
            
        }
    }
}
