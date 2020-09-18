using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BBC
{
    public class BaseTest
    {
        protected IWebDriver driver;
        private const string HomeURL = "https://www.bbc.com";

        public void TestsSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(HomeURL);
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public BasePage GetBasePage()
        {
            return new BasePage(GetDriver());
        }

    }
}
