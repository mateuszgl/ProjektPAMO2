using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test2.Models;

namespace Test2.Services
{
    public class RestService
    {
        HttpClient client;
        readonly String apiKey = "&appid=6e25edeab81cd8ac1f886cd6394a1375&units=metric";

        public RestService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather?q="),
                MaxResponseContentBufferSize = 256000
            };
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicaiton/json"));

        }

        public async Task<WeatherObject> GetResponse(string city, string countryCode = "")
        {
            var url = client.BaseAddress + city;
            if (countryCode.Length != 0) url += "," + countryCode;
            url += apiKey;

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherObject>(content);
            }
            return null;
        }
    }

}
