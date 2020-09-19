using System.Collections.ObjectModel;
using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace BBC.Tests
{
    public class CheckArticleNameTests
    {
        private const string HomeUrl = "https://www.bbc.com";
        private string expectedNameOfHeadlineArticle = "PLACEHOLDER FOR EXPECTED ARTICLE NAME'";
        private string expectedSecondaryArticleNameIndex1 = "Johnson considers new measures as UK cases surge";
        private string expectedSecondaryArticleNameIndex14 = "Shakespeare play found in Scots college in Spain";
        private int amountOfSecondaryArticle = 15;

        

        [Fact]
        public void CheckNameOfHeadLineArticle()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange 
                driver.Navigate().GoToUrl(HomeUrl);
                var getNewsPage = new NewsPage(driver);
                var getBasePage = new BasePage(driver);

                //Act
                getNewsPage.ClickOnNewsElement();
                getBasePage.ImplicitWait(50);

                //Assert
                Assert.Equal(expectedNameOfHeadlineArticle, getNewsPage.GetNameOfHeadlineArticle());


            }
        }

        [Fact]
        public void CheckSecondaryArticlesName()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);
                var getNewsPage = new NewsPage(driver);
                var getBasePage = new BasePage(driver);

                //Act
                getNewsPage.ClickOnNewsElement();
                getBasePage.ImplicitWait(50);
                ReadOnlyCollection<IWebElement> secondaryArticles = getNewsPage.GetSecondaryArticles();
                

                //Assert
                Assert.Equal(expectedSecondaryArticleNameIndex1, secondaryArticles[1].Text);
                Assert.Equal(expectedSecondaryArticleNameIndex14, secondaryArticles[14].Text);
                Assert.Equal(amountOfSecondaryArticle, getNewsPage.SecondaryArticlesAmount());


            }
        }
    }
}
