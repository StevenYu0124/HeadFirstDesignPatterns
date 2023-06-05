public class WeatherDataHandler : IObservable<WeatherData>, IDisposable
{
    private HashSet<IObserver<WeatherData>> _observers;

    public WeatherDataHandler()
    {
        _observers = new();
    }

    public IDisposable Subscribe(IObserver<WeatherData> observer)
    {
        _observers.Add(observer);
        return this;
    }

    public void Dispose()
    {
        _observers.Clear();
        System.Console.WriteLine("WeatherDataHandler dispose");
    }

    private void NotifyObserver(WeatherData data)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(data);
        }
    }

    private void MeasurementsChanged(WeatherData data)
    {
        NotifyObserver(data);
    }

    public void SetMeasurements(WeatherData data)
    {
        MeasurementsChanged(data);
    }

    public void Complete()
    {
        foreach (var observer in _observers)
        {
            observer.OnCompleted();
        }
    }
}