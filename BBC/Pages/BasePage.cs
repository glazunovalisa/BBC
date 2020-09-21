﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class BasePage
    {

        private const string HomeUrl = "https://www.bbc.com";


        private readonly IWebDriver Driver;


        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ImplicitWait() => Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

        public void OpenBBCHomePage() => Driver.Navigate().GoToUrl(HomeUrl);

        [Obsolete]
        public void WaitForElementToBeClickable(long timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForPageLoadComplete() => Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);

        public void ScrollTillElementIsVisible(IWebElement element)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)Driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
