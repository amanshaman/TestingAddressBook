using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAddressBook.Models;
using TestingAddressBook.Selenium;

namespace TestingAddressBook.Pages
{
    class SignInPage
    {
        public readonly SignInPageMap Map;

        public SignInPage(IWebDriver driver)
        {
            Map = new SignInPageMap(driver);
        }

        /// <summary>
        /// func. for testing login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void LogIn(string username, string password)
        {
            Map.GetElements();
            var inputEmail = Map.inputUserName;
            var inputPassword = Map.inputPassword;
            var singInbutton = Map.signInButton;

            inputEmail.SendKeys(username);
            inputPassword.SendKeys(password);
            singInbutton.Click();
        }
        /// <summary>
        /// Func. for log in. do not use for testing login page..
        /// </summary>
        public void LogIn()
        {
            Map.GetElements();
            LogInDetails logInDetails = new LogInDetails();
            var inputEmail = Map.inputUserName;
            var inputPassword = Map.inputPassword;
            var singInbutton = Map.signInButton;

            inputEmail.SendKeys(logInDetails.username);
            inputPassword.SendKeys(logInDetails.password);
            singInbutton.Click();
        }

        
    }


    public class SignInPageMap
    {
        public IWebElement homeLink, signInLink, inputUserName, inputPassword, signInButton, signUpLink;

        //declaring new driver for a class
        IWebDriver _driver;

        public SignInPageMap(IWebDriver driver)
        {
            Urls urls = new Urls();
            _driver = driver;
            _driver.Url = urls._signInPage;
        }

        /// <summary>
        /// Get all elements.
        /// </summary>
        public void GetElements()
        {
            FindElement findElement = new FindElement(_driver);

            homeLink = findElement.ByCssSelector($"a[data-test='home']");
            signInLink = findElement.ById("sign-in");
            inputUserName = findElement.ById("session_email");
            inputPassword = findElement.ById("session_password");
            signInButton = findElement.ByCssSelector($"input[name='commit']");
            signUpLink = findElement.ByCssSelector($"a[data-test='sign-up']");
        }
    }
}
