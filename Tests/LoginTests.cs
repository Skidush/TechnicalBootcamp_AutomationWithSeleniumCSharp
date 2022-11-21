using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalBootcampSelenium.Helpers;
using TechnicalBootcampSelenium.Hooks;
using TechnicalBootcampSelenium.PageObjects;

namespace TechnicalBootcampSelenium
{
    /// <summary>
    /// Contains all Login related tests
    /// </summary>
    [TestClass]
    public class LoginTests : BaseTest
    {
        /// <summary>
        /// 1.Input a valid user name "standard_username"
        /// 2.Input the password for the valid user "secret_sauce"
        /// 3.Click login button
        /// Expected result:
        ///     The user is logged in and has landed in the inventory page
        /// </summary>
        [TestMethod]
        public void Standard_user_must_be_able_to_login()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(UserHelper.StandardUserUsername, UserHelper.GenericPassword);

            Assert.AreEqual(ApplicationHelper.InventoryURL, driver.Url, "The user was not logged in!");
        }

        /// <summary>
        /// 1.Input a valid user name
        /// 2.Input the password for the valid user
        /// 3.Click login button
        /// Expected result:
        ///     The user is logged in and has landed in the inventory page
        ///         1. Check if the login wrapper is non existent
        ///         2. Check if the url is the landing page (inventory)
        /// </summary>
        [TestMethod]
        public void Any_valid_user_must_be_able_to_login()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(UserHelper.GenericPassword, UserHelper.GenericPassword);

            bool isUserLoggedIn = loginPage.LoginWrapperIsDisplayed();

            // Fail the test if the user is not logged in, acts as a fast fail condition
            if (!isUserLoggedIn)
            {
                Assert.Fail("The login elements are still displayed, the user was not logged in!");
            }

            // Will not be executed if the Assertion above fails.
            Assert.AreEqual(ApplicationHelper.InventoryURL, driver.Url, "The user was not logged in!");
        }
    }
}
