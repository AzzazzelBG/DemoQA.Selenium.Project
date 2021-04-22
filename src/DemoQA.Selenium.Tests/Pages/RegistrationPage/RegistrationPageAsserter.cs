using NUnit.Framework;

namespace DemoQA.Selenium.Tests.Pages.RegistrationPage
{
    /// <summary>
    /// The class contains custom Asserters for the RegistrationPage class in order to make them tracible and reduce the code in the test class
    /// </summary>
    public static class RegistrationPageAsserter
    {
        public static void AssertPracticeFormIsOpened(this RegistrationPage registrationPage, string text)
        {
            Assert.AreEqual(text, registrationPage.Title.Text);
        }

        public static void AssesrtSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertMobileNumberFieldRequiresValidDataChrome(this RegistrationPage page, string color)
        {
            string borderColor = page.PhoneNumber.GetCssValue("border-color");

            Assert.AreEqual(color, borderColor);
        }

        public static void AssertMobileNumbeFielRequiresValidDataFirefox(this RegistrationPage page, string color)
        {
            string borderColor = page.PhoneNumber.GetCssValue("border-bottom-color");

            Assert.AreEqual(color, borderColor);
        }
    }
}
