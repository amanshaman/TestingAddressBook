using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAddressBook.Models;
using TestingAddressBook.Selenium;

namespace TestingAddressBook.Pages
{
    class ConfirmationPage
    {
        public readonly ConfirmationPageMap Map;
        public ConfirmationPage(IWebDriver driver)
        {
            Map = new ConfirmationPageMap(driver);
        }
        public int GetId()
        {
            Console.WriteLine(Map.Driver.Url);
            int id = int.Parse(Map.Driver.Url.Split('/')[4]);
            return id;
        }

        public void GoToAddressesPage()
        {
            Map.GetElements();
            Map.listLink.Click();
        }


    }

    class ConfirmationPageMap
    {
        public IWebElement homeLink, signOutLink,  AddressesLink, editLink, listLink;
        public IWebDriver Driver { get => _driver; }

        IWebDriver _driver;
        public ConfirmationPageMap(IWebDriver driver)
        {
            Urls urls = new Urls();
            _driver = driver;
            //_driver.Url = urls._confirmationPage;
        }

        public void GetElements()
        {
            FindElement findElement = new FindElement(_driver);

            homeLink = findElement.ByCssSelector($"a[data-test='home']");
            signOutLink = findElement.ByCssSelector($"a[data-test='sign-out']");
            AddressesLink = findElement.ByCssSelector($"a[data-test='addresses']");
            editLink = findElement.ByCssSelector($"a[data-test='edit']");
            listLink = findElement.ByCssSelector($"a[data-test='list']");
        }
    }
}
