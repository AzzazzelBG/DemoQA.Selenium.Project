using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace DemoQA.Selenium.Tests.Pages.RegistrationPage
{
    /// <summary>
    /// In this partial class are stored the locators for all elements needed for the tests
    /// </summary>
    public partial class RegistrationPage
    {
        public IWebElement Title => GetClickableElement(By.ClassName("main-header"));

        public IWebElement FirstName => GetClickableElement(By.Id("firstName"));

        public IWebElement LastName => GetClickableElement(By.Id("lastName"));

        public IWebElement Email => GetClickableElement(By.Id("userEmail"));

        public List<IWebElement> Genders => Driver.FindElements(By.Name("gender")).ToList();

        public IWebElement PhoneNumber => GetClickableElement(By.Id("userNumber"));

        public IWebElement DataOfBirth => GetClickableElement(By.Id("dateOfBirthInput"));

        public IWebElement CurrentAddres => GetClickableElement(By.Id("currentAddress"));

        public IWebElement SubmitButton => GetClickableElement(By.Id("submit"));

        public IWebElement SuccessMessage => GetClickableElement(By.ClassName("modal-header"));
    }
}
