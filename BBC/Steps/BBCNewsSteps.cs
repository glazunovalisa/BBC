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
        private IWebDriver _driver = new ChromeDriver();

        private const string HomeUrl = "https://www.bbc.com";
        private readonly string expectedNameOfHeadlineArticle = "PLACEHOLDER FOR EXPECTED HEADLINE ARTICLE NAME'";
        private readonly string expectedSecondaryArticleNameIndex0 = "Thais hold huge protest demanding reforms";
        private readonly string expectedSecondaryArticleNameIndex14 = "Shakespeare play found in Scots college in Spain";
        private readonly int amountOfSecondaryArticle = 15;
        private readonly string TextOfCategory = "World";
        private readonly string expectegPageTitle = "How to share your questions, stories, pictures and videos with BBC News - BBC News";


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
            var getNewsPage = new NewsPage(_driver);
            var getBasePage = new BasePage(_driver);
            var getSignInPage = new SignInPage(_driver);
            var getCookiesPage = new CookiesPage(_driver);

            getCookiesPage.AgreeToAllTheCookies();
            getNewsPage.ClickOnNewsElement();
            getBasePage.ImplicitWait();
            getSignInPage.ClickOnSignInLaterButton();
        }

        [Then(@"I should see News page loading with the name of headline article visible on it")]
        [Obsolete]
        public void ThenIShouldSeeNewsPageLoadingWithTheNameOfHeadlineArticleVisibleOnIt()
        {
            var getNewsPage = new NewsPage(_driver);

            Assert.AreEqual(expectedNameOfHeadlineArticle, getNewsPage.GetNameOfHeadlineArticle());
        }


        [Then(@"I should see News page loading with 15 secondary articles on it")]
        public void ThenIShouldSeeNewsPageLoadingWithSecondaryArticlesOnIt()
        {
            var getNewsPage = new NewsPage(_driver);
            Assert.AreEqual(amountOfSecondaryArticle, getNewsPage.SecondaryArticlesAmount());
        }

        [Then(@"The name of the first secondary article is \[PLACEHOLDER]")]
        public void ThenTheNameOfTheFirstSecondaryArticleIsPLACEHOLDER()
        {
            var getNewsPage = new NewsPage(_driver);
            Assert.AreEqual(expectedSecondaryArticleNameIndex0, getNewsPage.SecondaryArticles[0].Text);
           
        }

        [Then(@"The name of the last secondary article is \[PLACEHOLDER]")]
        public void ThenTheNameOfTheLastSecondaryArticleIsPLACEHOLDER()
        {
            var getNewsPage = new NewsPage(_driver);
            Assert.AreEqual(expectedSecondaryArticleNameIndex14, getNewsPage.SecondaryArticles[14].Text);
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

            Assert.IsTrue(TextOfCategory.Contains(getSearchPage.NameOfFirstArticleInSearchByCategoryResults()));
        }

        [Given(@"I've opened the form in order to share my story")]
        [Obsolete]
        public void GivenIVeOpenedTheFormInOrderToShareMyStory()
        {
            var getFormPage = new FormPage(_driver);

            getFormPage.OpenFormToShareYourCoronavirusStory();
        }

        [When(@"I enter the text of my story")]
        public void WhenIEnterTheTextOfMyStory()
        {
            var getFormDataPage = new FormDataPage(_driver);

            getFormDataPage.EnterTextOfYourStory();
        }

        [When(@"I enter my name")]
        public void WhenIEnterMyName()
        {
            var getFormDataPage = new FormDataPage(_driver);

            getFormDataPage.EnterYourName();
        }

        [When(@"I enter a valid email")]
        public void WhenIEnterAValidEmail()
        {
            var getFormDataPage = new FormDataPage(_driver);

            getFormDataPage.EnterValidEmail();
        }

        [When(@"I enter an invalid email")]
        public void WhenIEnterAnInvalidEmail()
        {
            var getFormDataPage = new FormDataPage(_driver);

            getFormDataPage.EnterInvalidEmail();
        }


        [When(@"I enter a phone number")]
        public void WhenIEnterAPhoneNumber()
        {
            var getFormDataPage = new FormDataPage(_driver);

            getFormDataPage.EnterYourPhoneNumber();
        }

        [When(@"I enter a location")]
        public void WhenIEnterALocation()
        {
            var getFormDataPage = new FormDataPage(_driver);

            getFormDataPage.EnterYourLocation();
        }

        [When(@"I confirm that I'm over 16")]
        public void WhenIConfirmThatIMOver()
        {
            var getFormDataPage = new FormDataPage(_driver);

            getFormDataPage.ConfirmThatYouAreOlderThan16();
        }

        [When(@"I accept terms and conditions")]
        public void WhenIAcceptTermsAndConditions()
        {
            var getFormDataPage = new FormDataPage(_driver);

            getFormDataPage.AcceptTerms();
        }
        
        [When(@"I submit my story")]
        public void WhenISubmitMyStory()
        {
            var getFormToSubmitPage = new FormToSubmitPage(_driver);
            var getBasePage = new BasePage(_driver);

            getFormToSubmitPage.SubmitYourStory();
            getBasePage.ImplicitWait();
        }

        [Then(@"I am still on the same page because the submitting wasn't successful")]
        public void ThenIAmStillOnTheSamePageBecauseTheSubmittingWasnTSuccessful()
        {
            var getFormToSubmitPage = new FormToSubmitPage(_driver);

            Assert.AreEqual(expectegPageTitle, getFormToSubmitPage.ActualPageTitle());
        }


        [Then(@"I get (.*) validation error")]
        public void ThenIGetValidationError(int amountOFValidationErrors)
        {
            var getFormToSubmitPage = new FormToSubmitPage(_driver);

            Assert.AreEqual(amountOFValidationErrors, getFormToSubmitPage.AmountOfValidationErrors());
        }

        [Then(@"The first error message is following: ""(.*)""")]
        public void ThenTheFirstErrorMessageIsFollowing(string errorMessage)
        {
            var getFormToSubmitPage = new FormToSubmitPage(_driver);

            Assert.AreEqual(errorMessage, getFormToSubmitPage.ValidationErrors[0].Text);
        }

        [Then(@"The second error message is following: ""(.*)""")]
        public void ThenTheSecondErrorMessageIsFollowing(string errorMessage)
        {
            var getFormToSubmitPage = new FormToSubmitPage(_driver);

            Assert.AreEqual(errorMessage, getFormToSubmitPage.ValidationErrors[1].Text);
        }

        [Then(@"The third error message is following: ""(.*)""")]
        public void ThenTheThirdErrorMessageIsFollowing(string errorMessage)
        {
            var getFormToSubmitPage = new FormToSubmitPage(_driver);

            Assert.AreEqual(errorMessage, getFormToSubmitPage.ValidationErrors[2].Text);
        }

        [Then(@"The fourth error message is following: ""(.*)""")]
        public void ThenTheFourthErrorMessageIsFollowing(string errorMessage)
        {
            var getFormToSubmitPage = new FormToSubmitPage(_driver);

            Assert.AreEqual(errorMessage, getFormToSubmitPage.ValidationErrors[3].Text);
        }

        [AfterScenario]
        public void QuitWebDriver()
        {
            _driver.Quit();
        }
    }
}
