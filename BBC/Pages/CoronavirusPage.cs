using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class CoronavirusPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//li[contains(@class, 'wide-menuitem-container')]//span[contains(text(), 'Coronavirus')]")]
        public IWebElement CoronavirusElement { get; private set; }
        [FindsBy(How = How.XPath, Using = "//li[contains(@class, 'secondary')]//a")]
        public IWebElement CoronavirusStoriesElement { get; private set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '10725415')]")]
        public IWebElement ShareStoryElement { get; private set; }

        public CoronavirusPage(IWebDriver driver) : base (driver) { }

        public void ClickOnCoronavirusElement() => CoronavirusElement.Click();

        public void ClickOnCoronavirusStoriesElement()
        {
            WaitForElementToBeClickable(timeToWait, CoronavirusStoriesElement);
            CoronavirusStoriesElement.Click();
        }

        public void ClickOnShareStoryElement()
        {
            ScrollTillElementIsVisible(ShareStoryElement);
            ShareStoryElement.Click();
        }
    }
}
