using OpenQA.Selenium;

namespace BBC.Pages
{
    public class SearchPage
    {
        private readonly IWebDriver Driver;

        public SearchPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement CategoryWorld  => Driver.FindElement(By.XPath(".//nav[@class='nw-c-nav__wide']//a[contains(@href, 'world')]"));

        private IWebElement SearchField => Driver.FindElement(By.XPath(".//input[@id='orb-search-q']"));

        private IWebElement SearchButton => Driver.FindElement(By.XPath(".//button[@id='orb-search-button']"));

        private IWebElement NameOfFirstArticleInSearchResults => Driver.FindElement(By.XPath(".//a//span[contains(text(), 'End:')]"));



        public string GetTextOfCategoryWorld()
        {
            return CategoryWorld.Text;
        }

        public void PasteTextOfChosenCategoryIntoSearchField()
        {
            SearchField.SendKeys(CategoryWorld.Text);
        }

        public void ClickOnSearchButton()
        {
            SearchButton.Click();
        }

        public string NameOfFirstArticleInSearchByCategoryResults()
        {
            return NameOfFirstArticleInSearchResults.Text;
        }
    }
}
