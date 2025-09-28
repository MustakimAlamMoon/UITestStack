using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInyerface.Framework.Pages
{
    internal class MainPage : Form
    {
        private const string PageName = "Main Page";

        private static ILink gameStartLink = ElementFactory.GetLink(By.ClassName("start__link"), "Game Start Link");

        private ILink NavigationLink(string navigationName) => ElementFactory.GetLink(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, navigationName)), "Navigation link");

        public MainPage() : base(gameStartLink.Locator, PageName)
        {
        }

        public void ClickNavigationLink(string navigationName)
        {
            NavigationLink(navigationName).Click();
        }

        public void ClickGameStartLink()
        {
            gameStartLink.Click();
        }

        public bool VerifyPageIsOpened()
        {
            return gameStartLink.State.WaitForDisplayed();
        }
    }
}