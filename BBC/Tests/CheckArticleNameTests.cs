using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace BBC.Tests
{
    public class CheckArticleNameTests
    {
        
        private readonly string expectedNameOfHeadlineArticle = "PLACEHOLDER FOR EXPECTED HEADLINE ARTICLE NAME'";
        private readonly string expectedSecondaryArticleNameIndex0 = "Thais hold huge protest demanding reforms";
        private readonly string expectedSecondaryArticleNameIndex14 = "Shakespeare play found in Scots college in Spain";
        private readonly int amountOfSecondaryArticle = 15;

        

        [Fact]
        public void CheckNameOfHeadLineArticle()
        {
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getNewsPage = new NewsPage(driver);
            var getBasePage = new BasePage(driver);

            //Act
            getBasePage.OpenBBCHomePage();
            getNewsPage.ClickOnNewsElement();
            getBasePage.ImplicitWait();

            //Assert
            Assert.Equal(expectedNameOfHeadlineArticle, getNewsPage.GetNameOfHeadlineArticle());
        }

        [Fact]
        public void CheckSecondaryArticlesName()
        {
            
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getNewsPage = new NewsPage(driver);
            var getBasePage = new BasePage(driver);

            //Act
            getBasePage.OpenBBCHomePage();
            getNewsPage.ClickOnNewsElement();
            getBasePage.ImplicitWait();


            //Assert
            Assert.Equal(expectedSecondaryArticleNameIndex0, getNewsPage.GetSecondaryArticles()[0].Text);
            Assert.Equal(expectedSecondaryArticleNameIndex14, getNewsPage.GetSecondaryArticles()[14].Text);
            Assert.Equal(amountOfSecondaryArticle, getNewsPage.SecondaryArticlesAmount());
        }
    }
}
