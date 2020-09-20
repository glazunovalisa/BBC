using System;
using OpenQA.Selenium;

namespace BBC.Pages
{
    public class CoronavirusPage
    {
        private readonly IWebDriver Driver;


        public CoronavirusPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement CoronavirusElement
            => Driver.FindElement(By.XPath(".//li[contains(@class, 'wide-menuitem-container')]//span[contains(text(), 'Coronavirus')]"));
        
        private IWebElement CoronavirusStoriesElement => Driver.FindElement(By.XPath(".//li[contains(@class, 'secondary')]//a"));

        private IWebElement ShareStoryElement => Driver.FindElement(By.XPath(".//a[contains(@href, '10725415')]"));


        public void ClickOnCoronavirusElement()
        {
            CoronavirusElement.Click();
        }

        [Obsolete]
        public void ClickOnCoronavirusStoriesElement()
        {
            var getBasePage = new BasePage(Driver);

            getBasePage.WaitForElementToBeClickable(50, CoronavirusStoriesElement);
            CoronavirusStoriesElement.Click();
        }

        public void ClickOnShareStoryElement()
        {
            var getBasePage = new BasePage(Driver);

            getBasePage.ScrollTillElementIsVisible(ShareStoryElement);
            ShareStoryElement.Click();
        }
    }
}
