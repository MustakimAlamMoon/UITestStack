using Steam.Framework.Pages;
using Aquality.Selenium.Browsers;
using Reqnroll;

namespace Steam.Framework.StepDefinitions
{
    [Binding]
    internal class MainPageSteps
    {
        private MainPage mainPage = new();

        [Given(@"Main page is open")]
        public void GivenMainPageIsOpen()
        {
            Assert.That(mainPage.VerifyPageIsOpen(), mainPage.Name + " is not opened");
        }

        [When(@"I scroll and open Privacy Policy")]
        public void WhenIScrollAndOpenPrivacyPolicy()
        {
            mainPage.NavigationLink("Privacy Policy").MouseActions.ScrollToElement();
            mainPage.OpenPrivacyPolicy();
        }

        [Then(@"Privacy Policy page is opened in new tab")]
        public void ThenPrivacyPolicyPageIsOpenedInNewTab()
        {
            AqualityServices.Browser.Tabs().SwitchToLast();
        }

        [When(@"I click on 'Top Sellers' option in the ""BROWSE CATEGORIES"" section of the left menu")]
        public void WhenIClickOnOptionInTheSectionOfTheLeftMenu()
        {
            mainPage.ClickTopSellersLink();
        }
    }
}