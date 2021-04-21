using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoQA.Selenium.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement Title => Driver.FindElement(By.ClassName("main-header"));

        public IWebElement FirstName => Driver.FindElement(By.Id("firstName"));

        public IWebElement LastName => Driver.FindElement(By.Id("lastName"));

        public IWebElement Email => Driver.FindElement(By.Id("userEmail"));

        public List<IWebElement> Genders => Driver.FindElements(By.Name("gender")).ToList();

        public IWebElement PhoneNumber => Driver.FindElement(By.Id("userNumber"));

        public IWebElement DataOfBirth => Driver.FindElement(By.Id("dateOfBirthInput"));

        public IWebElement CurrentAddres => Driver.FindElement(By.Id("currentAddress"));

        public IWebElement SubmitButton => Driver.FindElement(By.Id("submit"));

        public IWebElement SuccessMessage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("modal-header")));
                return this.Driver.FindElement(By.ClassName("modal-header"));
            }
        }
    }
}
