using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using UserInyerface.Framework.Utils;

namespace UserInyerface.Framework.Pages
{
    internal class Card1Page : Form
    {
        private const string PageName = "Card 1";

        private static IButton acceptCookiesBtn = ElementFactory.GetButton(By.ClassName("button--transparent"), "Accept Cookies Button");
        private IButton hideHelpFormBtn = ElementFactory.GetButton(By.ClassName("help-form__send-to-bottom-button"), "Hide Help Form Button");
        private ITextBox passwordTxb = ElementFactory.GetTextBox(By.CssSelector("input[placeholder='Choose Password']"), "Password TextBox");
        private ITextBox emailTxb = ElementFactory.GetTextBox(By.CssSelector("input[placeholder='Your email']"), "Email TextBox");
        private ITextBox domainTxb = ElementFactory.GetTextBox(By.CssSelector("input[placeholder='Domain']"), "Domain TextBox");
        private IButton topLevelDomainBtn = ElementFactory.GetButton(By.ClassName("dropdown__opener"), "Top Level Domain Button");
        private ILink termsAndConditionsLevel = ElementFactory.GetLink(By.ClassName("checkbox__box"), "Terms and Conditions Level");
        private ILabel timerLbl = ElementFactory.GetLabel(By.ClassName("timer--white"), "Timer Label");
        private ILabel topLevelDomainLbl = ElementFactory.GetLabel(By.ClassName("dropdown__list"), "Top Level Domain Label");

        private IList<ILabel> GetTopLevelDomainList() => topLevelDomainLbl.FindChildElements<ILabel>(By.XPath("//*[@class='dropdown__list-item']"), "Top Level Domain List");

        private string randomEmail = string.Empty;
        private string randomPassword = string.Empty;

        private void GetRandomEmail() => randomEmail = RandomUtils.GenerateRandomEmail();
        private void GetRandomPassword() => randomPassword = RandomUtils.GenerateRandomPassword(randomEmail);

        public Card1Page() : base(acceptCookiesBtn.Locator, PageName)
        {
        }

        public void GenerateRandomEmailAndPassword()
        {
            GetRandomEmail();
            GetRandomPassword();
        }

        public bool VerifyPageIsOpened()
        {
            return acceptCookiesBtn.State.WaitForDisplayed();
        }

        public void AcceptCookies()
        {
            acceptCookiesBtn.Click();
        }

        public bool VerifyCookiesFormIsClosed()
        {
            return acceptCookiesBtn.State.WaitForNotDisplayed();
        }

        public void HideHelpForm()
        {
            hideHelpFormBtn.Click();
        }

        public bool VerifyHelpFormIsHidden()
        {
            return hideHelpFormBtn.State.WaitForNotDisplayed();
        }

        public void ExpandTopLevelDomainDropDownList()
        {
            topLevelDomainBtn.Click();
        }

        public void EnterPassword()
        {
            passwordTxb.ClearAndType(randomPassword);
        }

        public void EnterEmail()
        {
            emailTxb.ClearAndType(randomEmail);
        }

        public void EnterDomain(string domainName)
        {
            domainTxb.ClearAndType(domainName);
        }

        /// <summary>
        /// Selects a random top-level domain from the drop-down list.
        /// </summary>
        public void SelectTopLevelDomain()
        {
            ExpandTopLevelDomainDropDownList();
            
            // Retrieves the list of top - level domain labels and selects a random one.
            IList<ILabel> topLevelDomainList = GetTopLevelDomainList();
            topLevelDomainList[new Random().Next(topLevelDomainList.Count)].Click();
        }

        public void AcceptTermsAndConditions()
        {
            termsAndConditionsLevel.Click();
        }

        /// <summary>
        /// Validates if the given time string matches the time displayed on the timer label.
        /// </summary>
        /// <param name="time">The time string to compare in "HH:MM" format.</param>
        /// <returns>True if the given time matches the timer label's time; otherwise, false.</returns>
        public bool ValidateTimerText(string time)
        {
            // Retrieves the text from the timer label.
            string timerText = timerLbl.Text;
            // Splits the timer text to extract hours and minutes.
            string[] timeParts = timerText.Split(":");
            // Formats the extracted hours and minutes into "HH:MM" format.
            string hourMinute = $"{timeParts[0]}:{timeParts[1]}";

            // Compares the formatted timer text with the provided time string.
            return hourMinute == time;
        }
    }
}
