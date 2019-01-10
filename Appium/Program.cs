using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;


namespace Appium
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set the Desired Capabilities
            DesiredCapabilities capabilities = new DesiredCapabilities();

            //For Native apps
            //capabilities.SetCapability("deviceName", "My Phone");
            //capabilities.SetCapability("udid", "ce03171338a480160c"); //Give Device ID of your mobile phone
            //capabilities.SetCapability("platformName", "Android");
            //capabilities.SetCapability("platformVersion", "8.0.0");
            //capabilities.SetCapability("appPackage", "com.android.vending");
            //capabilities.SetCapability("appActivity", "com.google.android.finsky.activities.MainActivity");
            //capabilities.SetCapability("noReset", "true");
            //Instantiate Appium Driver
            //AppiumDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            //TakeScreenshot("First", driver);

            //For Web apps
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability("browserName", "chrome");
            capabilities.SetCapability("deviceName", "Motorola Moto g");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "8.0.0");
            IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
            driver.Navigate().GoToUrl("http://yahoo.com");
            if (driver.Title.Equals("Yahoo")) Console.WriteLine(" Sorry , the website didnt open!!");
            driver.Dispose();

        }

        public static void TakeScreenshot(string saveLocation, AppiumDriver<AndroidElement> driver)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ScreenshotImageFormat.Png);
        }
    }
}
