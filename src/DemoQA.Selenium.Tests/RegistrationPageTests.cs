using DemoQA.Selenium.Tests.Models;
using DemoQA.Selenium.Tests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace DemoQA.Selenium.Tests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class RegistrationPageTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public IWebDriver Driver;
        
        [SetUp]
        public void Setup()
        {
            if (typeof(TWebDriver) == typeof(FirefoxDriver))
            {
                var service = FirefoxDriverService.CreateDefaultService();
                service.Host = "::1";
                Driver = new FirefoxDriver(service);
            }
            else
            {
                Driver = new ChromeDriver();
            }
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
                                                         "Some current address in some city");
            
            registrationPage.NavigateTo();
            registrationPage.FillRegistrationFormMandatoryData(user);

            registrationPage.AssesrtSuccessMessage("Thanks for submitting the form");
        }

        [Test]
        public void StudentCannotRegisterWithoutPhoneNumber()
        {
            var registrationPage = new RegistrationPage(Driver);
            RegistrationUser user = new RegistrationUser("FirstName",
                                                         "LastName",
                                                         "someone@google.com",
                                                         1,
                                                         "",
                                                         "Some current address in some city");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationFormMandatoryData(user);

            Thread.Sleep(1000);

            IWebElement element = Driver.FindElement(By.Id("userNumber"));

            if(typeof(TWebDriver) == typeof(FirefoxDriver))
            {
                registrationPage.AssertMobileNumbeFielRequiresValidDataFirefox("rgb(220, 53, 69)");
            }
            else
            {
                registrationPage.AssertMobileNumberFieldRequiresValidData("rgb(220, 53, 69)");
            }
            
        }
    }
}