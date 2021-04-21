using DemoQA.Selenium.Tests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

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
    }
}