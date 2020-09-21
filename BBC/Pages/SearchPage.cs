using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class SearchPage
    {
        private readonly IWebDriver Driver;

        public SearchPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//nav[@class='nw-c-nav__wide']//a[contains(@href, 'world')]")]
        private IWebElement CategoryWorld { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='orb-search-button']")]
        private IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a//span[contains(text(), 'End:')]")]
        private IWebElement NameOfFirstArticleInSearchResults { get; set; }



        public string GetTextOfCategoryWorld() => CategoryWorld.Text;

        public void PasteTextOfChosenCategoryIntoSearchField() => SearchField.SendKeys(CategoryWorld.Text);

        public void ClickOnSearchButton() => SearchButton.Click();

        public string NameOfFirstArticleInSearchByCategoryResults() => NameOfFirstArticleInSearchResults.Text;
    }
}
