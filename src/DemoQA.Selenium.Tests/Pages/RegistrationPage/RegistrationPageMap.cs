using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Tests.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement Title => Driver.FindElement(By.ClassName("main-header"));
    }
}
