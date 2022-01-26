using InteractiveInvestorTest.Helpers;
using InteractiveInvestorTest.PageObjects.HomePage;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace InteractiveInvestorTest.Steps.Home
{
    [Binding]
    class HomeSteps
    {
        private readonly IHomePageObjects _homePageObjects;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureInfo _featureInfo;


        private IWebDriver _driver ;
        
        private readonly By _navigationItemServices = By.CssSelector("#navigationItemServices");
        
        public HomeSteps(IWebDriver driver, FeatureInfo featureInfo, ScenarioContext scenarioContext, IHomePageObjects homePageObjects)
        {
            _featureInfo = featureInfo;
            _scenarioContext = scenarioContext;
            _homePageObjects = homePageObjects;
            _driver = driver;
        }

        
        [Given(@"Open a browser and go to  webpage")]
        public void GivenOpenABrowserAndGoToWebpage()
        {
            _driver.TakeScreenShot();
            //implemented in DriverSetup
        }

        [Given(@"Click on the “Services” dropdown")]
        public void GivenClickOnTheServicesDropdown()
        {
            _homePageObjects.ClickServicesDropdown();
            _driver.AssertElementDisplayed(_navigationItemServices);
        }

        [When(@"Click on the link (.*) link")]
        public void WhenClickOnTheLinkTradingAccountLink(PageType content)
        {

            switch (content)
            {
                case PageType.TradingAccount:
                    _homePageObjects.ClickTradingAccount();
                    break;
                case PageType.StockAndShares:
                    _homePageObjects.ClickStockAndShares();
                    break;
            }
        }
    }
}
