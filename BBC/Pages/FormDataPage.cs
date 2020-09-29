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

        public void FillOutFormWithoutEnteringName()
        {
            FieldForYourStory.SendKeys(textOfYourStory);
            FillOutPrincipalFields();
            TickCheckBoxes();
        }

        public void FillOutFormWithoutEnteringStoryText()
        {
            FillOutPrincipalFields();
            FieldForYourName.SendKeys(yourName);
            TickCheckBoxes();
        }

        public void FillOutFormWithoutAgreeingToTerms()
        {
            FillOutPrincipalFields();
            EnterYourNameAndStory();
            CheckBoxOlderThan16.Click();
        }

        public void FillOutFormUsingInvalidEmail()
        {
            EnterYourNameAndStory();
            FieldForYourEmail.SendKeys(invalidEmail);
            FieldForYourPhoneNumber.SendKeys(phoneNumber);
            FieldForLocation.SendKeys(city);
            TickCheckBoxes();
        }

        private void TickCheckBoxes()
        {
            CheckBoxOlderThan16.Click();
            CheckboxAcceptTerms.Click();
        }

        private void FillOutPrincipalFields()
        {
            FieldForYourEmail.SendKeys(validEmail);
            FieldForYourPhoneNumber.SendKeys(phoneNumber);
            FieldForLocation.SendKeys(city);
        }

        private void EnterYourNameAndStory()
        {
            FieldForYourStory.SendKeys(textOfYourStory);
            FieldForYourName.SendKeys(yourName);
        }
    }
}
