using System;
using System.Globalization;
using System.IO;
using FluentAssertions;
using InteractiveInvestorTest.CommonSteps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace InteractiveInvestorTest.Helpers
{
   public static class WebDriverExtensions
    {
        public static void AssertUrlEquals(this IWebDriver driver, string expectedUrl)
        {
            string currentUrl = driver.Url.ToLower();
            string expectedUrlToLower = expectedUrl.ToLower();

            try
            {
                currentUrl.Should().Be(expectedUrlToLower,
                    $"The current URL '{currentUrl} should be equal to '{expectedUrlToLower}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    $"Actual URL: {currentUrl} is not equal to Expected URL: {expectedUrl} | Error: {e.Message}");
                throw;
            }
        }
        public static void TakeScreenShot(this IWebDriver driver)
        {
            try
            {
                Console.WriteLine($"Current URL : {driver.Url}");
                Console.WriteLine($"Current screen size: {driver.Manage().Window.Size}");

                Screenshot screenShot = driver.TakeScreenshot();
                string artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
                string fileNameBase =
                    $"{DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture)}.png".Replace(' ', '_');
                string screenShotFilePath = Path.Combine(artifactDirectory, fileNameBase);

                Directory.CreateDirectory(artifactDirectory);

                screenShot.SaveAsFile(screenShotFilePath, ScreenshotImageFormat.Png);
                Console.WriteLine($"Screenshot Location: {screenShotFilePath}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unable to take Screenshot due to: {exception.Message}");
            }
        }
        public static void AssertElementDisplayed(this IWebDriver driver, By by)
        {
            try
            {
                WaitForElementToBeVisible(driver, by);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to wait for the following to be visible {by} | Error: {e}");
                throw;
            }
        }
        public static void WaitForElementToBeVisible(IWebDriver driver, By by)
        {
            try
            {
                Setup.WebDriverWait = TimeSpan.FromSeconds(30);
                WebDriverWait waitForElement = new WebDriverWait(driver, Setup.WebDriverWait);
                waitForElement.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to wait for the following to be visible {by} | Error: {e.Message}");
                throw;
            }
        }

        public static void WaitForElementToBeClickable(this IWebDriver driver, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, Setup.WebDriverWait);
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The following error was thrown: {exception.Message}");
                throw;
            }
        }
    }
}
