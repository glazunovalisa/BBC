using System.Collections.Generic;
using OpenQA.Selenium;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace BBC.Pages
{
    public class FormToSubmitPage : BasePage
    { 
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Submit')]")]
        public IWebElement SubmitStoryButton { get; private set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        public IList<IWebElement> ValidationErrors { get;  private set; }

        public FormToSubmitPage(IWebDriver driver) : base(driver) { }

        public void ScrollTillFormToSubmitIsVisible() => ScrollTillElementIsVisible(SubmitStoryButton);

        public void SubmitYourStory() => SubmitStoryButton.Submit();

        public int AmountOfValidationErrors() => ValidationErrors.Count;

        public string ActualPageTitle() => driver.Title;
    }
}
