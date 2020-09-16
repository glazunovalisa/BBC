using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace BBC
{
    public class UnitTest1
    {
        private const string HomeUrl = "https://www.bbc.com";
        private string expectedNameOfHeadlineArticle = "Poisoned Navalny 'will return to Russia'";
        private string expectedSecondaryArticleName = "UK government under pressure over lack of tests";
        private int amountOfSecondaryArticle = 15;

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
                int amountOfSecondaryArticles = secondaryArticles.Count;
                Assert.Equal(expectedSecondaryArticleName, secondaryArticles[1].Text);
                Assert.Equal(amountOfSecondaryArticle, amountOfSecondaryArticles);
                

            }
        }

        [Fact]
        [Obsolete]
        public void SearchByCategory()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement agreeCookies = driver.FindElement(By.XPath(".//button[@id='bbcprivacy-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(agreeCookies)).Click();
                IWebElement yesCookies = driver.FindElement(By.XPath(".//button[@id='bbccookies-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(yesCookies)).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
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

        [Fact]
        public void SubmitQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();

            }
        }
    }
}
