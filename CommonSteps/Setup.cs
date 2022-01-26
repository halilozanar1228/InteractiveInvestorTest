using System;
using BoDi;
using TechTalk.SpecFlow;
using InteractiveInvestorTest.PageObjects.HomePage;


namespace InteractiveInvestorTest.CommonSteps
{
    [Binding]
    public class Setup : Helpers.DriverSetup
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        public static TimeSpan WebDriverWait { get; set; } = TimeSpan.Zero;
        public static TimeSpan PageLoadTimeout { get; internal set; }

        public Setup(FeatureInfo featureInfo, ScenarioInfo scenarioInfo, FeatureContext featureContext, ScenarioContext scenarioContext, IObjectContainer objectContainer)
            : base(featureInfo, scenarioInfo, featureContext, scenarioContext, objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }

        public override void RegisterStuff()
        {
            _objectContainer.RegisterTypeAs<HomePageObjects, IHomePageObjects>();
        }
    }
}
