using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class CookiesPage
    {
        private readonly IWebDriver Driver;

        public CookiesPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[@id='bbcprivacy-continue-button']")]
        private IWebElement ChangesInCookiesButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='bbccookies-continue-button']")]
        private IWebElement IAgreeToCookiesButton { get; set; }



        public void ClickOnOKToChangesInCookiesButton() => ChangesInCookiesButton.Click();

        public void ClickOnIAgreeToCookiesButton() => IAgreeToCookiesButton.Click();



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
