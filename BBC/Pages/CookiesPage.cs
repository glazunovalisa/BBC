using System;
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

        public IWebElement OKChangesInCookiesButton()
        {
            return ChangesInCookiesButton;
        }

        public void ClickOnOKToChangesInCookiesButton()
        {
            ChangesInCookiesButton.Click();
        }

        public IWebElement AgreeToCookiesButton()
        {
            return IAgreeToCookiesButton;
        }

        public void ClickOnIAgreeToCookiesButton()
        {
            IAgreeToCookiesButton.Click();
        }

        [Obsolete]
        public void AgreeToAllTheCookies()
        {
            var getBasePage = new BasePage(Driver);
            var getCookiesPage = new CookiesPage(Driver);

            getBasePage.WaitForElementToBeClickable(50, getCookiesPage.OKChangesInCookiesButton());
            getCookiesPage.ClickOnOKToChangesInCookiesButton();
            getBasePage.WaitForElementToBeClickable(50, getCookiesPage.AgreeToCookiesButton());
            getCookiesPage.ClickOnIAgreeToCookiesButton();
        }
    }
}
