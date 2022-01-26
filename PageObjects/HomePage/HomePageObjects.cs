using InteractiveInvestorTest.Helpers;
using OpenQA.Selenium;


namespace InteractiveInvestorTest.PageObjects.HomePage
{
    internal interface IHomePageObjects
    {
        void ClickServicesDropdown();
        void ClickTradingAccount();
        void ClickStockAndShares();
    }

    internal class HomePageObjects : IHomePageObjects
    {
        private readonly IWebDriver _driver;

        public HomePageObjects(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By _servicesDropDown = By.CssSelector(".css-1x3lo1o:nth-child(1) > div.css-70qvj9");
        private readonly By _tradingAccountLink = By.LinkText("Trading Account");
        private readonly By _stockAndShares = By.LinkText("Stocks and Shares ISA");


        public void ClickServicesDropdown()
        {
            _driver.WaitForElementToBeClickable(_servicesDropDown); //Message: element not interactable
            _driver.FindElement(_servicesDropDown).Click();
        }

        public void ClickTradingAccount()
        {
            _driver.FindElement(_tradingAccountLink).Click();
        }

        public void ClickStockAndShares()
        {
            _driver.FindElement(_stockAndShares).Click();
        }
    }
}
