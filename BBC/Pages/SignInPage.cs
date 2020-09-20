using System;
using OpenQA.Selenium;

namespace BBC.Pages
{
    public class SignInPage
    {
        private readonly IWebDriver Driver;


        public SignInPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement SignInLaterButton => Driver.FindElement(By.XPath(".//button[@class='sign_in-exit']"));

        [Obsolete]
        public void ClickOnSignInLaterButton()
        {
            var getBasePage = new BasePage(Driver);
            
            getBasePage.WaitForElementToBeClickable(50, SignInLaterButton);
            SignInLaterButton.Click();
        }

        public IWebElement SignIntoBBCLaterButton()
        {
            return SignInLaterButton;
        }
    }
}
