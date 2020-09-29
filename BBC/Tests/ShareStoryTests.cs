using BBC.Pages;
using NUnit.Framework;


namespace BBC.Tests
{
    public class ShareStoryTests : BaseTest
    {
        private readonly string expectegPageTitle = "How to share your questions, stories, pictures and videos with BBC News - BBC News";
        private readonly string errorNameMessage = "Name can't be blank";
        private readonly string errorAcceptMessage = "must be accepted";
        private readonly string errorMessage = "can't be blank";
        private readonly string errorEmailMessage = "Email address is invalid";

        [Test]
        public void SubmitQuestionWithoutEnteringName()
        {
            //Arrange
            FormPage.OpenFormToShareYourCoronavirusStory();

            //Act
            FormDataPage.FillOutFormWithoutEnteringName(); 
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();

            //Assert
            Assert.AreEqual(expectegPageTitle, FormToSubmitPage.ActualPageTitle());
            Assert.AreEqual(1,FormToSubmitPage.AmountOfValidationErrors());
            Assert.AreEqual(errorNameMessage, FormToSubmitPage.ValidationErrors[0].Text);
        }

        [Test]
        public void SubmitQuestionWithoutAgreeingToTerms()
        {
            //Arrange
            FormPage.OpenFormToShareYourCoronavirusStory();

            //Act
            FormDataPage.FillOutFormWithoutAgreeingToTerms();
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();

            //Assert
            Assert.AreEqual(expectegPageTitle, FormToSubmitPage.ActualPageTitle());
            Assert.AreEqual(1, FormToSubmitPage.AmountOfValidationErrors());
            Assert.AreEqual(errorAcceptMessage, FormToSubmitPage.ValidationErrors[0].Text);
        }

        [Test]
        public void SubmitEmptyFormForQuestion()
        {
            //Arrange
            FormPage.OpenFormToShareYourCoronavirusStory();

            //Act
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();

            //Assert
            Assert.AreEqual(expectegPageTitle, FormToSubmitPage.ActualPageTitle());
            Assert.AreEqual(4, FormToSubmitPage.AmountOfValidationErrors());
            Assert.AreEqual(errorMessage, FormToSubmitPage.ValidationErrors[0].Text);
            Assert.AreEqual(errorNameMessage, FormToSubmitPage.ValidationErrors[1].Text);
            Assert.AreEqual(errorAcceptMessage, FormToSubmitPage.ValidationErrors[2].Text);
            Assert.AreEqual(errorAcceptMessage, FormToSubmitPage.ValidationErrors[3].Text);
        }

        [Test]
        public void SubmitQuestionUsingInvalidEmail()
        {
            //Arrange
            FormPage.OpenFormToShareYourCoronavirusStory();

            //Act
            FormDataPage.FillOutFormUsingInvalidEmail();
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();

            //Assert
            Assert.AreEqual(expectegPageTitle, FormToSubmitPage.ActualPageTitle());
            Assert.AreEqual(1,FormToSubmitPage.AmountOfValidationErrors());
            Assert.AreEqual(errorEmailMessage, FormToSubmitPage.ValidationErrors[0].Text);
        }

        [Test]
        public void SubmitFormWithEmptyTextFieldForStory()
        {
            //Arrange
            FormPage.OpenFormToShareYourCoronavirusStory();

            //Act
            FormDataPage.FillOutFormWithoutEnteringStoryText();
            FormToSubmitPage.SubmitYourStory();
            BasePage.ImplicitWait();

            //Assert
            Assert.AreEqual(expectegPageTitle, FormToSubmitPage.ActualPageTitle());
            Assert.AreEqual(1, FormToSubmitPage.AmountOfValidationErrors());
            Assert.AreEqual(errorMessage, FormToSubmitPage.ValidationErrors[0].Text);
        }
    }
}
