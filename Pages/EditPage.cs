using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAddressBook.Models;
using TestingAddressBook.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace TestingAddressBook.Pages
{
    class EditPage
    {
        public readonly EditPageMap Map;

        public EditPage(IWebDriver driver, string id)
        {
            Map = new EditPageMap(driver,id);
        }

        public void FeedDataToPageForm(AddressPageModel addressPageModel)
        {
            Map.GetElements();
            Map.firstNameInput.Clear();
            Map.firstNameInput.SendKeys(addressPageModel.firstName);

            Map.lastNameInput.Clear();
            Map.lastNameInput.SendKeys(addressPageModel.lastName);

            Map.address1Input.Clear();
            Map.address1Input.SendKeys(addressPageModel.address1);

            Map.address2Input.Clear();
            Map.address2Input.SendKeys(addressPageModel.address2);

            Map.cityInput.Clear();
            Map.cityInput.SendKeys(addressPageModel.city);


            Map.stateComboBox.SendKeys(addressPageModel.state);

            Map.zipcodeInput.Clear();
            Map.zipcodeInput.SendKeys(addressPageModel.zipCode);

            if (addressPageModel.countryUS)
            {
                Map.countryUS.Click();
            }
            if (addressPageModel.countryCanada)
            {
                Map.countryCA.Click();
            }

            Map.birthdayInput.Click();
            Map.colorInput.Click();

            Map.ageCombobox.Clear();
            Map.ageCombobox.SendKeys(addressPageModel.age);

            Map.websiteInput.Clear();
            Map.websiteInput.SendKeys(addressPageModel.website);

            Map.phoneInput.Clear();
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

            Map.noteInput.Clear();
            Map.noteInput.SendKeys(addressPageModel.note);

            Map.submitButton.Click();
        }

        public Dictionary<string, string> GetDatafromForm()
        {
            Map.GetElements();
            Dictionary<string, string> newData = new Dictionary<string, string>();

            newData.Add("firstname",Map.firstNameInput.GetAttribute("value"));
            newData.Add("lastname",Map.lastNameInput.GetAttribute("value"));
            newData.Add("address1",Map.address1Input.GetAttribute("value"));
            newData.Add("address2",Map.address2Input.GetAttribute("value"));
            newData.Add("city",Map.cityInput.GetAttribute("value"));

            newData.Add("state", AccessComboboxValue(Map.stateComboBox));

            newData.Add("zipcode",Map.zipcodeInput.GetAttribute("value"));
            newData.Add("age",Map.ageCombobox.GetAttribute("value"));
            newData.Add("website",Map.websiteInput.GetAttribute("value"));
            newData.Add("phone",Map.phoneInput.GetAttribute("value"));
            newData.Add("note",Map.noteInput.GetAttribute("value"));

            if (Map.climbingCheckBox.Selected)
            {
                newData.Add("climbing","true");
            }
            if (Map.dancingCheckBox.Selected)
            {
                newData.Add("dancing", "true");
            }
            if (Map.readingCheckBox.Selected)
            {
                newData.Add("reading", "true");
            }
            if (Map.countryUS.Selected)
            {
                newData.Add("countryUS", "true");
            }
            if (Map.countryCA.Selected)
            {
                newData.Add("countryCanada", "true");
            }

            return newData;
        }

        public string AccessComboboxValue(IWebElement comboBox)
        {
            var temp = new SelectElement(comboBox);
            return temp.SelectedOption.Text;
        }

        public bool IsError()
        {
            try
            {
                Map.GetErrorMessageElement();
                if (Map.errorMessage.Displayed)
                {
                    return true;
                }
                else return false;
            }
            catch (System.NullReferenceException )
            {
                return false;
            }
            

        }
    }

    class EditPageMap
    {
        //navbar
        public IWebElement homeLink, signOutLink, toggleButton, AddressesLink, firstNameInput, lastNameInput, address1Input, address2Input, cityInput
            , stateComboBox, zipcodeInput, countryUS, countryCA, birthdayInput, colorInput, ageCombobox, websiteInput, pictureSaveButton, phoneInput,
            climbingCheckBox, dancingCheckBox, readingCheckBox, noteInput, listLink, submitButton,showLink, errorMessage;


        //declaring new driver for a class
        IWebDriver _driver;
        public EditPageMap(IWebDriver driver, string id)
        {
            Urls urls = new Urls();
            _driver = driver;

            string temp = urls._confirmationPage + id + "/edit";
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
            //showLink = findElement.ByCssSelector($"a[data-test='show']");

        }

        public void GetErrorMessageElement()
        {
            FindElement findElement = new FindElement(_driver);
            errorMessage = findElement.ById("error_explanation");
        }
    }
}
