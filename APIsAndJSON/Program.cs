using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.IO;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        { 
            string key = File.ReadAllText("appsettings.json");
            string apiKey = JObject.Parse(key).GetValue("APIKey").ToString();
           
            Console.WriteLine("Please enter your zip code:");
            string zipCode = Console.ReadLine();

            double temp = OpenWeatherMapAPI.GetTemp(zipCode, apiKey);
            
            Console.WriteLine();
            Console.WriteLine($"It is currently {temp} degrees F in your location.");


            for (int i = 0; i < 5; i++)
            {

                string kanyeQuote = QuoteGenerator.GetKanyeQuote();
                string ronQuote = QuoteGenerator.GetRonQuote();

                Console.WriteLine("----------------------");
                Console.WriteLine($"Kanye: '{kanyeQuote}'");
                Console.WriteLine("----------------------");

                Console.WriteLine("----------------------");
                Console.WriteLine($"Ron: '{ronQuote}'");
                Console.WriteLine("----------------------");
            }
        }
    }
}