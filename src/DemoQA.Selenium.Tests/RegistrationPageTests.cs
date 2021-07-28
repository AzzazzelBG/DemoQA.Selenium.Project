using DemoQA.Selenium.Tests.Models;
using DemoQA.Selenium.Tests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Threading;

namespace DemoQA.Selenium.Tests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class RegistrationPageTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public IWebDriver Driver;
        private RegistrationPage RegistrationPage => new RegistrationPage(Driver);
        
        [SetUp]
        public void Setup()
        {
            //These parameters are set for the Firefox Driver in oreder to avoid slow execution of the driver
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

        [Test, Order(1)]
        public void Navigate_To_Registration_Page()
        {
            RegistrationPage.NavigateTo();

            RegistrationPage.AssertPracticeFormIsOpened("Practice Form");
        }

        [Test, Order(2)]
        [TestCase("FirstName", "LastName", "someone@google.com", 1, "0123456789", "10.10.2020", "Some current address in some city")]
        public void Register_Mandatory_Fields_With_Valid_Data(string firstName, string lastName, string email, int genderIndex, string phoneNumber, string dateOfBirth, string currentAddres)
        {
            RegistrationUser user = new RegistrationUser(firstName,
                                                         lastName,
                                                         email,
                                                         genderIndex,
                                                         phoneNumber,
                                                         dateOfBirth,
                                                         currentAddres);

            RegistrationPage.NavigateTo();
            RegistrationPage.FillRegistrationFormMandatoryData(user);

            RegistrationPage.AssesrtForSuccessfulSubmition();
        }

        [Test, Order(3)]
        [TestCase("", "LastName", "someone@google.com", 1, "0123456789", "10.10.2020", "Some current address in some city")]
        [TestCase("FirstName", "", "someone@google.com", 1, "0123456789", "10.10.2020", "Some current address in some city")]
        [TestCase("FirstName", "LastName", "someone@google.com", 1, "", "10.10.2020", "Some current address in some city")]
        public void Student_Cannot_Register_Without_Requred_Fields(string firstName, string lastName, string email, int genderIndex, string phoneNumber, string dateOfBirth, string currentAddres)
        {
            RegistrationUser user = new RegistrationUser(firstName,
                                                         lastName,
                                                         email,
                                                         genderIndex,
                                                         phoneNumber,
                                                         dateOfBirth,
                                                         currentAddres);

            RegistrationPage.NavigateTo();
            RegistrationPage.FillRegistrationFormMandatoryData(user);

            Thread.Sleep(1000);

            RegistrationPage.AssertRequiredFieldsAreEmpty();
            
        }

        [Test, Order(4)]
        public void Hobbie_Checkboxes_Can_Be_Selected()
        {
            //Values in the list represents the 3 checkboxes from left to right and if the value is true the represented checkbox will be selected
            List<bool> checkboxForSelection = new List<bool>(new bool[] { true, true, false });

            RegistrationPage.NavigateTo();
            RegistrationPage.SelectCheckboxes(checkboxForSelection);

            RegistrationPage.AssertCheckboxesAreSelected(checkboxForSelection);
        }
    }
}