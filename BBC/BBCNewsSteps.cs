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
    }
}
