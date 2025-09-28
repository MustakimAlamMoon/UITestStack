using TechTalk.SpecFlow;
using UserInyerface.Framework.Pages;

namespace UserInyerface.Framework.StepDefinitions
{
    [Binding]
    internal class MainPageSteps
    {
        private MainPage mainPage = new();

        [Given(@"the welcome page is opened")]
        public void GivenTheWelcomePageIsOpened()
        {
            Assert.That(mainPage.VerifyPageIsOpened(), "Welcome page is not opened");
        }

        [When(@"I click the link 'Please click HERE to GO to the next page'")]
        public void WhenIClickTheLink()
        {
            mainPage.ClickGameStartLink();
        }
    }
}
