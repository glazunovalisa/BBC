using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace BBC.Pages
{
    public class FormToSubmitPage
    {
        private readonly IWebDriver Driver;


        public FormToSubmitPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement SubmitStoryButton => Driver.FindElement(By.XPath(".//button[contains(text(), 'Submit')]"));

        private ReadOnlyCollection<IWebElement> ValidationErrors => Driver.FindElements(By.XPath(".//div[@class='input-error-message']"));

        
        public void ScrollTillFormToSubmitIsVisible()
        {
            var getBasePage = new BasePage(Driver);

            getBasePage.ScrollTillElementIsVisible(SubmitStoryButton);
        }

        public void SubmitYourStory()
        {
            SubmitStoryButton.Submit();
        }

        public ReadOnlyCollection<IWebElement> GetValidationErrors()
        {
            return ValidationErrors;
        }

        public int AmountOfValidationErrors()
        {
            return ValidationErrors.Count;
        }

        public string ActualPageTitle()
        {
            return Driver.Title;
        }
    }
}
