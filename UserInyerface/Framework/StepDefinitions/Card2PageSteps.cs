using TechTalk.SpecFlow;
using UserInyerface.Framework.Pages;

namespace UserInyerface.Framework.StepDefinitions
{
    [Binding]
    internal class Card2PageSteps
    {
        private Card2Page card2Page = new();
        private MainPage mainPage = new();

        [When(@"I choose '(\d+)' random interests, upload image and click '([^']*)' button")]
        public void WhenIChooseRandomInterestsUploadImageAndClickButton(int numberOfInterests, string buttonName)
        {
            card2Page.ClickUnselectAllBtn();
            card2Page.SelectRandomInterests(numberOfInterests);
            card2Page.UploadImage();
            mainPage.ClickNavigationLink(buttonName);
        }
    }
}