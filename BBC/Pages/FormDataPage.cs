using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages
{
    public class FormDataPage : BasePage
    {
        private readonly string textOfYourStory = "very important story";
        private readonly string validEmail = "randombutvalidemail@gmail.com";
        private readonly string invalidEmail = "randsomandinvalidemail.com";
        private readonly string phoneNumber = "123";
        private readonly string city = "Chioggia";
        private readonly string yourName = "qwerty";

        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='Tell us your story. ']")]
        public IWebElement FieldForYourStory { get; private set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email address']")]
        public IWebElement FieldForYourEmail { get; private set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Contact number ']")]
        public IWebElement FieldForYourPhoneNumber { get; private set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Location ']")]
        public IWebElement FieldForLocation { get; private set; }
        [FindsBy(How = How.XPath, Using = "//span[@class='checkbox__text']//p[contains(text(), '16')]")]
        public IWebElement CheckBoxOlderThan16 { get; private set; }
        [FindsBy(How = How.XPath, Using = "//span[@class='checkbox__text']//p[contains(text(), 'accept')]")]
        public IWebElement CheckboxAcceptTerms { get; private set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Name']")]
        public IWebElement FieldForYourName { get; private set; }

        public FormDataPage(IWebDriver driver) : base(driver) { }

        public void EnterTextOfYourStory() => FieldForYourStory.SendKeys(textOfYourStory);

        public void EnterValidEmail() => FieldForYourEmail.SendKeys(validEmail);

        public void EnterInvalidEmail() => FieldForYourEmail.SendKeys(invalidEmail);

        public void EnterYourPhoneNumber() => FieldForYourPhoneNumber.SendKeys(phoneNumber);

        public void EnterYourLocation() => FieldForLocation.SendKeys(city);

        public void ConfirmThatYouAreOlderThan16() => CheckBoxOlderThan16.Click();

        public void AcceptTerms() => CheckboxAcceptTerms.Click();

        public void EnterYourName() => FieldForYourName.SendKeys(yourName);
    }
}
