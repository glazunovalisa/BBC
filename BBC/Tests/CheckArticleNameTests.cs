using System;
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
        private string expectedSecondaryArticleName = "UK government under pressure over lack of tests";
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
                driver.Navigate().GoToUrl(HomeUrl);
                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                ReadOnlyCollection<IWebElement> secondaryArticles
                    = driver.FindElements(By.XPath(".//div[contains(@class, 'top-stories--international')]//h3[contains(@class, 'gel-pica-bold')]"));
                int amountOfSecondaryArticles = secondaryArticles.Count;
                Assert.Equal(expectedSecondaryArticleName, secondaryArticles[1].Text);
                Assert.Equal(amountOfSecondaryArticle, amountOfSecondaryArticles);


            }
        }
    }
}
