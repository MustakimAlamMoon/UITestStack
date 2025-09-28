using Aquality.Selenium.Core.Utilities;
using TechTalk.SpecFlow;
using UserInyerface.Framework.Pages;

namespace UserInyerface.Framework.StepDefinitions
{
    [Binding]
    internal class Card1PageSteps 
    {
        private Card1Page card1Page = new();
        private MainPage mainPage = new();

        private static readonly JsonSettingsFile testData = new("testdata.json");
        private string GetDomain() => testData.GetValue<string>("card1Data.domain");

        [When(@"I input random valid password, email, domain, top level domain, accept the terms of use and click '([^']*)' button")]
        public void WhenIInputRandomValidPasswordEmailAcceptTheTermsOfUseAndClickNextButton(string buttonName)
        {
            // Generate random email and password before starting the process.
            card1Page.GenerateRandomEmailAndPassword();

            card1Page.EnterPassword();
            card1Page.EnterEmail();
            card1Page.EnterDomain(GetDomain());
            card1Page.SelectTopLevelDomain();
            card1Page.AcceptTermsAndConditions();
            mainPage.ClickNavigationLink(buttonName);
        }

        [When(@"I hide help form")]
        public void WhenIHideHelpForm()
        {
            card1Page.HideHelpForm();
        }

        [Then(@"form content is hidden")]
        public void ThenFormContentIsHidden()
        {
            Assert.That(card1Page.VerifyHelpFormIsHidden(), "Help form is not hidden");
        }

        [When(@"I accept cookies")]
        public void WhenIAcceptCookies()
        {
            card1Page.AcceptCookies();
        }

        [Then(@"form is closed")]
        public void ThenFormIsClosed()
        {
            Assert.That(card1Page.VerifyCookiesFormIsClosed(), "Cookies form is not closed");
        }

        [Then(@"I validate that timer starts from '([^']*)'")]
        public void ThenIValidateThatTimerStartsFrom(string time)
        {
            Assert.That(card1Page.ValidateTimerText(time), $"Timer doesn't start from {time}");
        }
    }
}