public class CurrentConditionDisplay : IObserver, IDisplay
{
    private double temperature;
    private double humidity;

    public void Update(double temperature, double humidity, double pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }

    public void Display()
    {
        System.Console.WriteLine($"Current Condition: temperature {temperature} and humidity {humidity}");
    }
}