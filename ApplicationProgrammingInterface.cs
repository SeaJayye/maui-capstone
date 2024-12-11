using System;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace API_SQLite;

internal class RESTAPI
{
    private readonly HttpClient _httpClient;

    public RESTAPI()
    //method to get the API
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        // the API baseAddress             ^^                                 ^^
    }
    public class Timer_Class // model class
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
    public async Task<List<Timer_Class>> GetTimer_ClassAsync() // get method
    {
        var response = await _httpClient.GetAsync("Timers");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync(); // when the method works it will return the json

            return JsonSerializer.Deserialize<List<Timer_Class>>(json);
        }
        throw new HttpRequestException($"Request failed: {response.StatusCode}"); // catches errors
    }


    public async Task<Timer_Class> PostTimerAsync(Timer timer) // post method 
    {
        var json = JsonSerializer.Serialize(timer);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/Timers", content);

        if (response.IsSuccessStatusCode) // if it works it will return the json
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Timer_Class>(responseJson);
        }
        throw new HttpRequestException($"Request failed: {response.StatusCode}"); // catches exceptions
    }
}