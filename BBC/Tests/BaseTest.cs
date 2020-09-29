using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using BBC.Pages;

namespace BBC.Tests
{
    public class BaseTest 
    {
        private const string HomeUrl = "https://www.bbc.com"; 

        public IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(HomeUrl);
        }

        [TearDown]
        public void QuitBrowser()
        {
            driver.Quit();
        }

        public NewsPage NewsPage => new NewsPage(driver);

        public CookiesPage CookiesPage => new CookiesPage(driver);

        public SignInPage SignInPage => new SignInPage(driver);

        public CoronavirusPage CoronavirusPage => new CoronavirusPage(driver);

        public FormToSubmitPage FormToSubmitPage => new FormToSubmitPage(driver);

        public BasePage BasePage => new BasePage(driver);

        public SearchPage SearchPage => new SearchPage(driver);

        public FormPage FormPage => new FormPage(driver);

        public FormDataPage FormDataPage => new FormDataPage(driver);

        public CategorySearchPage CategorySearchPage => new CategorySearchPage(driver);
    }
}
