using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='sign_in-exit']")]
        private IWebElement SignInLaterButton { get; set; }

        [Obsolete]
        public void ClickOnSignInLaterButton()
        {
            var getBasePage = new BasePage(driver);
            
            getBasePage.WaitForElementToBeClickable(timeToWait, SignInLaterButton);
            SignInLaterButton.Click();
        }

        public IWebElement SignIntoBBCLaterButton() => SignInLaterButton;
    }
}
