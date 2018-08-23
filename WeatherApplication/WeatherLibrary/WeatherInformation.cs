using Newtonsoft.Json;
using System.Net.Http;

namespace WeatherLibrary
{
    public class WeatherInformation
    {
        public string weather { get; set; }
        public string temperature { get; set; }

        public async void getWeatherInformation(string enteredLocation)
        {
            using (var client = new HttpClient())
            {
                string url = "http://api.openweathermap.org/data/2.5/weather?q=" + enteredLocation + "&appid=e2fd64acd68dd588026a4d0384ad6b1b";
                var result = await client.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject<Weather>(content);

                    weather = json.weather[0].main;
                    string degreesFromAbsoluteZero = json.main.temp;
                    temperature = updateTemperature(degreesFromAbsoluteZero);
                }
            }
        }

        public string updateTemperature(string degreesFromAbsoluteZero)
        {
            double actualTemperature = double.Parse(degreesFromAbsoluteZero);
            actualTemperature += -273.15;
            return actualTemperature.ToString();
        }      
    }
}
