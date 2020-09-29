using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class BasePage
    { 
        public readonly int timeToWait = 50;

        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ImplicitWait() => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);

        public void WaitForElementToBeClickable(long timeToWait, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(timeToWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForPageLoadComplete() => driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeToWait);

        public void ScrollTillElementIsVisible(IWebElement element)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public NewsPage NewsPage => new NewsPage(driver);

        public CookiesPage CookiesPage => new CookiesPage(driver);

        public SignInPage SignInPage => new SignInPage(driver);

        public CoronavirusPage CoronavirusPage => new CoronavirusPage(driver);

        public FormToSubmitPage FormToSubmitPage => new FormToSubmitPage(driver);

        public SearchPage SearchPage => new SearchPage(driver);
    }
}
