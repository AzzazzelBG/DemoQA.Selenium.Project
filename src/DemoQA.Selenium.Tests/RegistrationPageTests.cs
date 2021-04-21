using DemoQA.Selenium.Tests.Models;
using DemoQA.Selenium.Tests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DemoQA.Selenium.Tests
{
    //[TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class RegistrationPageTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public IWebDriver Driver;
        
        [SetUp]
        public void Setup()
        {
            Driver = new TWebDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            if (Driver != null)
                Driver.Quit();
        }

        [Test]
        public void NavigateToRegistrationPage()
        {
            var registrationPage = new RegistrationPage(Driver);
            registrationPage.NavigateTo();

            registrationPage.AssertPracticeFormIsOpened("Practice Form");
        }

        [Test]
        public void RegisterMandatoryFieldsWithValidData()
        {
            var registrationPage = new RegistrationPage(Driver);
            RegistrationUser user = new RegistrationUser("FirstName",
                                                         "LastName",
                                                         "someone@google.com",
                                                         1,
                                                         "0123456789",
                                                         "21.04.21",
                                                         "Some current address in some city");
            
            registrationPage.NavigateTo();
            registrationPage.FillRegistrationFormMandatoryData(user);
        }
    }
}