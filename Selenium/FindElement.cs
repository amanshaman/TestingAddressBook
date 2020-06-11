using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestingAddressBook.Selenium
{
    class FindElement
    {
        IWebDriver _driver;

        public FindElement(IWebDriver driver)
        {
            _driver = driver;
        }
        

        public IWebElement ById(string name)
        {
            var temp = By.Id(name);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(temp));

            return _driver.FindElement(By.Id(name));
        }

        public IWebElement ByCssSelector(string name)
        {
            var temp = By.CssSelector(name);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(temp));

            return _driver.FindElement(By.CssSelector(name));
        }

        
    }
}
