using System;
using System.Drawing;
using BoDi;
using FluentAssertions;
using JetBrains.Annotations;
using OpenQA.Selenium;
using SharedLogic.Helpers;
using TechTalk.SpecFlow;


namespace InteractiveInvestorTest.Helpers
{

    public abstract class DriverSetup
    {
        private readonly FeatureInfo _featureInfo;
        private readonly ScenarioInfo _scenarioInfo;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private readonly By _acceptCookies = By.CssSelector("button.chakra-button"); // This is Accept Button.
        private const string ExpectedUrl = "https://www.ii.co.uk/";
        protected DriverSetup(FeatureInfo featureInfo, ScenarioInfo scenarioInfo, FeatureContext featureContext, ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _featureInfo = featureInfo;
            _scenarioInfo = scenarioInfo;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }

        [UsedImplicitly]
        [BeforeScenario]
        public void BeforeScenario()
        {
            var webDriverCreator = new WebDriverCreator();
            
            _driver = webDriverCreator.LaunchChromeDriver(_featureContext);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ExpectedUrl);
            _driver.AssertUrlEquals(ExpectedUrl);
            _objectContainer.RegisterInstanceAs(_driver);
            _driver.FindElement(_acceptCookies).Click();
            RegisterStuff();
        }

        public virtual void RegisterStuff() { }

        [UsedImplicitly]
        [AfterStep]
        public void AfterStep()
        { 
            _driver.Url.Should().NotContainAny("error", "Error"); // FluentAssertions;
            _driver.Title.Should().NotContainAny("error", "Error");
        }

        [UsedImplicitly]
        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    OnTestError();
                    _driver.TakeScreenShot();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to execute AfterScenario step due to {e.Message}");
            }

            _driver.Quit();
            _driver.Dispose();
        }

        public virtual void OnTestError() { }
    }
}
