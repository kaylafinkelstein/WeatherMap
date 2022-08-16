using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace WeatherMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What's the weather like where you're at? Please enter the city:");
                var city_name = Console.ReadLine().ToLower();
                Console.WriteLine("Now enter the state:");
                var state_code = Console.ReadLine().ToLower();
                Console.WriteLine("Please enter the country code (i.e. US for United States:");
                var country_code = Console.ReadLine().ToLower();
                var apiKey = ConfigurationManager.AppSettings["weatherAPIKey"];
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name},{state_code},{country_code}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose a different city and state?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if(userInput.ToLower() == "no")
                {
                    break;
                }
            }
        }
    }
}
