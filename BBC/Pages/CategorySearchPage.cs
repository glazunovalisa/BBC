using OpenQA.Selenium;

namespace BBC.Pages
{
    public class CategorySearchPage : BasePage
    {
        public CategorySearchPage(IWebDriver driver) : base(driver) { }

        public void CopyTheTextOfChoosenCategory()
        {
            NewsPage.ClickOnNewsElement();
            ImplicitWait();
            SearchPage.GetTextOfCategory();
        }

        public void SearchArticlesByPastingCopiedKeywordIntoASearchField()
        {
            SearchPage.PasteTextOfChosenCategoryIntoSearchField();
            SearchPage.ClickOnSearchButton();
            WaitForPageLoadComplete();
        }
    }
}
