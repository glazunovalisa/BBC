using NUnit.Framework;

namespace BBC.Tests
{
    public class CheckArticleNameTests : BaseTest
    {
        private readonly string expectedNameOfHeadlineArticle = "Donald Trump 'paid $750 in federal income taxes'";
        private readonly string expectedSecondaryArticleNameIndex0 = "Covid-19 deaths near one million worldwide";
        private readonly string expectedSecondaryArticleNameIndex13 = "NFL legend Joe Montana thwarts kidnapping attempt";
        private readonly int amountOfSecondaryArticles = 14;

        [Test]
        public void CheckNameOfHeadLineArticle()
        {
            //Arrange
            CookiesPage.AgreeToAllTheCookies();

            //Act
            NewsPage.ClickOnNewsElement();
            SignInPage.ClickOnSignInLaterButton();
            BasePage.ImplicitWait();

            //Assert
            Assert.AreEqual(expectedNameOfHeadlineArticle, NewsPage.GetNameOfHeadlineArticle());
        }

        [Test]
        public void CheckSecondaryArticlesNames()
        {
            //Arrange
            CookiesPage.AgreeToAllTheCookies();

            //Act
            NewsPage.ClickOnNewsElement();
            SignInPage.ClickOnSignInLaterButton();
            BasePage.ImplicitWait();

            //Assert
            Assert.AreEqual(expectedSecondaryArticleNameIndex0, NewsPage.SecondaryArticles[0].Text);
            Assert.AreEqual(expectedSecondaryArticleNameIndex13, NewsPage.SecondaryArticles[13].Text);
            Assert.AreEqual(amountOfSecondaryArticles, NewsPage.SecondaryArticlesAmount());
        }
    }
}
