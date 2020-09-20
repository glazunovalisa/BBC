using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BBC.Pages
{
    public class FormPage
    {
        private readonly IWebDriver Driver;


        public FormPage(IWebDriver driver)
        {
            Driver = driver;
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
