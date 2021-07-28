using DemoQA.Selenium.Tests.Models;
using OpenQA.Selenium;

namespace DemoQA.Selenium.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        /// <summary>
        /// The class contains specific actions related to the Registration page
        /// </summary>
        /// <param name="driver"></param>
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
            Type(DataOfBirth, user.DateOfBirth);
            Type(CurrentAddres, user.CurrentAddres);
            ClickOnElement(SubmitButton);
        }

        public bool AreRequiredFieldsEmpty()
        {
            try
            {
               bool element = Driver.FindElement(By.CssSelector("input.form-control:invalid")).Displayed;
               return element;
            }
            catch
            {

                return false;
            }
        }
    }
}
