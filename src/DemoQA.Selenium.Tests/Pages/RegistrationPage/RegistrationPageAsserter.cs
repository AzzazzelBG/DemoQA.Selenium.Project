using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Tests.Pages.RegistrationPage
{
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
    }
}
