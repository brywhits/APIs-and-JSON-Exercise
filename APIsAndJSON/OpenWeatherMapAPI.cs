using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static double GetTemp(string zipcode,  string apiKey)
        {
            var client = new HttpClient();
            
            var apiURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipcode}&units=imperial&appid={apiKey}";
            
            var response = client.GetStringAsync(apiURL).Result;
            
            var temp = double.Parse(JObject.Parse(response)["main"]["temp"].ToString());
            
            return temp;
        }
    }
}
