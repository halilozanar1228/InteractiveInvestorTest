using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using InteractiveInvestorTest.CommonSteps;
using TechTalk.SpecFlow;

namespace SharedLogic.Helpers
{
    public class WebDriverCreator
    {
        public IWebDriver LaunchChromeDriver(FeatureContext featureContext)
        {
            if (featureContext == null) throw new ArgumentNullException(nameof(featureContext));

            Setup.WebDriverWait = TimeSpan.FromSeconds(10);
            Setup.PageLoadTimeout = TimeSpan.FromSeconds(20);

            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss,
                PageLoadStrategy = PageLoadStrategy.Normal, 
                AcceptInsecureCertificates = true
            };

            if (!Debugger.IsAttached)
            {
                //A list of Arguments can be found here: https://peter.sh/experiments/chromium-command-line-switches/
                options.AddArgument("--headless");
            }

            options.AddArguments(
                "--enable-automation",
                "--disable-notifications"
            );

            options.AddAdditionalCapability("useAutomationExtension", false);
            return new ChromeDriver(options);
        }
    }
}