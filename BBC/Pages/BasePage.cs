using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class BasePage
    {
        private const string HomeUrl = "https://www.bbc.com";
        public readonly int timeToWait = 50;

        public readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void OpenBBCHomePage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(HomeUrl);
        }

        public void ImplicitWait() => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);

        public void WaitForElementToBeClickable(long timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForPageLoadComplete() => driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeToWait);

        public void ScrollTillElementIsVisible(IWebElement element)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public NewsPage NewsPage()
        {
            return new NewsPage(driver);
        }

        public CookiesPage CookiesPage()
        {
            return new CookiesPage(driver);
        }

        public SignInPage SignInPage()
        {
            return new SignInPage(driver);
        }
        
        public CoronavirusPage CoronavirusPage()
        {
            return new CoronavirusPage(driver);
        }
        
        public FormToSubmitPage FormToSubmitPage()
        {
            return new FormToSubmitPage(driver);
        }
    }
}
