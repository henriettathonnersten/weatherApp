using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Xamarin.UITest;
using WeatherLibrary;
using Xamarin.UITest.Queries;

namespace WeatherApplicationGherkinTests
{
    [Binding]
    public sealed class StepDefinitionMain
    {
        private IApp app;
        private string city = "London";
        private WeatherInformation weather = new WeatherInformation();

        [Given(@"there is no stored home city")]
        public void checkForNoStoredHomeCity()
        {
            StaticValues.homeCity = ""; 
            app = ConfigureApp.Android.StartApp();            
        }

        [Given(@"that (.*) has been stored as the home city")]
        public void checkForStoredHomeCity(string homeCity)
        {
            StaticValues.homeCity = homeCity;
        }

        [When(@"the app starts")]
        public void waitForStartPageToDisplay()
        {
            app.WaitForElement(c => c.Marked("getLocationTextView"));
        }

        [Then(@"the input field should be empty")]
        public void checkForEmptyInputField()
        {
            app.WaitForElement(c => c.Id("getLocationEditText"));
            AppResult[] location = app.Query(c => c.Id("getLocationEditText"));
            Assert.That(location[0].Text, Is.EqualTo(""));
        }

        [Then(@"the input field should contain the word (.*)")]
        public void checkForInputFieldWithContent(string homeCity)
        {
            app.WaitForElement(c => c.Id("getLocationEditText"));
            AppResult[] location = app.Query(c => c.Id("getLocationEditText"));
            Assert.That(location[0].Text, Does.Contain(homeCity).IgnoreCase);
        }

        [Given(@"there is no input in the input field")]
        public void tryLocationWithoutInput()
        {
            app = ConfigureApp.Android.StartApp();
            app.ClearText(c => c.Id("getLocationEditText"));
        }

        [Given(@"that (.*) is entered in the input field")]
        public void tryLocationWithInput(string input)
        {
            app = ConfigureApp.Android.StartApp();
            app.EnterText(c => c.Id("getLocationEditText"), input);
            app.DismissKeyboard();
        }

        [When(@"the Get My Weather-button is clicked")]
        public void pressButton()
        {
            app.Tap(c => c.Marked("getLocationButton"));  
        }

        [Then(@"a warning message should be shown")]
        public void displayErrorMessage()
        {
            app.WaitForElement(c => c.Id("errorMessageTextView"));
            AppResult[] location = app.Query(c => c.Id("errorMessageTextView"));
            Assert.That(location[0].Text, Is.EqualTo("Location not recognised.\nPlease try again."));
        }

        [Then(@"the app should display weather information on a new page")]
        public void displayNewPage()
        {
            app.WaitForElement(c => c.Marked("WeatherDisplay"));
            AppResult[] weatherLocation = app.Query(c => c.Id("getLocationEditText"));
            Assert.That(weatherLocation[0].Text, Does.Contain(city).IgnoreCase);
        }
    }
}
