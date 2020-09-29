using NUnit.Framework;

namespace BBC.Tests
{
    public class SearchTests : BaseTest
    {
        private readonly string TextOfCategory = "World";

        [Test]
        public void SearchByCategoryKeyword()
        {
            //Arrange 
            CookiesPage.AgreeToAllTheCookies();

            //Act
            CategorySearchPage.CopyTheTextOfChoosenCategory();
            CategorySearchPage.SearchArticlesByPastingCopiedKeywordIntoASearchField();

            //Assert
            Assert.IsTrue(SearchPage.NameOfFirstArticleInSearchByCategoryResults().Contains(TextOfCategory));
        }
    }
}
