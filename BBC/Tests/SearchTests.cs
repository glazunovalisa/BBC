using NUnit.Framework;

namespace BBC.Tests
{
    public class SearchTests : BaseTest
    {
        [Test]
        public void SearchByCategoryKeyword()
        {
            //Arrange 
            CookiesPage.AgreeToAllTheCookies();

            //Act
            CategorySearchPage.CopyTheTextOfChoosenCategory();
            SignInPage.ClickOnSignInLaterButton();
            string textOfCategory = SearchPage.GetTextOfCategory();
            CategorySearchPage.SearchArticlesByPastingCopiedKeywordIntoASearchField();

            //Assert
            Assert.IsTrue(SearchPage.NameOfFirstArticleInSearchByCategoryResults().Contains(textOfCategory));
        }
    }
}
