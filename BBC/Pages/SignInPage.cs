using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class SignInPage
    {
        private readonly IWebDriver Driver;

        public SignInPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[@class='sign_in-exit']")]
        private IWebElement SignInLaterButton { get; set; }


        [Obsolete]
        public void ClickOnSignInLaterButton()
        {
            var getBasePage = new BasePage(Driver);
            
            getBasePage.WaitForElementToBeClickable(50, SignInLaterButton);
            SignInLaterButton.Click();
        }


        public IWebElement SignIntoBBCLaterButton() => SignInLaterButton;
    }
}
