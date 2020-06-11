using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAddressBook.Models;
using TestingAddressBook.Selenium;

namespace TestingAddressBook.Pages
{

    class AddressPage
    {
        public readonly AddressPagecsMap Map;

        public AddressPage(IWebDriver driver)
        {
            SignInPage signInPage = new SignInPage(driver);
            signInPage.LogIn();

            Map = new AddressPagecsMap(driver);
        }

        public void AddNewAddress()
        {
            Map.GetElements();
            Map.createButton.Click();
        }

        public void ShowRow(string id)
        {
            Map.getListElements(id);
            Map.showLink.Click();
        }

        public void EditRow(string id)
        {
            Map.getListElements(id);
            Map.editLink.Click();
        }

        public void DestroyRow(string id)
        {
            Map.getListElements(id);
            Map.destroyLink.Click();
        }

    }

    class AddressPagecsMap
    {
        public IWebElement homeLink, signOutLink, toggleButton, AddressesLink, createButton, showLink, editLink, destroyLink;


        //declaring new driver for a class
        IWebDriver _driver;
        public AddressPagecsMap(IWebDriver driver)
        {
            Urls urls = new Urls();
            _driver = driver;
            _driver.Url = urls._addressPage;
        }

        public void GetElements()
        {
            FindElement findElement = new FindElement(_driver);

            homeLink = findElement.ByCssSelector($"a[data-test='home']");
            signOutLink = findElement.ByCssSelector($"a[data-test='sign-out']"); 
            //toggleButton = findElement.ByCssSelector($"button[data-toggle='collapse']");
            AddressesLink = findElement.ByCssSelector($"a[data-test='addresses']");
            createButton = findElement.ByCssSelector($"a[data-test='create']");
        }

        public void getListElements(string id)
        {
            FindElement findElement = new FindElement(_driver);

            showLink = findElement.ByCssSelector($"a[data-test='show-" + id + "']");
            editLink = findElement.ByCssSelector($"a[data-test='edit-" + id + "']");
            destroyLink = findElement.ByCssSelector($"a[data-test='destroy-" + id + "']");
        }
    }
}
