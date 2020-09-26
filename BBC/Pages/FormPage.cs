using OpenQA.Selenium;

namespace BBC.Pages
{
    public class FormPage : BasePage
    {
        public FormPage(IWebDriver driver) : base (driver)
        {
        }

        public void OpenFormToShareYourCoronavirusStory()
        {
            OpenBBCHomePage();
            CookiesPage().AgreeToAllTheCookies();
            NewsPage().ClickOnNewsElement();
            ImplicitWait();
            SignInPage().ClickOnSignInLaterButton();
            CoronavirusPage().ClickOnCoronavirusElement();
            CoronavirusPage().ClickOnCoronavirusStoriesElement();
            CoronavirusPage().ClickOnShareStoryElement();
            FormToSubmitPage().ScrollTillFormToSubmitIsVisible();
        }
    }
}
