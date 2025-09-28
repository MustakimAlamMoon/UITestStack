using Steam.Framework.Pages;
using Reqnroll;

namespace Steam.Framework.StepDefinitions
{
    [Binding]
    internal class TopSellersPageSteps
    {
        private TopSellersPage topSellersPage = new();
        private readonly ScenarioContext _scenarioContext;

        public TopSellersPageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"the page with Top Sellers products is open")]
        public void ThenThePageWithTopSellersProductsIsOpen()
        {
            Assert.That(topSellersPage.VerifyPageIsOpen(), "Top Sellers page is not open");
        }

        [When(@"I move the handle of the slider in the 'Narrow by Price' section to the ""([^""]*)"" position")]
        public void WhenIMoveTheHandleOfTheSliderInTheSectionToThePosition(string priceRangeDisplayText)
        {
            topSellersPage.SetPriceRange(priceRangeDisplayText);
        }

        [Then(@"the price range under the slider shows the text ""([^""]*)""")]
        public void ThenThePriceRangeUnderTheSliderShowsTheText(string priceRangeDisplayText)
        {
            Assert.That(topSellersPage.GetPriceRangeDisplayText(), Is.EqualTo(priceRangeDisplayText), 
                $"Price range display text is not equal to {priceRangeDisplayText}");
        }

        [When(@"I select the following filters in the right menu")]
        public void WhenISelectTheFollowingFiltersInTheRightMenu(Table table)
        {
            foreach (var row in table.Rows)
            {
                string tag = row["Narrow by tag"];

                topSellersPage.SearchForTag(tag);
                topSellersPage.CheckByCheckBoxName(tag);
            }

            foreach (var row in table.Rows)
            {
                string os = row["Narrow by OS"];

                if (!string.IsNullOrEmpty(os))
                    topSellersPage.CheckByCheckBoxName(os);
                else
                    break;
            }

            topSellersPage.ClearSearchForTagField();

            Thread.Sleep(1000);
        }

        [Then(@"all (.*) checkboxes are checked")]
        public void ThenAllCheckboxesAreChecked(int numOfCheckBox)
        {
            Assert.That(topSellersPage.GetCheckedCheckBoxCount(), Is.EqualTo(numOfCheckBox), "Not all checkboxes are checked");
        }

        [Then(@"the number of results matching the search equals the number of games in the games list")]
        public void ThenTheNumberOfResultsMatchingTheSearchEqualsTheNumberOfGamesInTheGamesList()
        {
            Assert.That(topSellersPage.GetGamesListCount(), Is.EqualTo(topSellersPage.GetSearchResultText()), "Number of results does not match the number of games in the list");
        }

        [When(@"I get the first game's name, release date, and price from the list")]
        public void WhenIGetTheFirstGamesNameReleaseDateAndPriceFromTheList()
        {
            // Get the tuple containing the game's details
            var (gameName, releaseDate, price) = topSellersPage.GetFirstGameInfo();

            _scenarioContext.Add("GameName", gameName);
            _scenarioContext.Add("ReleaseDate", releaseDate);
            _scenarioContext.Add("Price", price);
        }

        [When(@"I click on the first game in the list")]
        public void WhenIClickOnTheFirstGameInTheList()
        {
            topSellersPage.ClickOnFirstGame();
        }

        [Then(@"the page with the game's description is opened")]
        public void ThenThePageWithTheGamesDescriptionIsOpened()
        {
            throw new PendingStepException();
        }

        [Then(@"the game's name, release date, and price are equal to the ones from previous step")]
        public void ThenTheGamesNameReleaseDateAndPriceAreEqualToTheOnesFromPreviousStep()
        {
            throw new PendingStepException();
        }
    }
}
