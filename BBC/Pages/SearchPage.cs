using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class SearchPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@data-entityid='container-top-stories#1']//div[contains(@class, 'block@m')]//a[contains(@class, 'visited')]//span")]
        public IWebElement CategoryHeadlineArticle { get; private set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        public IWebElement SearchField { get; private set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='orb-search-button']")]
        public IWebElement SearchButton { get; private set; }
        [FindsBy(How = How.XPath, Using = "//a//span[contains(text(), 'End:')]")]
        public IWebElement NameOfFirstArticleInSearchResults { get; private set; }

        public SearchPage(IWebDriver driver) : base(driver) { }
 
        public string GetTextOfCategory() => CategoryHeadlineArticle.Text;

        public void PasteTextOfChosenCategoryIntoSearchField() => SearchField.SendKeys(CategoryHeadlineArticle.Text);

        public void ClickOnSearchButton() => SearchButton.Click();

        public string NameOfFirstArticleInSearchByCategoryResults() => NameOfFirstArticleInSearchResults.Text;
    }
}
