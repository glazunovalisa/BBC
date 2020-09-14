using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace BBC
{
    public class UnitTest1
    {
        private const string HomeUrl = "https://www.bbc.com";
        private string expectedNameOfHeadlineArticle = "placeholder for expected Article Name ";
        private string expectedSecondaryArticleName = "TikTok";

        [Fact]
        public void CheckNameOfHeadLineArticle()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                IWebElement nameOfHeadlineArticle =
                    driver.FindElement(By.XPath(".//div[@data-entityid='container-top-stories#1']//div[contains(@class, 'block@m')]//h3"));
                string nameOfHeadLineArticle = nameOfHeadlineArticle.Text;
                Assert.Equal(expectedNameOfHeadlineArticle, nameOfHeadLineArticle);
                

            }
        }

        [Fact]
        public void CheckSecondaryArticlesNames()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                ReadOnlyCollection<IWebElement> secondaryArticles
                    = driver.FindElements(By.XPath(".//div[contains(@class, 'top-stories--international')]//h3[contains(@class, 'gel-pica-bold')]"));
                Assert.Equal(expectedSecondaryArticleName, secondaryArticles[1].Text);

            }
        }

        [Fact]
        public void SearchByCategory()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                IWebElement categoryKeys = driver.FindElement(By.XPath(".//nav[@class='nw-c-nav__wide']//a[contains(@href, 'world')]"));
                string categoryKeyss = categoryKeys.Text;
                driver.FindElement(By.XPath(".//input[@id='orb-search-q']")).SendKeys(categoryKeyss);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                Assert.Contains("World", categoryKeyss); 

            }
        }

    }
}
