using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Steam.Framework.Pages
{
    internal class PrivacyPolicyPage : Form
    {
        private const string PageName = "Privacy Policy Page";

        private static ILabel languageLbl = ElementFactory.GetLabel(By.Id("language_pulldown"), "Language Label");
        private ILabel languageOptionsLbl = ElementFactory.GetLabel(By.Id("language_dropdown"), "Language Options Label");
        private ILabel pageHeadingLbl = ElementFactory.GetLabel(By.XPath("//*[@class='page_name']//*[@class='blockbg']"), "Page Heading Label");
        private ILabel revisionSignedLbl = ElementFactory.GetLabel(By.XPath("//*[@id='newsColumn']//i[last()]"), "Revision Signed Label");
        
        private ILabel ChooseLanguage(string language) => ElementFactory.GetLabel(By.XPath($"//a[contains(text(), '{language}')]"), $"{language} Language Selected");

        public PrivacyPolicyPage() : base(languageLbl.Locator, PageName)
        {
        }

        public bool VerifyPageIsOpen()
        {
            return languageLbl.State.WaitForDisplayed();
        }

        public void OpenLanguageOptions()
        {
            languageLbl.ClickAndWait();
        }

        public bool VerifySwitchLanguageListDisplayed()
        {
            OpenLanguageOptions();
            return languageOptionsLbl.State.WaitForDisplayed();
        }

        public void SelectLanguage(string language)
        {
            ChooseLanguage(language).ClickAndWait();
        }

        public string GetPageHeadingText()
        {
            return pageHeadingLbl.GetText();
        }

        public string GetRevisionSignedText()
        {
            revisionSignedLbl.MouseActions.ScrollToElement();
            return revisionSignedLbl.GetText();
        }
    }
}