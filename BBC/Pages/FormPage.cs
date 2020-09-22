using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class FormPage
    {
        private readonly IWebDriver Driver;

        public FormPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [Obsolete]
        public void OpenFormToShareYourCoronavirusStory()
        {
            //Arrange
            
            var getNewsPage = new NewsPage(Driver);
            var getBasePage = new BasePage(Driver);
            var getCookiesPage = new CookiesPage(Driver);
            var getSignInPage = new SignInPage(Driver);
            var getCoronavirusPage = new CoronavirusPage(Driver);
            var getFormToSubmitPage = new FormToSubmitPage(Driver);

            //Act
            getBasePage.OpenBBCHomePage();
            getCookiesPage.AgreeToAllTheCookies();
            //getSignInPage.ClickOnSignInLaterButton();
            getNewsPage.ClickOnNewsElement();
            getBasePage.ImplicitWait();
            getSignInPage.ClickOnSignInLaterButton();
            getCoronavirusPage.ClickOnCoronavirusElement();
            getCoronavirusPage.ClickOnCoronavirusStoriesElement();
            getCoronavirusPage.ClickOnShareStoryElement();
            getFormToSubmitPage.ScrollTillFormToSubmitIsVisible();
        }

    }
}
