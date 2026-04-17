using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            
            var APIKey = 

            var geoURL =
                "https://api.openweathermap.org/geo/1.0/direct?q=Springfield,MA,US&limit=1&appid=d7202b4499e566bac9938ffeca077f73";
            
            HttpResponseMessage geoResponse = await client.GetAsync(geoURL);
            var geoJson = await geoResponse.Content.ReadAsStringAsync();
            JArray geoArray = JArray.Parse(geoJson);

            double lat = (double)geoArray[0]["lat"];
            double lon = (double)geoArray[0]["lon"];
            
            var weatherURL =
                $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=d7202b4499e566bac9938ffeca077f73";

            var weatherResponse = await client.GetStringAsync(weatherURL);
            JObject weatherObj = JObject.Parse(weatherResponse);
            
            string city = weatherObj["name"].ToString();

            string description =
                weatherObj["weather"][0]["description"].ToString();

            double kelvin = (double)weatherObj["main"]["temp"];
            
            double fahrenheit = (kelvin - 273.15) * 9 / 5 + 32;
            
            Console.WriteLine("🌤 WEATHER REPORT 🌤");
            Console.WriteLine($"City: {city}");
            Console.WriteLine($"Condition: {description}");
            Console.WriteLine($"Temperature: {fahrenheit:F1}°F");
        }
    }
}
