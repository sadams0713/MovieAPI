namespace MovieAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }


        //You can set up a listener on properties
        //Temperature F has a listener on Temperature C
        //Every time Temp C updates, Temp F gets run
        //Very useful in thousands of small ways, and super useful in game development

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}