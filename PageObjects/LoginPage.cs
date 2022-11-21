using OpenQA.Selenium;
using System;

namespace TechnicalBootcampSelenium.PageObjects
{
    /// <summary>
    /// Page Object for the Login Page
    /// Contains implementation details, elements, and actions that can be done in the Login page
    /// </summary>
    public class LoginPage
    {
        private readonly WebDriver driver;

        public LoginPage(WebDriver driver) {
            this.driver = driver;
        }

        // Private because we want to hide implementation details from tests and prevent them from being used there
        private IWebElement usernameField => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordField => driver.FindElement(By.Id("password"));
        private IWebElement loginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement loginWrapper => driver.FindElement(By.ClassName("login_wrapper"));

        /// <summary>
        /// Executes the whole login process based on the given parameters
        /// </summary>
        /// <param name="username">The username of the user to be logged in</param>
        /// <param name="password">The password of the user to be logged in</param>
        public void Login(string username, string password)
        {
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();
        }

        /// <summary>
        /// Checks for the displayed state of the Login Wrapper element
        /// </summary>
        /// <returns>True if the login wrapper is displayed, False if otherwise</returns>
        public bool LoginWrapperIsDisplayed()
        {
            bool loginWrapperIsDisplayed = true;
            try
            {
                loginWrapperIsDisplayed = loginWrapper.Displayed;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine($"The login wrapper was not found, this is should be expected for this purpose!");
            }

            return loginWrapperIsDisplayed;
        }
    }
}
