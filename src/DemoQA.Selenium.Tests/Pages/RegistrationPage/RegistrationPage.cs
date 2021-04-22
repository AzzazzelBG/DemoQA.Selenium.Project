using DemoQA.Selenium.Tests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl("https://www.demoqa.com/automation-practice-form");
        }

        public void FillRegistrationFormMandatoryData(RegistrationUser user)
        {
            Type(FirstName, user.FirstName);
            Type(LastName, user.LastName);
            Type(Email, user.Email);
            ClickOnElement(Genders[user.GenderIndex]);
            Type(PhoneNumber, user.PhoneNumber);
            Type(CurrentAddres, user.CurrentAddres);
            SubmitButton.Click();
        }
        private void ClickOnElement(IWebElement element)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)Driver;

            javaScriptExecutor.ExecuteScript("arguments[0].click()", element);
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
