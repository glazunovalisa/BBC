using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class SearchPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//nav[@class='nw-c-nav__wide']//a[contains(@href, 'world')]")]
        public IWebElement CategoryWorld { get;  private set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        public IWebElement SearchField { get; private set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='orb-search-button']")]
        public IWebElement SearchButton { get; private set; }
        [FindsBy(How = How.XPath, Using = "//a//span[contains(text(), 'End:')]")]
        public IWebElement NameOfFirstArticleInSearchResults { get; private set; }

        public SearchPage(IWebDriver driver) : base(driver) { }
 
        public string GetTextOfCategoryWorld() => CategoryWorld.Text;

        public void PasteTextOfChosenCategoryIntoSearchField() => SearchField.SendKeys(CategoryWorld.Text);

        public void ClickOnSearchButton() => SearchButton.Click();

        public string NameOfFirstArticleInSearchByCategoryResults() => NameOfFirstArticleInSearchResults.Text;
    }
}
