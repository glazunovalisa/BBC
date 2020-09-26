using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class CoronavirusPage : BasePage
    {
        public CoronavirusPage(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//li[contains(@class, 'wide-menuitem-container')]//span[contains(text(), 'Coronavirus')]")]
        private IWebElement CoronavirusElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(@class, 'secondary')]//a")]
        private IWebElement CoronavirusStoriesElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '10725415')]")]
        private IWebElement ShareStoryElement { get; set; }


        public void ClickOnCoronavirusElement() => CoronavirusElement.Click();

        [Obsolete]
        public void ClickOnCoronavirusStoriesElement()
        {
            var getBasePage = new BasePage(driver);

            getBasePage.WaitForElementToBeClickable(timeToWait, CoronavirusStoriesElement);
            CoronavirusStoriesElement.Click();
        }

        public void ClickOnShareStoryElement()
        {
            var getBasePage = new BasePage(driver);

            getBasePage.ScrollTillElementIsVisible(ShareStoryElement);
            ShareStoryElement.Click();
        }
    }
}
