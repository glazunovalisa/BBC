using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class FormDataPage
    {
        private readonly IWebDriver Driver;


        public FormDataPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='Tell us your story. ']")]
        private IWebElement FieldForYourStory { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        private IWebElement FieldForYourEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Contact number ']")]
        private IWebElement FieldForYourPhoneNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Location ']")]
        private IWebElement FieldForLocation { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='checkbox__text']//p[contains(text(), '16')]")]
        private IWebElement CheckBoxOlderThan16 { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='checkbox__text']//p[contains(text(), 'accept')]")]
        private IWebElement CheckboxAcceptTerms { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name']")]
        private IWebElement FieldForYourName { get; set; }


        public void EnterTextOfYourStory() => FieldForYourStory.SendKeys("Very important story lol");

        public void EnterValidEmail() => FieldForYourEmail.SendKeys("randombutvalidemail@gmail.com");

        public void EnterInvalidEmail() => FieldForYourEmail.SendKeys("randsomandinvalidemail.com");

        public void EnterYourPhoneNumber() => FieldForYourPhoneNumber.SendKeys("1");

        public void EnterYourLocation() => FieldForLocation.SendKeys("Chioggia");

        public void ConfirmThatYouAreOlderThan16() => CheckBoxOlderThan16.Click();

        public void AcceptTerms() => CheckboxAcceptTerms.Click();

        public void EnterYourName() => FieldForYourName.SendKeys("blabla");
    }
}
