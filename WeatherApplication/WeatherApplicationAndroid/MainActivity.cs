using Android.App;
using Android.Widget;
using Android.OS;
using System;
using WeatherLibrary;
using Android.Content;
using Android.Preferences;

namespace WeatherApplicationAndroid
{
    [Activity(Label = "@string/ApplicationName")]  
    public class MainActivity : Activity
    {
        EditText locationInput;
        Button locationButton;
        WeatherInformation weatherInformation;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);
            locationInput = FindViewById<EditText>(Resource.Id.getLocationEditText);
            locationButton = FindViewById<Button>(Resource.Id.getLocationButton);
            weatherInformation = new WeatherInformation();

            locationButton.Click += locationButton_Click;
        }

        protected override void OnResume() 
        {
            base.OnResume();
            locationInput.Text = StaticValues.homeCity;
            string test = StaticValues.homeCity;
            getSharedPreferences();
        }

        private void getSharedPreferences()
        {
            ISharedPreferences locationPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            if (locationInput.Text == "" && StaticValues.homeCity == "")
            {
                locationInput.Text = locationPreferences.GetString("enteredLocation", "");
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            setSharedPreferences();
        }

        private void setSharedPreferences()
        {
            ISharedPreferences locationPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor locationEditor = locationPreferences.Edit();
            locationEditor.PutString("enteredLocation", locationInput.Text);
            locationEditor.Apply();
        }

        private void locationButton_Click(object sender, EventArgs e)
        {
            string enteredlocation = locationInput.Text;
            weatherInformation.getWeatherInformation(enteredlocation);

            Intent intent = new Intent(this, typeof(WeatherDisplay));

            if (weatherInformation.weather != null && weatherInformation.temperature != null && enteredlocation != "")
            {
                intent.PutExtra("homeCity", enteredlocation);
                intent.PutExtra("weather", weatherInformation.weather);
                intent.PutExtra("temperature", weatherInformation.temperature);             
            }
            else
            {
                intent.PutExtra("weather", "Location not recognised.\nPlease try again.");
            }

            StartActivity(intent);
        }
    }
}

