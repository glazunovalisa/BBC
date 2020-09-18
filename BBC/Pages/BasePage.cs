using System;
using OpenQA.Selenium;


namespace BBC.Pages
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void ImplicitWait(long timeToWait)
        {
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }
    }
}
