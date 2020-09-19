using System;
using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace BBC.Tests
{
    public class SearchTests
    {
        [Fact]
        [Obsolete]
        public void SearchByCategoryKeyword()
        {
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getNewsPage = new NewsPage(driver);
            var getBasePage = new BasePage(driver);
            var getCookiesPage = new CookiesPage(driver);
            

            //Act
            getBasePage.OpenBBCHomePage();
            getCookiesPage.AgreeToAllTheCookies();
            getNewsPage.ClickOnNewsElement();
            getBasePage.WaitForPageLoadComplete();






            IWebElement maybeLater = driver.FindElement(By.XPath(".//button[@class='sign_in-exit']"));
            maybeLater.Click();
            IWebElement categoryKeys = driver.FindElement(By.XPath(".//nav[@class='nw-c-nav__wide']//a[contains(@href, 'world')]"));
            string categoryKeyss = categoryKeys.Text;
            driver.FindElement(By.XPath(".//input[@id='orb-search-q']")).SendKeys(categoryKeyss);
            driver.FindElement(By.XPath(".//button[@id='orb-search-button']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Assert.Contains("World", driver.FindElement(By.XPath(".//a//span[contains(text(), 'End:')]")).Text);
        }
    }
}
