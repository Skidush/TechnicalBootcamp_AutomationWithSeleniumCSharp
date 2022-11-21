using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechnicalBootcampSelenium.Helpers;

namespace TechnicalBootcampSelenium.Hooks
{
    /// <summary>
    /// Base Test for all existing tests. This is where we declare all common code that ALL test classes use
    /// </summary>
    public class BaseTest
    {
        public ChromeDriver driver;
        public BaseTest() { }

        [TestInitialize]
        public void InitializeTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl(ApplicationHelper.BaseURL);
        }

        [TestCleanup]
        public void DestroyTest()
        {
            // Close the current browser / driver session
            driver.Close();
        }
    }
}
