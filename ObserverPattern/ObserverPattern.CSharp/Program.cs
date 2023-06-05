using (var weatherDataHandler = new WeatherDataHandler())
{
    var currentConditionDisplay = new CurrentConditionDisplay();
    var statisticsDisplay = new StatisticsDisplay();
    weatherDataHandler.Subscribe(currentConditionDisplay);
    weatherDataHandler.Subscribe(statisticsDisplay);
    weatherDataHandler.SetMeasurements(new WeatherData(80, 65, 30.4));
    weatherDataHandler.SetMeasurements(new WeatherData(82, 70, 29.2));
    weatherDataHandler.SetMeasurements(new WeatherData(78, 90, 30.4));
    weatherDataHandler.Complete();
}
