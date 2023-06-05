var weatherData = new WeatherData();
var currentConditionDisplay = new CurrentConditionDisplay();
var statisticsDisplay = new StatisticsDisplay();
weatherData.RegisterObserver(currentConditionDisplay);
weatherData.RegisterObserver(statisticsDisplay);
weatherData.SetMeasurements(80, 65, 30.4);
weatherData.SetMeasurements(82, 70, 29.2);
weatherData.SetMeasurements(78, 90, 30.4);