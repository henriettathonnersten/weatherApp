using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using WeatherLibrary;

namespace WeatherLibraryTests
{
    [TestFixture]
    public class WeatherLibraryTest
    {
        private WeatherInformation weather = new WeatherInformation();

        [Test]
        public void checkForWeatherDescription()
        {
            string homeCity = "London";
            weather.getWeatherInformation(homeCity);
            NUnit.Framework.Assert.IsNotNull(weather.weather);
        }

        [Test]
        public void checkForTemperature()
        {
            string homeCity = "London";
            weather.getWeatherInformation(homeCity);
            NUnit.Framework.Assert.IsNotNull(weather.temperature);
        }

        [Test]
        public void checkForNotFoundLocation()
        {
            string enteredLocation = "NotAPlace123";
            weather.getWeatherInformation(enteredLocation);
            NUnit.Framework.Assert.IsNull(weather.weather);
        }

        [Test]
        public void getCorrectTemperature()
        {
            string temperature = "296.15";
            string actualTemperature = weather.updateTemperature(temperature);
            NUnit.Framework.Assert.AreEqual("23", actualTemperature);
        }

        [Test]
        public void getHomeCityWhenNoneIsStored()
        {
            NUnit.Framework.Assert.IsNull(StaticValues.homeCity);
        }

        [Test]
        public void getHomeCityWhenOneIsStored()
        {
            StaticValues.homeCity = "London";
            NUnit.Framework.Assert.AreEqual("London", StaticValues.homeCity);
        }
    }
}
