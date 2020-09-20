using System;
using OpenQA.Selenium;

namespace BBC.Pages
{
    public class FormDataPage
    {
        private readonly IWebDriver Driver;


        public FormDataPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement FieldForYourStory => Driver.FindElement(By.XPath(".//textarea[@placeholder='Tell us your story. ']"));

        private IWebElement FieldForYourEmail => Driver.FindElement(By.XPath(".//input[@placeholder='Email address']"));

        private IWebElement FieldForYourPhoneNumber => Driver.FindElement(By.XPath(".//input[@placeholder='Contact number ']"));

        private IWebElement FieldForLocation => Driver.FindElement(By.XPath(".//input[@placeholder='Location ']"));

        private IWebElement CheckBoxOlderThan16 => Driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), '16')]"));

        private IWebElement CheckboxAcceptTerms => Driver.FindElement(By.XPath(".//span[@class='checkbox__text']//p[contains(text(), 'accept')]"));

        private IWebElement FieldForYourName => Driver.FindElement(By.XPath(".//input[@placeholder='Name']"));


        public void EnterTextOfYourStory()
        {
            FieldForYourStory.SendKeys("Very important story lol");
        }
           
        public void EnterValidEmail()
        {
            FieldForYourEmail.SendKeys("randombutvalidemail@gmail.com");
        }

        public void EnterInvalidEmail()
        {
            FieldForYourEmail.SendKeys("randsomandinvalidemail.com");
        }

        public void EnterYourPhoneNumber()
        {
            FieldForYourPhoneNumber.SendKeys("1");
        }

        public void EnterYourLocation()
        {
            FieldForLocation.SendKeys("Chioggia");
        }

        public void ConfirmThatYouAreOlderThan16()
        {
            CheckBoxOlderThan16.Click();
        }

        public void AcceptTerms()
        {
            CheckboxAcceptTerms.Click();
        }

        public void EnterYourName()
        {
            FieldForYourName.SendKeys("blabla");
        }
    }
}
