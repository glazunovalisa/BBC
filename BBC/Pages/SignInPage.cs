using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class SignInPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='sign_in-exit']")]
        public IWebElement SignInLaterButton { get; private set; }

        public SignInPage(IWebDriver driver) : base (driver) { }

        public void ClickOnSignInLaterButton()
        {
            WaitForElementToBeClickable(timeToWait, SignInLaterButton);
            SignInLaterButton.Click();
        }
    }
}
