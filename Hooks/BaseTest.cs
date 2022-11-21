using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;

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
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
    }
}
