using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;

namespace WeatherApplicationAndroid
{
    [Activity(Theme = "@style/WeatherAppTheme_Splash", MainLauncher = true, Label = "@string/ApplicationName", NoHistory = true)] 
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override async void OnResume()    
        {
            base.OnResume();
            await Task.Delay(3000); // Simulates background startup work.
            StartActivity(new Intent(this, typeof(MainActivity)));
        }

        public override void OnBackPressed() { }
    }
}