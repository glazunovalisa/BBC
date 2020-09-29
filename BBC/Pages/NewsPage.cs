using System.Collections.Generic;
using OpenQA.Selenium;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace BBC.Pages
{
    public class NewsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//a[contains(text(), 'News')]")]
        public IWebElement NewsElement { get; private set; }
        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']//div[contains(@class, 'block@m')]//a[contains(@class, 'anchor')]/h3")]
        public IWebElement NameOfHeadlineArticle { get; private set; }
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'top-stories--international')]//h3[contains(@class, 'gel-pica-bold')]")]
        public IList<IWebElement> SecondaryArticles { get;  private set; }

        public NewsPage(IWebDriver driver) : base(driver) { }

        public void ClickOnNewsElement() => NewsElement.Click();

        public string GetNameOfHeadlineArticle() => NameOfHeadlineArticle.Text;

        public int SecondaryArticlesAmount() => SecondaryArticles.Count;
    }
}
