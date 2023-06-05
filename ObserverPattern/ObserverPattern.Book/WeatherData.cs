public class WeatherData : ISubject
{
    public double Temperature { get; private set; }
    public double Humidity { get; private set; }
    public double Pressure { get; private set; }

    public HashSet<IObserver> observers;
    public WeatherData()
    {
        observers = new();
    }
    public void NotifyObserver()
    {
        foreach (var observer in observers)
        {
            observer.Update(Temperature, Humidity, Pressure);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void MeasurementsChanged()
    {
        NotifyObserver();
    }

    public void SetMeasurements(double temperature, double humidity, double pressure)
    {
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
        MeasurementsChanged();
    }
}