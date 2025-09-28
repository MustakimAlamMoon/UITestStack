using AngleSharp.Text;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Steam.Framework.Pages
{
    internal class TopSellersPage : Form
    {
        private const string PageName = "Top Sellers Page";

        private static ILabel priceRangeSliderLbl = ElementFactory.GetLabel(By.Id("price_range"), "Price Range Slider Label");

        private ILabel priceRangeDisplayLbl = ElementFactory.GetLabel(By.Id("price_range_display"), "Price Range Display Label");

        private ILabel priceInputLbl = ElementFactory.GetLabel(By.Id("maxprice_input"), "Price Input Label");

        private ITextBox searchForTagTxb = ElementFactory.GetTextBox(By.Id("TagSuggest"), "Search For Tag TextBox");




        private ILabel gameTitleLbl = ElementFactory.GetLabel(By.ClassName("title"), "Game Title Label");

        private ILabel gameReleaseDateLbl = ElementFactory.GetLabel(By.XPath("//*[contains(@class, 'search_released')]"), "Game Release Date Label");

        private ILabel gameFinalPriceLbl = ElementFactory.GetLabel(By.XPath("//*[contains(@class, 'discount_final_price')]"), "Game Final Price Label");



        private ILabel searchResultTextLbl = ElementFactory.GetLabel(By.Id("search_results_filtered_warning_persistent"), "Search Result Text Label");

        private ILabel searchResultLbl = ElementFactory.GetLabel(By.Id("search_results"), "Search Result Label");

        private ILabel GetCheckedCheckBoxLbl(string name) => ElementFactory.GetLabel(By.XPath($"//*[contains(@class, 'tab_filter_control_row') and contains(@class, 'checked') and @data-loc='{name}']"), $"Get Checked CheckBox {name}");

        private ICheckBox GetCheckBoxByName(string name) => ElementFactory.GetCheckBox(By.XPath($"//*[@class='tab_filter_control_label'][normalize-space(text()) = '{name}']"), $"Get CheckBox {name}");

        private IList<ILabel> GetGamesList() => ElementFactory.FindElements<ILabel>(By.XPath("//*[contains(@class,'search_result_row')]"), "Get Games List");

        private int checkedCheckBoxCount;

        public TopSellersPage() : base(priceRangeSliderLbl.Locator, PageName)
        {
        }

        public bool VerifyPageIsOpen() => priceRangeSliderLbl.State.WaitForDisplayed();

        public void SetPriceRange(string priceRangeDisplayText)
        {
            while (!priceRangeDisplayLbl.Text.Equals(priceRangeDisplayText))
            {
                priceRangeSliderLbl.SendKeys(Keys.Left);
            }
        }

        public string GetPriceRangeDisplayText() => priceRangeDisplayLbl.GetText();
        public void SearchForTag(string tag) => searchForTagTxb.ClearAndType(tag);

        public void CheckByCheckBoxName(string name)
        {
            GetCheckBoxByName(name).Check();

            bool res = GetCheckedCheckBoxLbl(name).State.IsDisplayed;

            if (res) checkedCheckBoxCount++;
        }

        public int GetCheckedCheckBoxCount() => checkedCheckBoxCount;
        public void ClearSearchForTagField() => searchForTagTxb.Clear();
        public int GetGamesListCount() => GetGamesList().Count;

        public int GetSearchResultText()
        {
            string fullText = searchResultTextLbl.GetText();
            string[] words = fullText.Split(' ');
            int searchResultCount = Int32.Parse(words[0]);

            return searchResultCount;
        }

        //public (string GameName, string ReleaseDate, string Price) GetFirstGameInfo()
        //{
        //    var firstGameLbl = GetGamesList().First();
        //    var gameName = firstGameLbl.FindChildElement<ILabel>(gameTitleLbl.Locator, "Game Name").GetText();
        //    string releaseDate = firstGameLbl.FindChildElement<ILabel>(gameReleaseDateLbl.Locator, "Game Release Date").GetText();
        //    ILabel priceLbl = firstGameLbl.FindChildElement<ILabel>(gameFinalPriceLbl.Locator, "Game Price");
        //    string price = priceLbl.GetText();

        //    return (gameName, releaseDate, price);
        //}

        public (string GameName, string ReleaseDate, string Price) GetFirstGameInfo()
        {
            var firstGameLbl = GetGamesList().First();
            Thread.Sleep(2000);

            var gameName = firstGameLbl.FindChildElement<ILabel>(gameTitleLbl.Locator).Text;
            Thread.Sleep(2000);

            string releaseDate = firstGameLbl.FindChildElement<ILabel>(gameReleaseDateLbl.Locator).Text;
            Thread.Sleep(2000);

            var price = firstGameLbl.FindChildElement<ILabel>(gameFinalPriceLbl.Locator).Text;

            Thread.Sleep(2000);

            return (gameName, releaseDate, price);
        }



        public void ClickOnFirstGame() => GetGamesList().First().Click();
    }
}