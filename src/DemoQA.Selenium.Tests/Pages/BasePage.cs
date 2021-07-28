using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace DemoQA.Selenium.Tests.Pages
{
    public abstract class BasePage
    {
        //The Base class where webdriver is initialized and some common functionalities are added
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            Driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver { get; set; }

        public WebDriverWait Wait { get; set; }

        public void ClickOnElement(IWebElement element)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)Driver;

            javaScriptExecutor.ExecuteScript("arguments[0].click()", element);
        }

        public void Type(IWebElement element, string text)
        {
            element.SendKeys(Keys.Control + "A");
            element.SendKeys(text);
        }

        public IWebElement GetClickableElement(By locator)
        {
            Wait.Until(d =>
            {
                IWebElement e = d.FindElement(locator);
                return e.Displayed && e.Enabled;
            }
            );

            IWebElement element = Driver.FindElement(locator);
            return element;
        }

        public void SelectSpecificCheckboxes(List<IWebElement> elements, List<bool> selectConditions)
        {
            for (int i = 0; i < selectConditions.Count; i++)
            {
                if (selectConditions[i])
                {
                    Actions action = new Actions(Driver);

                    action.MoveToElement(elements[i]).Click().Perform();
                }
            }
        }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
