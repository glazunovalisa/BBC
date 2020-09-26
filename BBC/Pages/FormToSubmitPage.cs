using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace BBC.Pages
{
    public class FormToSubmitPage : BasePage
    { 
        public FormToSubmitPage(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Submit')]")]
        private IWebElement SubmitStoryButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        public IList<IWebElement> ValidationErrors { get; set; }


        public void ScrollTillFormToSubmitIsVisible()
        {
            var getBasePage = new BasePage(driver);

            getBasePage.ScrollTillElementIsVisible(SubmitStoryButton);
        }

        public void SubmitYourStory() => SubmitStoryButton.Submit();

        public IList<IWebElement> GetValidationErrors() => ValidationErrors;

        public int AmountOfValidationErrors() => ValidationErrors.Count;

        public string ActualPageTitle() => driver.Title;
    }
}
