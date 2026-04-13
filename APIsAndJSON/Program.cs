using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            
            for (int i = 0; i < 5; i++)
            {
                string ronResponse = await client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes");
                JArray ronArray = JArray.Parse(ronResponse);
                string ronQuote = ronArray[0].ToString();
                
                string kanyeResponse = await client.GetStringAsync("https://api.kanye.rest");
                JObject kanyeObject = JObject.Parse(kanyeResponse);
                string kanyeQuote = kanyeObject["quote"].ToString();
                
                Console.WriteLine("Ron: " + ronQuote);
                Console.WriteLine("Kanye: " + kanyeQuote);
                Console.WriteLine();
            }
        }
    }
}
