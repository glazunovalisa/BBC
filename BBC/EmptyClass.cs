using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BBC
{
    public class EmptyClass
    {

        private const string HomeUrl = "https://www.bbc.com";


        public void ManageCookies()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                IWebElement agreeCookies = driver.FindElement(By.XPath(".//button[@id='bbcprivacy-continue-button']"));
                agreeCookies.Click();
                //wait.Until(ExpectedConditions.ElementToBeClickable(agreeCookies)).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                IWebElement yesCookies = driver.FindElement(By.XPath(".//button[@id='bbccookies-continue-button']"));
                yesCookies.Click();
                //wait.Until(ExpectedConditions.ElementToBeClickable(yesCookies)).Click();
            }
        }
    }
}
