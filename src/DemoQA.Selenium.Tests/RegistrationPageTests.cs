using DemoQA.Selenium.Tests.Models;
using DemoQA.Selenium.Tests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
            var registrationPage = new RegistrationPage(Driver);
            registrationPage.NavigateTo();

            registrationPage.AssertPracticeFormIsOpened("Practice Form");
        }

        [Test, Order(2)]
        [TestCase("FirstName", "LastName", "someone@google.com", 1, "0123456789", "Some current address in some city")]
        public void Register_Mandatory_Fields_With_Valid_Data(string firstName, string lastName, string email, int genderIndex, string phoneNumber, string currentAddres)
        {
            var registrationPage = new RegistrationPage(Driver);
            RegistrationUser user = new RegistrationUser(firstName,
                                                         lastName,
                                                         email,
                                                         genderIndex,
                                                         phoneNumber,
                                                         currentAddres);

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationFormMandatoryData(user);

            registrationPage.AssesrtSuccessMessage("Thanks for submitting the form");
        }

        [Test, Order(3)]
        [TestCase("FirstName", "LastName", "someone@google.com", 1, "", "Some current address in some city")]
        public void Student_Cannot_Register_Without_Phone_Number(string firstName, string lastName, string email, int genderIndex, string phoneNumber, string currentAddres)
        {
            var registrationPage = new RegistrationPage(Driver);
            RegistrationUser user = new RegistrationUser(firstName,
                                                         lastName,
                                                         email,
                                                         genderIndex,
                                                         phoneNumber,
                                                         currentAddres);

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationFormMandatoryData(user);

            Thread.Sleep(1000);

            IWebElement element = Driver.FindElement(By.Id("userNumber"));

            //Having two different Assert methods for both drivers is because the FirefoxDriver finds the color 
            //by different way which is not applicable for ChromDriver
            if(typeof(TWebDriver) == typeof(FirefoxDriver))
            {
                registrationPage.AssertMobileNumbeFielRequiresValidDataFirefox("rgb(220, 53, 69)");
            }
            else
            {
                registrationPage.AssertMobileNumberFieldRequiresValidDataChrome("rgb(220, 53, 69)");
            }
            
        }
    }
}