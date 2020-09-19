using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class BasePage
    {
        private readonly IWebDriver Driver;


        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ImplicitWait(long timeToWait)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }
    }
}
