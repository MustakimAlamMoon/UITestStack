using TechTalk.SpecFlow;
using UserInyerface.Framework.Pages;
using UserInyerface.Framework.Utils;

namespace UserInyerface.Framework.StepDefinitions
{
    [Binding]
    internal class CommonPageSteps
    {
        // Instances of Card1Page, Card2Page, and Card3Page.
        private Card1Page card1Page = new();
        private Card2Page card2Page = new();
        private Card3Page card3Page = new();

        /// <summary>
        /// Verifies that the specified card page is open.
        /// </summary>
        /// <param name="cardNumber">The number of the card page to verify.</param>
        [Then(@"the '(\d+)' card is open")]
        public void ThenTheCardIsOpen(int cardNumber)
        {
            // Creates an instance of the page based on the card number.
            var cardPage = CommonPageUtils.CreatePage(cardNumber);

            // Uses dynamic type to call the VerifyPageIsOpened method on the created page instance.
            dynamic dynamicCardPage = cardPage;
            bool isOpened = dynamicCardPage.VerifyPageIsOpened();

            // Asserts that the card page is opened.
            Assert.That(isOpened, $"Card {cardNumber} page is not opened");
        }
    }
}
