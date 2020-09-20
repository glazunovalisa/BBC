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
        
        
        public void ClickOnSignInLaterButton()
        {
            SignInLaterButton.Click();
        }
    }
}
