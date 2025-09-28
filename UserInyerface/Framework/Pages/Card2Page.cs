using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using UserInyerface.Framework.Utils;

namespace UserInyerface.Framework.Pages
{
    internal class Card2Page : Form
    {
        private const string PageName = "Card 2";

        private static ILabel interestsListLbl = ElementFactory.GetLabel(By.ClassName("avatar-and-interests__interests-list"), "Interests List Label");
        private ILink uploadImageBtn = ElementFactory.GetLink(By.CssSelector("[class*='interests__upload']"), "Upload Image Button");

        public ILabel FindCheckBoxByName(string itemName)
        {
            return interestsListLbl.FindChildElement<ILabel>(By.XPath($"//*[@class='avatar-and-interests__interests-list__item' and .//*[text()='{itemName}']]//*[@class='checkbox__label']"), $"Checkbox item: {itemName}");
        }

        public Card2Page() : base(interestsListLbl.Locator, PageName)
        {
        }

        public bool VerifyPageIsOpened()
        {
            return interestsListLbl.State.WaitForDisplayed();
        }

        public void ClickUploadImageBtn()
        {
            uploadImageBtn.Click();
        }

        public void UploadImage()
        {
            ClickUploadImageBtn();
            ImageUtils.RunInputSimulatorScriptToUploadImage();
        }

        public void ClickUnselectAllBtn()
        {
            FindCheckBoxByName("Unselect all").Click();
        }

        /// <summary>
        /// Clicks on the label tag of a specified number of random items in the interests list.
        /// </summary>
        /// <param name="numberOfInterests">The number of random interests to select.</param>
        public void SelectRandomInterests(int numberOfInterests)
        {
            // Validates the interests list to exclude "Select all" and "Unselect all" items.
            IList<ILabel> validatedList = ValidateInterestsList();
            Random random = new();

            // Selects random items from the validated list.
            for (int i = 0; i < numberOfInterests; i++)
            {
                int randomItemNumber = random.Next(validatedList.Count);
                ILabel randomItemLbl = validatedList[randomItemNumber].FindChildElement<ILabel>(By.ClassName("checkbox__label"), $"Random Item Label");
                randomItemLbl.Click();

                // Removes the selected item from the list to avoid reselection.
                validatedList.RemoveAt(randomItemNumber);
            }
        }

        /// <summary>
        /// Validates the interests list by removing unnecessary items like "Select all" and "Unselect all".
        /// </summary>
        /// <returns>A list of validated interest labels.</returns>
        public IList<ILabel> ValidateInterestsList()
        {
            // Retrieves the list of interest labels.
            IList<ILabel> validatedList = interestsListLbl.FindChildElements<ILabel>(By.ClassName("avatar-and-interests__interests-list__item"), "Validated List");

            // Removes "Select all" and "Unselect all" elements from the list.
            validatedList = validatedList.Where(lbl => lbl.Text != "Select all" && lbl.Text != "Unselect all").ToList();

            return validatedList;
        }
    }
}