using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestingAddressBook.Models;
using TestingAddressBook.Pages;
using TestingAddressBook.Selenium;

namespace TestingAddressBook
{
    class UnitTest2
    {
        private const string _id = "11310";

        /// <summary>
        /// test for testing editing. 
        /// </summary>
        /// <param name="key">name of property to edit</param>
        /// <param name="value">value of property</param>
        /// <param name="errorExpected">expected outcome after saving the edit.</param>
        [Test]
        [TestCase("firstname", "Dusan", false)]
        [TestCase("lastname", "Novak", false)]
        [TestCase("address1", "Budovatelska 2", false)]
        [TestCase("address2", "Budovatelska 5", false)]
        [TestCase("city", "Brusel", false)]
        [TestCase("state", "F", false)]
        [TestCase("zipcode", "04013", false)]
        [TestCase("age", "50", false)]
        [TestCase("website", "www.google.com", false)]
        [TestCase("phone", "+89603520879", false)]
        [TestCase("note", "EditedNote", false)]
        [TestCase("lastname", "", true)]
        public void EditTest(string key, string value, bool errorExpected)
        {
            foreach (var driver in Driver.Current)
            {
                AddressPage addressPagecs = new AddressPage(driver);

                addressPagecs.EditRow(_id);

                EditPage editPage = new EditPage(driver, _id);

                Dictionary<string, string> newData = new Dictionary<string, string>();
                newData = editPage.GetDatafromForm();
                newData[key] = value;

                AddressPageModel addressPageModel = new AddressPageModel();
                addressPageModel.CreateData(newData);
                editPage.FeedDataToPageForm(addressPageModel);



                if (!("http://a.testaddressbook.com/addresses/" + _id == driver.Url))
                {
                    bool temp = editPage.IsError();
                    Assert.IsTrue(temp == errorExpected);
                }

               
            }
        }


        /// <summary>
        /// Quick test for testing preview page
        /// </summary>
        [Test]
        public void Showtest()
        {
            foreach (var driver in Driver.Current)
            {
                AddressPage addressPagecs = new AddressPage(driver);

                addressPagecs.AddNewAddress();

                AddNewAddressPage addNewAddressPage = new AddNewAddressPage(driver);

                AddressPageModel addressPageModel = new AddressPageModel();

                addNewAddressPage.Map.GetElements();
                addNewAddressPage.FeedDataToPageForm(addressPageModel);

                ConfirmationPage confirmationPage = new ConfirmationPage(driver);

                string id = confirmationPage.GetId().ToString();

                confirmationPage.GoToAddressesPage();

                addressPagecs.ShowRow(id);

                Urls urls = new Urls();

                Assert.AreEqual(urls._confirmationPage + id, driver.Url);
            }
        }


        /// <summary>
        /// Testing adding incorect data. Test has already predefined data in every property. Choose a property to be change and give it a value.
        /// </summary>
        /// <param name="key">property to be added</param>
        /// <param name="value">value of property. Anything outside of empty string (not handled)</param>
        /// <param name="expectedUrl"></param>
        [Test]
        [TestCase("zipCode", "!%&( zip", "http://a.testaddressbook.com/addresses/new")]
        [TestCase("Age", "eighteen", "http://a.testaddressbook.com/addresses/new")]
        [TestCase("Age", "-18", "http://a.testaddressbook.com/addresses/new")]
        [TestCase("Phone", "myphoneletters", "http://a.testaddressbook.com/addresses/new")]
        [TestCase("firstname", "!%&(569*", "http://a.testaddressbook.com/addresses/new")]
        [TestCase("lastname", "!%&(569*", "http://a.testaddressbook.com/addresses/new")]
        [TestCase("city", "!%&(569*", "http://a.testaddressbook.com/addresses/new")]
        [TestCase("webiste", "!%&(569*", "http://a.testaddressbook.com/addresses/new")]
        public void AddNewAddressWithIncorectData(string key, string value, string expectedUrl)
        {
            foreach (var driver in Driver.Current)
            {
                AddressPage addressPagecs = new AddressPage(driver);

                addressPagecs.AddNewAddress();

                AddNewAddressPage addNewAddressPage = new AddNewAddressPage(driver);

                Dictionary<string, string> newData = new Dictionary<string, string>();
                newData.Add(key, value);


                AddressPageModel addressPageModel = new AddressPageModel();
                addressPageModel.CreateData(newData);


                addNewAddressPage.Map.GetElements();
                addNewAddressPage.FeedDataToPageForm(addressPageModel);

                Assert.AreEqual(expectedUrl, driver.Url);
            }
        }

        /// <summary>
        /// Happy path of AddNewAddressWithIncorectData
        /// </summary>
        [Test]
        public void AddNewAddressWithFillingInAllData()
        {
            foreach (var driver in Driver.Current)
            {
                AddressPage addressPagecs = new AddressPage(driver);

                addressPagecs.AddNewAddress();

                AddNewAddressPage addNewAddressPage = new AddNewAddressPage(driver);

                AddressPageModel addressPageModel = new AddressPageModel();

                addNewAddressPage.Map.GetElements();
                addNewAddressPage.FeedDataToPageForm(addressPageModel);


                Urls urls = new Urls();

                Assert.AreEqual(urls._confirmationPage + int.Parse(driver.Url.Split('/')[4].ToString()), driver.Url);
            }
        }

        /// <summary>
        /// happy path of AddNewAddressWithIncorectData but just with minimal data
        /// </summary>
        [Test]
        public void AddNewAddresssWithOnlyNecessaryInfo()
        {
            foreach (var driver in Driver.Current)
            {
                AddressPage addressPagecs = new AddressPage(driver);

                addressPagecs.AddNewAddress();

                AddNewAddressPage addNewAddressPage = new AddNewAddressPage(driver);

                Dictionary<string, string> newData = new Dictionary<string, string>();
                newData.Add("firstname", "john");
                newData.Add("lastname", "smith");
                newData.Add("address1", "juzna trieda 6");
                newData.Add("city", "KE");
                newData.Add("zipcode", "04011");

                AddressPageModel addressPageModel = new AddressPageModel();

                addressPageModel.clearModel();
                addressPageModel.CreateData(newData);

                addNewAddressPage.Map.GetElements();
                addNewAddressPage.FeedDataToPageForm(addressPageModel);


                Urls urls = new Urls();

                Assert.AreEqual(urls._confirmationPage + int.Parse(driver.Url.Split('/')[4].ToString()), driver.Url);
            }
        }

        [Test]
        public void AddNewAddressWithoutfillingData()
        {
            foreach (var driver in Driver.Current)
            {
                AddressPage addressPagecs = new AddressPage(driver);

                addressPagecs.AddNewAddress();

                AddNewAddressPage addNewAddressPage = new AddNewAddressPage(driver);
                Console.WriteLine(driver.Url);
                addNewAddressPage.Map.GetElements();

                Assert.IsTrue(addNewAddressPage.Map.submitButton.Displayed);
                Console.WriteLine("submit button displayed");

                addNewAddressPage.Map.submitButton.Click();

                Assert.IsTrue(addNewAddressPage.IsError());

            }
        }

        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();

            foreach (var driver in Driver.Current)
            {
                driver.Manage().Window.Maximize();
            }

        }


        [TearDown]
        public void AfterEach()
        {
            foreach (var driver in Driver.Current)
            {
                driver.Quit();
            }
        }
    }
}
