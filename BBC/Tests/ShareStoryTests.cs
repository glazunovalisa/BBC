using System;
using BBC.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;


namespace BBC
{
    public class ShareStoryTests 
    {
        
        private readonly string expectegPageTitle = "How to share your questions, stories, pictures and videos with BBC News - BBC News";
        private readonly string errorNameMessage = "Name can't be blank";
        private readonly string errorAcceptMessage = "must be accepted";
        private readonly string errorMessage = "can't be blank";
        private readonly string errorEmailMessage = "Email address is invalid";

        [Fact]
        [Obsolete]
        public void SubmitQuestionWithoutEnteringName()
        {

            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getFormPage = new FormPage(driver);
            var getFormToSubmitPage = new FormToSubmitPage(driver);
            var getFormDataPage = new FormDataPage(driver);
            var getBasePage = new BasePage(driver);

            //Act
            getFormPage.OpenFormToShareYourCoronavirusStory();

            getFormDataPage.EnterTextOfYourStory();
            getFormDataPage.EnterValidEmail();
            getFormDataPage.EnterYourPhoneNumber();
            getFormDataPage.EnterYourLocation();
            getFormDataPage.ConfirmThatYouAreOlderThan16();
            getFormDataPage.AcceptTerms();

            getFormToSubmitPage.SubmitYourStory();
            getBasePage.ImplicitWait();

            //Assert
            Assert.Equal(expectegPageTitle, getFormToSubmitPage.ActualPageTitle());
            Assert.Equal(1,getFormToSubmitPage.AmountOfValidationErrors());
            Assert.Equal(errorNameMessage, getFormToSubmitPage.GetValidationErrors()[0].Text);
        }


        [Fact]
        [Obsolete]
        public void SubmitQuestionWithoutAgreeingToTerms()
        {
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getFormPage = new FormPage(driver);
            var getFormToSubmitPage = new FormToSubmitPage(driver);
            var getFormDataPage = new FormDataPage(driver);
            var getBasePage = new BasePage(driver);

            //Act
            getFormPage.OpenFormToShareYourCoronavirusStory();

            getFormDataPage.EnterTextOfYourStory();
            getFormDataPage.EnterYourName();
            getFormDataPage.EnterValidEmail();
            getFormDataPage.EnterYourPhoneNumber();
            getFormDataPage.EnterYourLocation();
            getFormDataPage.ConfirmThatYouAreOlderThan16();
            
            getFormToSubmitPage.SubmitYourStory();
            getBasePage.ImplicitWait();

            //Assert
            Assert.Equal(expectegPageTitle, getFormToSubmitPage.ActualPageTitle());
            Assert.Equal(1, getFormToSubmitPage.AmountOfValidationErrors());
            Assert.Equal(errorAcceptMessage, getFormToSubmitPage.GetValidationErrors()[0].Text);
        }


        [Fact]
        [Obsolete]
        public void SubmitEmptyFormForQuestion()
        {
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getFormPage = new FormPage(driver);
            var getFormToSubmitPage = new FormToSubmitPage(driver);
            var getFormDataPage = new FormDataPage(driver);
            var getBasePage = new BasePage(driver);

            //Act
            getFormPage.OpenFormToShareYourCoronavirusStory();

            getFormToSubmitPage.SubmitYourStory();
            getBasePage.ImplicitWait();

            //Assert
            Assert.Equal(expectegPageTitle, getFormToSubmitPage.ActualPageTitle());
            Assert.Equal(4, getFormToSubmitPage.AmountOfValidationErrors());
            Assert.Equal(errorMessage, getFormToSubmitPage.GetValidationErrors()[0].Text);
            Assert.Equal(errorNameMessage, getFormToSubmitPage.GetValidationErrors()[1].Text);
            Assert.Equal(errorAcceptMessage, getFormToSubmitPage.GetValidationErrors()[2].Text);
            Assert.Equal(errorAcceptMessage, getFormToSubmitPage.GetValidationErrors()[3].Text);
        }

        [Fact]
        [Obsolete]
        public void SubmitQuestionUsingInvalidEmail()
        {
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getFormPage = new FormPage(driver);
            var getFormToSubmitPage = new FormToSubmitPage(driver);
            var getFormDataPage = new FormDataPage(driver);
            var getBasePage = new BasePage(driver);

            //Act
            getFormPage.OpenFormToShareYourCoronavirusStory();

            getFormDataPage.EnterTextOfYourStory();
            getFormDataPage.EnterYourName();
            getFormDataPage.EnterInvalidEmail();
            getFormDataPage.EnterYourPhoneNumber();
            getFormDataPage.EnterYourLocation();
            getFormDataPage.ConfirmThatYouAreOlderThan16();
            getFormDataPage.AcceptTerms();

            getFormToSubmitPage.SubmitYourStory();
            getBasePage.ImplicitWait();

            //Assert
            Assert.Equal(expectegPageTitle, getFormToSubmitPage.ActualPageTitle());
            Assert.Equal(1,getFormToSubmitPage.AmountOfValidationErrors());
            Assert.Equal(errorEmailMessage, getFormToSubmitPage.GetValidationErrors()[0].Text);
        }

        [Fact]
        [Obsolete]
        public void SubmitFormWithEmptyTextFieldForStory()
        {
            //Arrange
            using IWebDriver driver = new ChromeDriver();
            var getFormPage = new FormPage(driver);
            var getFormToSubmitPage = new FormToSubmitPage(driver);
            var getFormDataPage = new FormDataPage(driver);
            var getBasePage = new BasePage(driver);

            //Act
            getFormPage.OpenFormToShareYourCoronavirusStory();

            getFormDataPage.EnterYourName();
            getFormDataPage.EnterValidEmail();
            getFormDataPage.EnterYourPhoneNumber();
            getFormDataPage.EnterYourLocation();
            getFormDataPage.ConfirmThatYouAreOlderThan16();
            getFormDataPage.AcceptTerms();

            getFormToSubmitPage.SubmitYourStory();
            getBasePage.ImplicitWait();

            //Assert
            Assert.Equal(expectegPageTitle, getFormToSubmitPage.ActualPageTitle());
            Assert.Equal(1, getFormToSubmitPage.AmountOfValidationErrors());
            Assert.Equal(errorMessage, getFormToSubmitPage.GetValidationErrors()[0].Text);
        }
    }
}
