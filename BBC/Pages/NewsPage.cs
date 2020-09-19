using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BBC.Pages
{
    public class NewsPage
    {

        private readonly IWebDriver Driver;


        public NewsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement NewsElement => Driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
        private IWebElement NameOfHeadlineArticle => Driver.FindElement(By.XPath(".//div[@data-entityid='container-top-stories#1']//div[contains(@class, 'block@m')]//a[contains(@class, 'anchor')]"));




        public void ClickOnNewsElement()
        {
            NewsElement.Click();
        }

        public string GetNameOfHeadlineArticle()
        {
            return NameOfHeadlineArticle.Text;
        }
    }
}
