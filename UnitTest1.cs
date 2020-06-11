using NUnit.Framework;
using TestingAddressBook.Pages;
using TestingAddressBook.Selenium;

namespace TestingAddressBook
{
    public class Tests
    {
        private const string URL = "http://a.testaddressbook.com/";
        private const string urlSign = "http://a.testaddressbook.com/sign_in";

        /// <summary>
        /// Test for sign out/
        /// </summary>
        [Test]
        public void signOut()
        {
            foreach (var driver in Driver.Current)
            {
                SignInPage signInPage = new SignInPage(driver);

                signInPage.LogIn();

                WelcomePage welcomePage = new WelcomePage(driver);
                welcomePage.logOf();


            }
        }

        /// <summary>
        /// test for signing up new user with diff. username, password
        /// test is concluded pass/fail by redirection to next page.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="expectedWebPage"></param>
        [Test]
        [Parallelizable(ParallelScope.Children)]
        [TestCase("withoutat", "password1234", "http://a.testaddressbook.com/sign_up")]
        [TestCase("with@", "password1234", "http://a.testaddressbook.com/sign_up")]
        [TestCase("@with", "password1234", "http://a.testaddressbook.com/sign_up")]
        [TestCase("address@site.com", "password1234", "http://a.testaddressbook.com/users")]
        public void SignUpNewUser(string username, string password, string expectedWebPage)
        {
            foreach (var driver in Driver.Current)
            {
                SignUpPage signUpPage = new SignUpPage(driver);

                signUpPage.Register(username, password);

                Assert.AreEqual(expectedWebPage, driver.Url);

            }
        }


        [Test]
        [Parallelizable(ParallelScope.Children)]
        [TestCase("home", URL)]
        [TestCase("sign-in", urlSign)]
        public void WelcomePageSignUpClickFunctionality(string identifierName, string expectedPage)
        {
            foreach (var driver in Driver.Current)
            {
                WelcomePage wp = new WelcomePage(driver);
                wp.AccessLinkByCssSelector(identifierName);
                Assert.AreEqual(expectedPage, driver.Url);
            }
        }

        //[Test]
        [TestCase("aayush.haroun@andyes.net", "qwerty123.", "http://a.testaddressbook.com/")]
        [TestCase("aayush.haroun@andyes.net", "sdasdasd", "http://a.testaddressbook.com/session")]
        public void SingUpPageFunctionality(string username, string password, string expectedWebPage)
        {
            foreach (var driver in Driver.Current)
            {
                SignInPage sgp = new SignInPage(driver);
                sgp.LogIn(username, password);
                Assert.AreEqual(expectedWebPage, driver.Url);
            }
        }

        [Test]
        [Parallelizable(ParallelScope.Children)]
        [TestCase("home", URL)]
        [TestCase("sign-in", urlSign)]
        public void WelcomePageClickFunctionality(string identifierName, string expectedPage)
        {
            foreach (var driver in Driver.Current)
            {
                WelcomePage wp = new WelcomePage(driver);
                wp.AccessLinkByCssSelector(identifierName);
                Assert.AreEqual(expectedPage, driver.Url);
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