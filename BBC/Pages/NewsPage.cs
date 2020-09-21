using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace BBC.Pages
{
    public class NewsPage
    {
        private readonly IWebDriver Driver;

        public NewsPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//a[contains(text(), 'News')]")]
        private IWebElement NewsElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']/a[contains(@class, 'anchor')]/h3")]
        private IWebElement NameOfHeadlineArticle { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'top-stories--international')]//h3[contains(@class, 'gel-pica-bold')]")]
        private IList<IWebElement> SecondaryArticles { get; set; }


        public void ClickOnNewsElement() => NewsElement.Click();

        public string GetNameOfHeadlineArticle() => NameOfHeadlineArticle.Text;

        public IList<IWebElement> GetSecondaryArticles() => SecondaryArticles;

        public int SecondaryArticlesAmount() => SecondaryArticles.Count;
    }
}
