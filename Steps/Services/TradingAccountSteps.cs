using InteractiveInvestorTest.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace InteractiveInvestorTest.Steps.TradingAccountSteps
{
    [Binding]
    class TradingAccountSteps
    {
        private IWebDriver _driver;
        private readonly FeatureInfo _featureInfo;
        public TradingAccountSteps(IWebDriver driver, FeatureInfo featureInfo)
        {
            _featureInfo = featureInfo;
            _driver = driver;
        }
        private const string ExpectedTradingPageUrl = "https://www.ii.co.uk/ii-accounts/trading-account";
        private const string ExpectedStockAndSharesUrl = "https://www.ii.co.uk/ii-accounts/isa";
        private readonly By _tradingPageHeaderTitle = By.CssSelector("h1.text-jumbo");
        private readonly By _stockAndSharesHeaderTitle = By.CssSelector("h1.text-jumbo:nth-child(1)");

        [Then(@"Should see expected (.*)")]
        public void ThenShouldSeeExpectedPage(PageType content)
        {
            switch (content)
            {
                case PageType.TradingAccount:
                    _driver.AssertElementDisplayed(_tradingPageHeaderTitle);
                    _driver.AssertUrlEquals(ExpectedTradingPageUrl);
                    break;
                case PageType.StockAndShares:
                    _driver.AssertElementDisplayed(_stockAndSharesHeaderTitle);
                    _driver.AssertUrlEquals(ExpectedStockAndSharesUrl);
                    break;
            }
        }
    }
}
