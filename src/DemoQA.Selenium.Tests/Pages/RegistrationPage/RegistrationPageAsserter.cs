using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

        public static void AssertCheckboxesAreSelected(this RegistrationPage page, List<bool> selectConditions)
        {
            List<bool> selectedCheckboxes = new List<bool>();

            for (int i = 0; i < page.HobbieCheckboxes.Count; i++)
            {
                if (page.HobbieCheckboxes[i].Selected)
                {
                    selectedCheckboxes.Add(true);
                }
                else
                {
                    selectedCheckboxes.Add(false);
                }
            }

            Assert.True(Enumerable.SequenceEqual(selectedCheckboxes, selectConditions));
        }
    }
}
