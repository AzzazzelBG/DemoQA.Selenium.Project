using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Tests.Pages
{
    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            Driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver { get; set; }

        public WebDriverWait Wait { get; set; }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
