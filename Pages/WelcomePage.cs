using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAddressBook.Models;
using TestingAddressBook.Selenium;

namespace TestingAddressBook.Pages
{
    /// <summary>
    /// Class for handling welcome page (loged or not)
    /// </summary>
    public class WelcomePage
    {
        public readonly WelcomePageMap Map;

        public WelcomePage(IWebDriver driver)
        {
            Map = new WelcomePageMap(driver);
        }

        public void AccessLinkByCssSelector(string dataTest)
        {
            Map.LinkCssSelector(dataTest).Click();
        }

        public void logOf()
        {
            Map.GetElements();
            Map.signOutLink.Click();
        } 
    }

    /// <summary>
    /// class for getting elements on page
    /// </summary>
    public class WelcomePageMap
    {
        public IWebElement homeLink, signInLink, signOutLink, toggleButton, AddressesLink;

        //declaring new driver for a class
        IWebDriver _driver;

        public WelcomePageMap(IWebDriver driver)
        {
            Urls urls = new Urls();
            _driver = driver;
            _driver.Url = urls._welcomePage;
        }

        public IWebElement LinkCssSelector(string dataTest) => _driver.FindElement(By.CssSelector($"a[data-test='{dataTest}']"));

        public void GetElements()
        {
            FindElement findElement = new FindElement(_driver);

            homeLink = findElement.ByCssSelector($"a[data-test='home']");
            //if can`t find sign in link than user is already logged so sign out link is displayed.
            try
            {
                signInLink = findElement.ByCssSelector($"a[data-test='sign-in']");
            }
            catch (Exception )
            {
                signOutLink = findElement.ByCssSelector($"a[data-test='sign-out']");
            }
            //toggleButton = findElement.ByCssSelector($"button[data-toggle='collapse']");
            AddressesLink = findElement.ByCssSelector($"a[data-test='addresses']");
        }


    }
}
