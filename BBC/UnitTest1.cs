using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace BBC
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.bbc.com");
            }
        }

    }
}
