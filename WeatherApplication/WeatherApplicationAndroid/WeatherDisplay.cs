using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

using WeatherLibrary;
using Android.Preferences;

namespace WeatherApplicationAndroid
{
    [Activity (Label = "@string/ApplicationName")]
    public class WeatherDisplay : Activity
    {
        TextView locationDisplay;
        TextView weatherInformationDisplay;
        TextView temperatureInformationDisplay;
        Button locationSaveButton;
        private string homeCity;
        private string weather;
        private string temperature;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Weather);            
            locationDisplay = FindViewById<TextView>(Resource.Id.weatherLocationTextView);
            weatherInformationDisplay = FindViewById<TextView>(Resource.Id.weatherInformationTextView);
            temperatureInformationDisplay = FindViewById<TextView>(Resource.Id.temperatureInformationTextView);
            locationSaveButton = FindViewById<Button>(Resource.Id.saveLocationButton);

            homeCity = Intent.Extras.GetString("homeCity");
            weather = Intent.Extras.GetString("weather");
            temperature = Intent.Extras.GetString("temperature");            

            locationSaveButton.Click += locationSaveButton_Click;
        }

        protected override void OnResume()
        {
            base.OnResume();
            updateDisplay();            
        }

        private void locationSaveButton_Click(object sender, EventArgs e)
        {
            StaticValues.homeCity = homeCity;
        }

        private void updateDisplay()
        {
            if (homeCity != null)
            {
                locationDisplay.Text += homeCity;
                weatherInformationDisplay.Text += weather;
                temperatureInformationDisplay.Text += temperature + " C" + '\xB0';
            }
            else
            {
                locationDisplay.Text = weather;
                weatherInformationDisplay.Visibility = Android.Views.ViewStates.Gone;
                temperatureInformationDisplay.Visibility = Android.Views.ViewStates.Gone;
                locationSaveButton.Visibility = Android.Views.ViewStates.Gone;
            }
        }       
    }
}