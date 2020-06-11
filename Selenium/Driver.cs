using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAddressBook.Selenium
{
    public static class Driver
    {
        [ThreadStatic]        
        private static IWebDriver[] _driver;

        /// <summary>
        /// initialise all webdrivers, 
        /// </summary>
        public static void Init()
        {
            _driver = new IWebDriver[] { new ChromeDriver(), /*new FirefoxDriver()*/ };
            foreach (var driver in _driver)
            {
                driver.Manage().Window.Maximize();
            }
        }


        public static IWebDriver[] Current => _driver ?? throw new NullReferenceException("_driver is null.");
    }
}
