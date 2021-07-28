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

        public static void AssesrtForSuccessfulSubmition(this RegistrationPage page)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual("Thanks for submitting the form", page.SuccessMessage.Text);
        }

        public static void AssertRequiredFieldsAreEmpty(this RegistrationPage page)
        {
            Assert.IsTrue(page.AreRequiredFieldsEmpty());
        }
    }
}
