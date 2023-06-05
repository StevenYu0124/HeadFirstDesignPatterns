public class StatisticsDisplay : IObserver<WeatherData>
{
    private List<double> temperatureList;

    public StatisticsDisplay()
    {
        temperatureList = new();
    }

    public void OnCompleted()
    {
        System.Console.WriteLine("Statistic: update completed");
    }

    public void OnError(Exception error)
    {
        throw error;
    }

    public void OnNext(WeatherData value)
    {
        temperatureList.Add(value.Temperature);
        System.Console.WriteLine($"Statistics: temperature Max {temperatureList.Max()} / Min {temperatureList.Min()} / Avg {temperatureList.Average()}");
    }
}