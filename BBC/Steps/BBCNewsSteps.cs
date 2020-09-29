using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BBC
{
    [Binding]
    public class BBCNewsSteps 
    {
        private readonly IWebDriver _driver = new ChromeDriver();

        private const string HomeUrl = "https://www.bbc.com";
        private readonly string expectedNameOfHeadlineArticle = "PLACEHOLDER FOR EXPECTED HEADLINE ARTICLE NAME'";
        private readonly string expectedSecondaryArticleNameIndex0 = "Thais hold huge protest demanding reforms";
        private readonly string expectedSecondaryArticleNameIndex14 = "Shakespeare play found in Scots college in Spain";
        private readonly int amountOfSecondaryArticle = 15;
        private readonly string textOfCategory = "World";
        private readonly string expectegPageTitle = "How to share your questions, stories, pictures and videos with BBC News - BBC News";

        public NewsPage NewsPage => new NewsPage(_driver);
        public CookiesPage CookiesPage => new CookiesPage(_driver);
        public SignInPage SignInPage => new SignInPage(_driver);
        public CoronavirusPage CoronavirusPage => new CoronavirusPage(_driver);
        public FormToSubmitPage FormToSubmitPage => new FormToSubmitPage(_driver);
        public BasePage BasePage => new BasePage(_driver);
        public SearchPage SearchPage => new SearchPage(_driver);
        public FormPage FormPage => new FormPage(_driver);
        public FormDataPage FormDataPage => new FormDataPage(_driver);
        public CategorySearchPage CategorySearchPage => new CategorySearchPage(_driver);

        [BeforeScenario]
        public void MaximizeTheBrowserPage()
        {
            _driver.Manage().Window.Maximize();
        }

        [Given(@"I am on the BBC home page")]
        public void GivenIAmOnTheBBCHomePage()
        {
            _driver.Navigate().GoToUrl(HomeUrl);
        }

        [When(@"I click on News Tab")]
        [Obsolete]
        public void WhenIClickOnNewsTab()
        {
            CookiesPage.AgreeToAllTheCookies();
            NewsPage.ClickOnNewsElement();
            BasePage.ImplicitWait();
            SignInPage.ClickOnSignInLaterButton();
        }

        [Then(@"I should see News page loading with the name of headline article visible on it")]
        [Obsolete]
        public void ThenIShouldSeeNewsPageLoadingWithTheNameOfHeadlineArticleVisibleOnIt()
        {
            Assert.AreEqual(expectedNameOfHeadlineArticle, NewsPage.GetNameOfHeadlineArticle());
        }

        [Then(@"I should see News page loading with 15 secondary articles on it")]
        public void ThenIShouldSeeNewsPageLoadingWithSecondaryArticlesOnIt()
        {
            Assert.AreEqual(amountOfSecondaryArticle, NewsPage.SecondaryArticlesAmount());
        }

        [Then(@"The name of the first secondary article is \[PLACEHOLDER]")]
        public void ThenTheNameOfTheFirstSecondaryArticleIsPLACEHOLDER()
        {
            Assert.AreEqual(expectedSecondaryArticleNameIndex0, NewsPage.SecondaryArticles[0].Text);
        }

        [Then(@"The name of the last secondary article is \[PLACEHOLDER]")]
        public void ThenTheNameOfTheLastSecondaryArticleIsPLACEHOLDER()
        {
            Assert.AreEqual(expectedSecondaryArticleNameIndex14, NewsPage.SecondaryArticles[14].Text);
        }

        [When(@"Copy the text of headline article's category")]
        public void WhenCopyTheTextOfHeadlineArticleSCategory()
        {
            CategorySearchPage.CopyTheTextOfChoosenCategory();
        }

        [When(@"Search articles by pasting copied word into a search field")]
        public void WhenSearchArticlesByPastingCopiedWordIntoASearchField()
        {
            CategorySearchPage.SearchArticlesByPastingCopiedKeywordIntoASearchField();
        }

        [Then(@"The first article's name should contain my keyword")]
        public void ThenTheFirstArticleSNameShouldContainMyKeyword()
        {
            Assert.IsTrue(SearchPage.NameOfFirstArticleInSearchByCategoryResults().Contains(textOfCategory));
        }

        [Given(@"I've opened the form in order to share my story")]
        [Obsolete]
        public void GivenIVeOpenedTheFormInOrderToShareMyStory()
        {
            FormPage.OpenFormToShareYourCoronavirusStory();
        }

        [When(@"I fill out the form without entering my name")]
        public void WhenIFillOutTheFormWithoutEnteringMyName()
        {
            FormDataPage.FillOutFormWithoutEnteringName();
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();
        }

        [When(@"I fill out the fowm without agreeing to terms")]
        public void WhenIFillOutTheFowmWithoutAgreeingToTerms()
        {
            FormDataPage.FillOutFormWithoutAgreeingToTerms();
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();
        }

        [When(@"I fill out the worm using using invalid email")]
        public void WhenIFillOutTheWormUsingUsingInvalidEmail()
        {
            FormDataPage.FillOutFormUsingInvalidEmail();
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();
        }

        [When(@"I fill out the form without entering any message into text field")]
        public void WhenIFillOutTheFormWithoutEnteringAnyMessageIntoTextField()
        {
            FormDataPage.FillOutFormWithoutEnteringStoryText();
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();
        }

        [When(@"I submit my story")]
        public void WhenISubmitMyStory()
        {
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();
        }

        [Then(@"I am still on the same page because the submitting wasn't successful")]
        public void ThenIAmStillOnTheSamePageBecauseTheSubmittingWasnTSuccessful()
        {
            Assert.AreEqual(expectegPageTitle, FormToSubmitPage.ActualPageTitle());
        }

        [Then(@"I get (.*) validation error\(s\)")]
        public void ThenIGetValidationError(int amountOFValidationErrors)
        {
            Assert.AreEqual(amountOFValidationErrors, FormToSubmitPage.AmountOfValidationErrors());
        }

        [Then(@"The first error message is following: ""(.*)""")]
        public void ThenTheFirstErrorMessageIsFollowing(string errorMessage)
        {
            Assert.AreEqual(errorMessage, FormToSubmitPage.ValidationErrors[0].Text);
        }

        [Then(@"The second error message is following: ""(.*)""")]
        public void ThenTheSecondErrorMessageIsFollowing(string errorMessage)
        {
            Assert.AreEqual(errorMessage, FormToSubmitPage.ValidationErrors[1].Text);
        }

        [Then(@"The third error message is following: ""(.*)""")]
        public void ThenTheThirdErrorMessageIsFollowing(string errorMessage)
        {
            Assert.AreEqual(errorMessage, FormToSubmitPage.ValidationErrors[2].Text);
        }

        [Then(@"The fourth error message is following: ""(.*)""")]
        public void ThenTheFourthErrorMessageIsFollowing(string errorMessage)
        {
            Assert.AreEqual(errorMessage, FormToSubmitPage.ValidationErrors[3].Text);
        }

        [AfterScenario]
        public void QuitWebDriver()
        {
            _driver.Quit();
        }
    }
}
