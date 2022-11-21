using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TechnicalBootcampSelenium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // 1.Input a valid user name "standard_username"
            IWebElement usernameField = driver.FindElement(By.Id("user-name"));
            usernameField.SendKeys("standard_user");

            // 2.Input the password for the valid user "secret_sauce"
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("secret_sauce");

            // 3.Click login button
            IWebElement loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            /*Expected result:
               The user is logged in and has landed in the inventory page*/
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "The user was not logged in!");
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Using -> performance_glitch_user

            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // 1.Input a valid user name
            IWebElement usernameField = driver.FindElement(By.Id("user-name"));
            usernameField.SendKeys("performance_glitch_user");

            // 2.Input the password for the valid user
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("secret_sauce");

            // 3.Click login button
            IWebElement loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            /*Expected result:
               The user is logged in 
                1. Check if the login wrapper is non existent
                2. Check if the url is the landing page (inventory)
             */

            try
            {
                IWebElement loginWrapper = driver.FindElement(By.ClassName("login_wrapper"));
                Assert.Fail("The login elements are still displayed, the user was not logged in!");
            } catch (NoSuchElementException e)
            {
                Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "The user was not logged in!");
            }
        }

        [TestMethod]
        public void TestMethod3()
        {

            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            /*driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);*/
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // 1.Input a valid user name
            IWebElement usernameField = driver.FindElement(By.Id("user-name"));
            usernameField.SendKeys("performance_glitch_user");

            // 2.Input the password for the valid user
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("secret_sauce");

            // 3.Click login button
            IWebElement loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            driver.FindElement(By.TagName("body")).SendKeys("Keys.ESCAPE");

            /*Expected result:
               The user is logged in 
                1.Check if the login wrapper is non existent
                2.Check if the url is the landing page(inventory)
            */

            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url, "The user was not logged in!");
        }
    }
}
