using System;
using Newtonsoft.Json.Linq;

namespace WeatherFrontEnd;

public partial class MainPage : ContentPage
{

    static async Task<String> Weather(string city)
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=1c297bb9968380cd3ef70d5c3c77c9dc&lang=ua&units=metric");
        var content = await response.Content.ReadAsStringAsync();

        return content;
    }

    public MainPage()
    {
        InitializeComponent();
    }

    void OnEntryCompleted(object sender, EventArgs e)
    {
        string city = ((Entry)sender).Text;
    }

    static async Task Method(string city)
    {
        var json = JObject.Parse(await Weather(city));
    }
}