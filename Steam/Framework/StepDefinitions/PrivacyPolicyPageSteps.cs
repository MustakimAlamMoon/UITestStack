using Steam.Framework.Pages;
using Aquality.Selenium.Core.Utilities;
using Reqnroll;
using Aquality.Selenium.Browsers;

namespace Steam.Framework.StepDefinitions
{
    [Binding]
    internal class PrivacyPolicyPageSteps
    {
        private PrivacyPolicyPage privacyPolicyPage = new();

        private static readonly JsonSettingsFile testData = new("testdata.json");
        private string GetLanguageSpecificPageHeading(string language) => testData.GetValue<string>($"pageHeadings.{language}");


        [Then(@"Switch language elements list displayed")]
        public void ThenSwitchLanguageElementsListDisplayed()
        {
            Assert.That(privacyPolicyPage.VerifySwitchLanguageListDisplayed(), $"Switch language elements list is not displayed");
        }

        [Then(@"Supported languages (.*)")]
        public void ThenSupportedLanguages(string language)
        {
            // English option is not available in the language switching list
            if (language == "English")
                Assert.Ignore("Test for English is ignored.");

            privacyPolicyPage.SelectLanguage(language);

            // Correctly format the language key for JSON lookup by removing space
            string formatedLanguage = language.Replace(" ", "");

            Thread.Sleep(1000);

            Assert.That(privacyPolicyPage.GetPageHeadingText(), Is.EqualTo(GetLanguageSpecificPageHeading(formatedLanguage)), $"Page Language doesn't match with {language}");
        }

        [Then(@"Policy revision signed in the current year")]
        public void ThenPolicyRevisionSignedInTheCurrentYear()
        {
            Assert.That(privacyPolicyPage.GetRevisionSignedText(), Does.Contain(DateTime.Now.Year.ToString()), $"Policy revision is not signed in the current year");
        }
    }
}
