using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class CookiesPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//button[@id='bbcprivacy-continue-button']")]
        public IWebElement ChangesInCookiesButton { get; private set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='bbccookies-continue-button']")]
        public IWebElement IAgreeToCookiesButton { get; private set; }

        public CookiesPage(IWebDriver driver) : base (driver) { }

        public void ClickOnOKToChangesInCookiesButton() => ChangesInCookiesButton.Click();

        public void ClickOnIAgreeToCookiesButton() => IAgreeToCookiesButton.Click();

        public void AgreeToAllTheCookies()
        {
            WaitForElementToBeClickable(timeToWait,ChangesInCookiesButton);
            ClickOnOKToChangesInCookiesButton();
            WaitForElementToBeClickable(timeToWait, IAgreeToCookiesButton);
            ClickOnIAgreeToCookiesButton();
        }
    }
}
