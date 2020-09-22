using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace BBC
{
    [Binding]
    public class BBCNewsSteps
    {
        private IWebDriver _driver;
        

        private readonly string expectedNameOfHeadlineArticle = "PLACEHOLDER FOR EXPECTED HEADLINE ARTICLE NAME'";
        private readonly string expectedSecondaryArticleNameIndex0 = "Thais hold huge protest demanding reforms";
        private readonly string expectedSecondaryArticleNameIndex14 = "Shakespeare play found in Scots college in Spain";
        private readonly int amountOfSecondaryArticle = 15;
        private readonly string TextOfCategory = "World";

        [Given(@"I am on the BBC home page")]
        [Obsolete]
        public void GivenIAmOnTheBBCHomePage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            var getBasePage = new BasePage(_driver);
            var getCookiesPage = new CookiesPage(_driver);

            getBasePage.OpenBBCHomePage();
            getCookiesPage.AgreeToAllTheCookies();
        }

        [When(@"I click on News Tab")]
        [Obsolete]
        public void WhenIClickOnNewsTab()
        {
            var getNewsPage = new NewsPage(_driver);
            var getBasePage = new BasePage(_driver);
            var getSignInPage = new SignInPage(_driver);

            getNewsPage.ClickOnNewsElement();
            getBasePage.ImplicitWait();
            getSignInPage.ClickOnSignInLaterButton();
        }

        [Then(@"I should see News page loading with the name of headline article visible on it")]
        [Obsolete]
        public void ThenIShouldSeeNewsPageLoadingWithTheNameOfHeadlineArticleVisibleOnIt()
        {
            var getNewsPage = new NewsPage(_driver);

            Assert.Equal(expectedNameOfHeadlineArticle, getNewsPage.GetNameOfHeadlineArticle());
        }


        [Then(@"I should see News page loading with 15 secondary articles on it")]
        public void ThenIShouldSeeNewsPageLoadingWithSecondaryArticlesOnIt()
        {
            var getNewsPage = new NewsPage(_driver);
            Assert.Equal(amountOfSecondaryArticle, getNewsPage.SecondaryArticlesAmount());
        }

        [Then(@"The name of the first secondary article is \[PLACEHOLDER]")]
        public void ThenTheNameOfTheFirstSecondaryArticleIsPLACEHOLDER()
        {
            var getNewsPage = new NewsPage(_driver);
            Assert.Equal(expectedSecondaryArticleNameIndex0, getNewsPage.GetSecondaryArticles()[0].Text);
           
        }

        [Then(@"The name of the last secondary article is \[PLACEHOLDER]")]
        public void ThenTheNameOfTheLastSecondaryArticleIsPLACEHOLDER()
        {
            var getNewsPage = new NewsPage(_driver);
            Assert.Equal(expectedSecondaryArticleNameIndex14, getNewsPage.GetSecondaryArticles()[14].Text);
        }



        [When(@"I copy the text of the category link of the headline article \(World\)")]
        public void WhenICopyTheTextOfTheCategoryLinkOfTheHeadlineArticleWorld()
        {
            var getSearchPage = new SearchPage(_driver);

            getSearchPage.GetTextOfCategoryWorld();
        }

        [When(@"I paste copied keyword into a search field")]
        public void WhenIPasteCopiedKeywordIntoASearchField()
        {
            var getSearchPage = new SearchPage(_driver);

            getSearchPage.PasteTextOfChosenCategoryIntoSearchField();
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            var getSearchPage = new SearchPage(_driver);
            var getBasePage = new BasePage(_driver);

            getSearchPage.ClickOnSearchButton();
            getBasePage.WaitForPageLoadComplete();
        }

        [Then(@"The first article's name should contain my keyword")]
        public void ThenTheFirstArticleSNameShouldContainMyKeyword()
        {
            var getSearchPage = new SearchPage(_driver);

            Assert.Contains(TextOfCategory, getSearchPage.NameOfFirstArticleInSearchByCategoryResults());
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
