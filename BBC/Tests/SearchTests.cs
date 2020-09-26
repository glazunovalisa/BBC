using System;
using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace BBC.Tests
{
    public class SearchTests 
    {
        private readonly string TextOfCategory = "World";

        [Fact]
        public void SearchByCategoryKeyword()
        {
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getNewsPage = new NewsPage(driver);
            var getBasePage = new BasePage(driver);
            var getCookiesPage = new CookiesPage(driver);
            var getSignInPage = new SignInPage(driver);
            var getSearchPage = new SearchPage(driver);
            
            //Act
            getBasePage.OpenBBCHomePage();
            getCookiesPage.AgreeToAllTheCookies();
            getNewsPage.ClickOnNewsElement();
            getBasePage.ImplicitWait();
            getSearchPage.GetTextOfCategoryWorld();
            getSignInPage.ClickOnSignInLaterButton();
            getSearchPage.PasteTextOfChosenCategoryIntoSearchField();
            getSearchPage.ClickOnSearchButton();
            getBasePage.WaitForPageLoadComplete();

            //Assert
            Assert.Contains(TextOfCategory, getSearchPage.NameOfFirstArticleInSearchByCategoryResults());
        }
    }
}
