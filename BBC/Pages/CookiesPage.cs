﻿using System;
using OpenQA.Selenium;

namespace BBC.Pages
{
    public class CookiesPage
    {
        private readonly IWebDriver Driver;


        public CookiesPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement ChangesInCookiesButton => Driver.FindElement(By.XPath(".//button[@id='bbcprivacy-continue-button']"));
        private IWebElement IAgreeToCookiesButton => Driver.FindElement(By.XPath(".//button[@id='bbccookies-continue-button']"));

      
        public void ClickOnOKToChangesInCookiesButton()
        {
            ChangesInCookiesButton.Click();
        }

       
        public void ClickOnIAgreeToCookiesButton()
        {
            IAgreeToCookiesButton.Click();
        }

        [Obsolete]
        public void AgreeToAllTheCookies()
        {
            var getBasePage = new BasePage(Driver);
            
            getBasePage.WaitForElementToBeClickable(50,ChangesInCookiesButton);
            ClickOnOKToChangesInCookiesButton();
            getBasePage.WaitForElementToBeClickable(50, IAgreeToCookiesButton);
            ClickOnIAgreeToCookiesButton();
        }
    }
}
