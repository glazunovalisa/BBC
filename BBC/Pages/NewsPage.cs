using System.Collections.ObjectModel;
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

        private IWebElement NewsElement
            => Driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));

        private IWebElement NameOfHeadlineArticle
            => Driver.FindElement(By.XPath(".//div[@data-entityid='container-top-stories#1']//div[contains(@class, 'block@m')]//a[contains(@class, 'anchor')]"));

        private ReadOnlyCollection<IWebElement> SecondaryArticles
            => Driver.FindElements(By.XPath(".//div[contains(@class, 'top-stories--international')]//h3[contains(@class, 'gel-pica-bold')]"));


        


        public void ClickOnNewsElement()
        {
            NewsElement.Click();
        }

        public string GetNameOfHeadlineArticle()
        {
            return NameOfHeadlineArticle.Text;
        }

        public ReadOnlyCollection<IWebElement> GetSecondaryArticles()
        {
            return SecondaryArticles;
        }

        public int SecondaryArticlesAmount()
        {
            return SecondaryArticles.Count;
        }
    }
}
