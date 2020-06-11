using OpenQA.Selenium;
using TestingAddressBook.Models;
using TestingAddressBook.Selenium;

namespace TestingAddressBook.Pages
{
    class SignUpPage
    {
        public readonly SignUpPageMap Map;

        public SignUpPage(IWebDriver driver)
        {
            Map = new SignUpPageMap(driver);
        }

        public void Register(string name, string password)
        {
            Map.GetElements();

            var userName = Map.inputUserName;
            var userPassword = Map.inputPassword;
            var submit = Map.signUpButton;

            userName.SendKeys(name);
            userPassword.SendKeys(password);
            submit.Click();
        }
    }

    class SignUpPageMap
    {

        public IWebElement homeLink, signInLink, inputUserName, inputPassword, signUpButton, signInButton;

        //declaring new driver for a class
        IWebDriver _driver;

        public SignUpPageMap(IWebDriver driver)
        {
            Urls urls = new Urls();
            _driver = driver;
            _driver.Url = urls._signUpPage;
        }

        public void GetElements()
        {
            FindElement findElement = new FindElement(_driver);

            homeLink = findElement.ByCssSelector($"a[data-test='home']");
            signInLink = findElement.ById("sign-in");
            inputUserName = findElement.ById("user_email");
            inputPassword = findElement.ById("user_password");
            signUpButton = findElement.ByCssSelector($"input[name='commit']");
            signInButton = findElement.ByCssSelector($"a[data-test='sign-in']");
        }
    }
}
