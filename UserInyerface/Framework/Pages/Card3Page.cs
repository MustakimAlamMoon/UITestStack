using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInyerface.Framework.Pages
{
    internal class Card3Page : Form
    {
        private const string PageName = "Card 3";

        private static ILabel PersonalDetailsLbl => ElementFactory.GetLabel(By.ClassName("personal-details"), "Personal Details Label");

        public Card3Page() : base(PersonalDetailsLbl.Locator, PageName)
        {
        }

        public bool VerifyPageIsOpened()
        {
            return PersonalDetailsLbl.State.WaitForDisplayed();
        }
    }
}