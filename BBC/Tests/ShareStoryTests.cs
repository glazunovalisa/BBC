using System;
using System.Collections.ObjectModel;
using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;


namespace BBC
{
    public class ShareStoryTests 
    {
        private const string HomeUrl = "https://www.bbc.com";
        
        private string expectegPageTitle = "How to share your questions, stories, pictures and videos with BBC News - BBC News";

        [Fact]
        [Obsolete]
        public void SubmitQuestionWithoutName()
        {
            
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getNewsPage = new NewsPage(driver);
            var getBasePage = new BasePage(driver);
            var getCookiesPage = new CookiesPage(driver);
            var getSignInPage = new SignInPage(driver);
            var getCoronavirusPage = new CoronavirusPage(driver);
            
            //Act
            getBasePage.OpenBBCHomePage();
            getCookiesPage.AgreeToAllTheCookies();
            getNewsPage.ClickOnNewsElement();
            getBasePage.WaitForPageLoadComplete();
            getSignInPage.ClickOnSignInLaterButton();
            getCoronavirusPage.ClickOnCoronavirusElement();
            getCoronavirusPage.ClickOnCoronavirusStoriesElement();

            

            


            IWebElement shareStory = driver.FindElement(By.XPath(".//a[contains(@href, '10725415')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", shareStory);
            shareStory.Click();

            IWebElement submitStory = driver.FindElement(By.XPath(".//button[contains(text(), 'Submit')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitStory);


            driver.FindElement(By.XPath(".//textarea[@placeholder='Tell us your story. ']")).SendKeys("blabla");


            driver.FindElement(By.XPath(".//input[@placeholder='Email address']")).SendKeys("randombutvalidemail@gmail.com");


            driver.FindElement(By.XPath(".//input[@placeholder='Contact number ']")).SendKeys("1");


            driver.FindElement(By.XPath(".//input[@placeholder='Location ']")).SendKeys("Chioggia");


            driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), '16')]")).Click();

            driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), 'accept')]")).Click();

            submitStory.Submit();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            string pageName = driver.Title;

            var validationErrors = driver.FindElements(By.XPath(".//div[@class='input-error-message']"));

            Assert.Equal(expectegPageTitle, pageName);
            Assert.Single(validationErrors);
            Assert.Equal("Name can't be blank", validationErrors[0].Text);
        }


        [Fact]
        [Obsolete]
        public void SubmitQuestionWithoutAgreeingToTerms()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement agreeCookies = driver.FindElement(By.XPath(".//button[@id='bbcprivacy-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(agreeCookies)).Click();
                IWebElement yesCookies = driver.FindElement(By.XPath(".//button[@id='bbccookies-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(yesCookies)).Click();

                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

                IWebElement maybeLater = driver.FindElement(By.XPath(".//button[@class='sign_in-exit']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(maybeLater)).Click();

                IWebElement coronavirusElement = driver.FindElement(By.XPath(".//li[contains(@class, 'wide-menuitem-container')]//span[contains(text(), 'Coronavirus')]"));
                coronavirusElement.Click();

                IWebElement coronavirusStoriesElement = driver.FindElement(By.XPath(".//li[contains(@class, 'secondary')]//a"));
                wait.Until(ExpectedConditions.ElementToBeClickable(coronavirusStoriesElement)).Click();



                IWebElement shareStory = driver.FindElement(By.XPath(".//a[contains(@href, '10725415')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", shareStory);
                shareStory.Click();

                IWebElement submitStory = driver.FindElement(By.XPath(".//button[contains(text(), 'Submit')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitStory);

                driver.FindElement(By.XPath(".//textarea[@placeholder='Tell us your story. ']")).SendKeys("blabla");

                driver.FindElement(By.XPath(".//input[@placeholder='Name']")).SendKeys("blabla");

                driver.FindElement(By.XPath(".//input[@placeholder='Email address']")).SendKeys("randombutvalidemail@gmail.com");


                driver.FindElement(By.XPath(".//input[@placeholder='Contact number ']")).SendKeys("1");


                driver.FindElement(By.XPath(".//input[@placeholder='Location ']")).SendKeys("Chioggia");


                driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), '16')]")).Click();

                //driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), 'accept')]")).Click();

               

                submitStory.Submit();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

                string pageName = driver.Title;

                var validationErrors = driver.FindElements(By.XPath(".//div[@class='input-error-message']"));

                Assert.Equal(expectegPageTitle, pageName);
                Assert.Single(validationErrors);
                Assert.Equal("must be accepted", validationErrors[0].Text);

            }
        }


        [Fact]
        [Obsolete]
        public void SubmitEmptyFormForQuestion()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement agreeCookies = driver.FindElement(By.XPath(".//button[@id='bbcprivacy-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(agreeCookies)).Click();
                IWebElement yesCookies = driver.FindElement(By.XPath(".//button[@id='bbccookies-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(yesCookies)).Click();

                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

                IWebElement maybeLater = driver.FindElement(By.XPath(".//button[@class='sign_in-exit']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(maybeLater)).Click();

                IWebElement coronavirusElement = driver.FindElement(By.XPath(".//li[contains(@class, 'wide-menuitem-container')]//span[contains(text(), 'Coronavirus')]"));
                coronavirusElement.Click();

                IWebElement coronavirusStoriesElement = driver.FindElement(By.XPath(".//li[contains(@class, 'secondary')]//a"));
                wait.Until(ExpectedConditions.ElementToBeClickable(coronavirusStoriesElement)).Click();



                IWebElement shareStory = driver.FindElement(By.XPath(".//a[contains(@href, '10725415')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", shareStory);
                shareStory.Click();

                IWebElement submitStory = driver.FindElement(By.XPath(".//button[contains(text(), 'Submit')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitStory);



                submitStory.Submit();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

                string pageName = driver.Title;

                var validationErrors = driver.FindElements(By.XPath(".//div[@class='input-error-message']"));

                Assert.Equal(expectegPageTitle, pageName);
                Assert.Equal(4, validationErrors.Count);
                Assert.Equal("can't be blank", validationErrors[0].Text);
                Assert.Equal("Name can't be blank", validationErrors[1].Text);
                Assert.Equal("must be accepted", validationErrors[2].Text);
                Assert.Equal("must be accepted", validationErrors[3].Text);

            }
        }

        [Fact]
        [Obsolete]
        public void SubmitQuestionUsingInvalidEmail()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement agreeCookies = driver.FindElement(By.XPath(".//button[@id='bbcprivacy-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(agreeCookies)).Click();
                IWebElement yesCookies = driver.FindElement(By.XPath(".//button[@id='bbccookies-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(yesCookies)).Click();

                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

                IWebElement maybeLater = driver.FindElement(By.XPath(".//button[@class='sign_in-exit']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(maybeLater)).Click();

                IWebElement coronavirusElement = driver.FindElement(By.XPath(".//li[contains(@class, 'wide-menuitem-container')]//span[contains(text(), 'Coronavirus')]"));
                coronavirusElement.Click();

                IWebElement coronavirusStoriesElement = driver.FindElement(By.XPath(".//li[contains(@class, 'secondary')]//a"));
                wait.Until(ExpectedConditions.ElementToBeClickable(coronavirusStoriesElement)).Click();



                IWebElement shareStory = driver.FindElement(By.XPath(".//a[contains(@href, '10725415')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", shareStory);
                shareStory.Click();

                IWebElement submitStory = driver.FindElement(By.XPath(".//button[contains(text(), 'Submit')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitStory);

                driver.FindElement(By.XPath(".//textarea[@placeholder='Tell us your story. ']")).SendKeys("blabla");

                driver.FindElement(By.XPath(".//input[@placeholder='Name']")).SendKeys("blabla");

                driver.FindElement(By.XPath(".//input[@placeholder='Email address']")).SendKeys("randomnotvalidemailgmail.com");


                driver.FindElement(By.XPath(".//input[@placeholder='Contact number ']")).SendKeys("1");


                driver.FindElement(By.XPath(".//input[@placeholder='Location ']")).SendKeys("Chioggia");


                driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), '16')]")).Click();

                driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), 'accept')]")).Click();



                submitStory.Submit();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

                string pageName = driver.Title;

                var validationErrors = driver.FindElements(By.XPath(".//div[@class='input-error-message']"));

                Assert.Equal(expectegPageTitle, pageName);
                Assert.Single(validationErrors);
                Assert.Equal("Email address is invalid", validationErrors[0].Text);
               

            }
        }

        [Fact]
        [Obsolete]
        public void SubmitFormWithEmptyTextFieldFortStory()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement agreeCookies = driver.FindElement(By.XPath(".//button[@id='bbcprivacy-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(agreeCookies)).Click();
                IWebElement yesCookies = driver.FindElement(By.XPath(".//button[@id='bbccookies-continue-button']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(yesCookies)).Click();

                IWebElement newsElement = driver.FindElement(By.XPath(".//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
                newsElement.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

                IWebElement maybeLater = driver.FindElement(By.XPath(".//button[@class='sign_in-exit']"));
                wait.Until(ExpectedConditions.ElementToBeClickable(maybeLater)).Click();

                IWebElement coronavirusElement = driver.FindElement(By.XPath(".//li[contains(@class, 'wide-menuitem-container')]//span[contains(text(), 'Coronavirus')]"));
                coronavirusElement.Click();

                IWebElement coronavirusStoriesElement = driver.FindElement(By.XPath(".//li[contains(@class, 'secondary')]//a"));
                wait.Until(ExpectedConditions.ElementToBeClickable(coronavirusStoriesElement)).Click();



                IWebElement shareStory = driver.FindElement(By.XPath(".//a[contains(@href, '10725415')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", shareStory);
                shareStory.Click();

                IWebElement submitStory = driver.FindElement(By.XPath(".//button[contains(text(), 'Submit')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitStory);

                

                driver.FindElement(By.XPath(".//input[@placeholder='Name']")).SendKeys("blabla");

                driver.FindElement(By.XPath(".//input[@placeholder='Email address']")).SendKeys("randombutvalidemail@gmail.com");


                driver.FindElement(By.XPath(".//input[@placeholder='Contact number ']")).SendKeys("1");


                driver.FindElement(By.XPath(".//input[@placeholder='Location ']")).SendKeys("Chioggia");


                driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), '16')]")).Click();

                driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), 'accept')]")).Click();



                submitStory.Submit();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

                string pageName = driver.Title;

                var validationErrors = driver.FindElements(By.XPath(".//div[@class='input-error-message']"));

                Assert.Equal(expectegPageTitle, pageName);
                Assert.Single(validationErrors);
                Assert.Equal("can't be blank", validationErrors[0].Text);


            }
        }
    }
}
