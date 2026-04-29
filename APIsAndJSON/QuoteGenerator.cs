using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class QuoteGenerator
    { 
        public static string GetKanyeQuote()
        {
            var client = new HttpClient();
            
            var kanyeURL = "https://api.kanye.rest/";
            
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            return kanyeQuote;
        }
        
        public static string GetRonQuote()
        {
            var client = new HttpClient();
            
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            
            var ronResponse = client.GetStringAsync(ronURL).Result;
            
            var ronQuote = JArray.Parse(ronResponse)[0].ToString();
            
           return ronQuote;
        }
    }
}
