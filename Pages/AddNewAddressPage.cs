using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAddressBook.Models;
using TestingAddressBook.Selenium;

namespace TestingAddressBook.Pages
{
    class AddNewAddressPage
    {
        public readonly AddNewAddressPageMap Map;

        public AddNewAddressPage(IWebDriver driver)
        {
            Map = new AddNewAddressPageMap(driver);
        }

        public void FeedDataToPageForm(AddressPageModel addressPageModel)
        {
            Map.GetElements();
            Map.firstNameInput.SendKeys(addressPageModel.firstName);
            Map.lastNameInput.SendKeys(addressPageModel.lastName);
            Map.address1Input.SendKeys(addressPageModel.address1);
            Map.address2Input.SendKeys(addressPageModel.address2);
            Map.cityInput.SendKeys(addressPageModel.city);

            Map.stateComboBox.Click();
            Map.stateComboBox.SendKeys(addressPageModel.state);

            Map.zipcodeInput.SendKeys(addressPageModel.zipCode);

            if (addressPageModel.countryUS)
            {
                Map.countryUS.Click(); 
            }
            if(addressPageModel.countryCanada)
            {
                Map.countryCA.Click();
            }

            Map.birthdayInput.Click();
            Map.colorInput.Click();
            Map.ageCombobox.SendKeys(addressPageModel.age);
            Map.websiteInput.SendKeys(addressPageModel.website);

            Map.phoneInput.SendKeys(addressPageModel.phone);
            if (addressPageModel.climbing)
            {
                Map.climbingCheckBox.Click();
            }
            if (addressPageModel.dancing)
            {
                Map.dancingCheckBox.Click();
            }
            if (addressPageModel.reading)
            {
                Map.readingCheckBox.Click();
            }
            
            
            Map.noteInput.SendKeys(addressPageModel.note);

            Map.submitButton.Click();
        }

        public bool IsError()
        {
            Map.GetErrorMessageElement();
            if (Map.errorMessage.Displayed)
            {
                return true;
            }
            else return false;
            
        }

    }

    class AddNewAddressPageMap
    {
        //navbar
        public IWebElement homeLink, signOutLink, toggleButton, AddressesLink, firstNameInput, lastNameInput, address1Input, address2Input, cityInput
            , stateComboBox, zipcodeInput, countryUS, countryCA, birthdayInput, colorInput, ageCombobox, websiteInput, pictureSaveButton, phoneInput,
            climbingCheckBox, dancingCheckBox, readingCheckBox, noteInput, listLink, submitButton, errorMessage;


        //declaring new driver for a class
        IWebDriver _driver;
        public AddNewAddressPageMap(IWebDriver driver)
        {          
            Urls urls = new Urls();
            _driver = driver;
            _driver.Url = urls._addNewAddressPage;
        }

        public void GetElements()
        {
            FindElement findElement = new FindElement(_driver);

            homeLink = findElement.ByCssSelector($"a[data-test='home']");
            signOutLink = findElement.ByCssSelector($"a[data-test='sign-out']");
            AddressesLink = findElement.ByCssSelector($"a[data-test='addresses']");
            firstNameInput = findElement.ById("address_first_name");
            lastNameInput = findElement.ById("address_last_name");
            address1Input = findElement.ById("address_street_address");
            address2Input = findElement.ById("address_secondary_address");
            cityInput = findElement.ById("address_city");
            stateComboBox = findElement.ById("address_state");
            zipcodeInput = findElement.ById("address_zip_code");
            countryUS = findElement.ById("address_country_us");
            countryCA = findElement.ById("address_country_canada");
            birthdayInput = findElement.ById("address_birthday");
            colorInput = findElement.ById("address_color");
            ageCombobox = findElement.ById("address_age");
            websiteInput = findElement.ById("address_website");
            pictureSaveButton = findElement.ById("address_picture");
            phoneInput = findElement.ById("address_phone");
            climbingCheckBox = findElement.ById("address_interest_climb");
            dancingCheckBox = findElement.ById("address_interest_dance");
            readingCheckBox = findElement.ById("address_interest_read");
            noteInput = findElement.ById("address_note");
            listLink = findElement.ByCssSelector($"a[data-test='list']");
            submitButton = findElement.ByCssSelector($"input[data-test='submit']");

        }

        public void GetErrorMessageElement()
        {
            FindElement findElement = new FindElement(_driver);
            errorMessage = findElement.ById("error_explanation");
        }
    }
}
