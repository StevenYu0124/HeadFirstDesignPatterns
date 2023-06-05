public class StatisticsDisplay : IObserver, IDisplay
{
    private List<double> temperatureList;

    public StatisticsDisplay()
    {
        temperatureList = new();
    }

    public void Update(double temperature, double humidity, double pressure)
    {
        temperatureList.Add(temperature);
        Display();
    }

    public void Display()
    {
        System.Console.WriteLine($"Statistics: temperature Max {temperatureList.Max()} / Min {temperatureList.Min()} / Avg {temperatureList.Average()}");
    }
}