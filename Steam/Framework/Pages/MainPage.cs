using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Steam.Framework.Pages
{
    internal class MainPage : Form
    {
        private const string PageName = "Main Page";

        private static ILabel pageTitle = ElementFactory.GetLabel(By.XPath(string.Format(LocatorConstants.PartialTextLocator, "Steam")), "Page Title");

        private ILink topSellersLink = ElementFactory.GetLink(By.XPath("//*[@class='gutter_items']//*[contains(text(), 'Top Sellers')]"), "Top Sellers Link");

        public ILink NavigationLink(string navigationName) => ElementFactory.GetLink(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, navigationName)), "Navigation link");


        public MainPage() : base(pageTitle.Locator, PageName)
        {
        }

        public bool VerifyPageIsOpen()
        {
            return pageTitle.State.WaitForDisplayed();
        }

        public void OpenPrivacyPolicy()
        {
            NavigationLink("Privacy Policy").Click();
        }

        public void ClickTopSellersLink()
        {
            topSellersLink.Click();
        }
    }
}