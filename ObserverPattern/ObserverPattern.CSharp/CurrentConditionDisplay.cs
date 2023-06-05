public class CurrentConditionDisplay : IObserver<WeatherData>
{
    public void OnCompleted()
    {
        System.Console.WriteLine("Current Condition: update completed");
    }

    public void OnError(Exception error)
    {
        throw error;
    }

    public void OnNext(WeatherData value)
    {
        System.Console.WriteLine($"Current Condition: temperature {value.Temperature} and humidity {value.Humidity}");
    }
}