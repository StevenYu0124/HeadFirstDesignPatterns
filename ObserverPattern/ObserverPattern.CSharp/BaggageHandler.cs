public sealed class BaggageHandler : IObservable<BaggageInfo>
{
    // thread safe
    // use ConcurrentDictionary to implement a thread safe hashset
    // https://stackoverflow.com/questions/18922985/concurrent-hashsett-in-net-framework
    private ConcurrentDictionary<IObserver<BaggageInfo>, byte> observers;
    private HashSet<BaggageInfo> baggageInfos;

    public BaggageHandler()
    {
        observers = new ConcurrentDictionary<IObserver<BaggageInfo>, byte>();
        baggageInfos = new HashSet<BaggageInfo>();
    }

    public IDisposable Subscribe(IObserver<BaggageInfo> observer)
    {
        observers.TryAdd(observer, 0);
        return new Unsubscriber<BaggageInfo>(observers, observer);
    }

    public void UpdateBaggageInfo(BaggageInfo baggageInfo)
    {
        if (baggageInfos.Add(baggageInfo))
        {
            foreach (var observer in observers.Keys)
            {
                try
                {
                    observer.OnNext(baggageInfo);
                }
                catch (Exception ex)
                {
                    observer.OnError(ex);
                }
            }
        }
    }

    public void RemoveBaggageInfo(BaggageInfo baggageInfo)
    {
        if (baggageInfos.Remove(baggageInfo))
        {
            foreach (var observer in observers.Keys)
            {
                try
                {
                    observer.OnNext(baggageInfo);
                }
                catch (Exception ex)
                {
                    observer.OnError(ex);
                }
            }
        }
    }

    public void LastBaggageClaimed()
    {
        foreach (var observer in observers.Keys)
        {
            observer.OnCompleted();
        }
        baggageInfos.Clear();
    }

    private class Unsubscriber<BaggageInfo> : IDisposable
    {
        private readonly ConcurrentDictionary<IObserver<BaggageInfo>, byte> observers;
        private readonly IObserver<BaggageInfo> observer;

        public Unsubscriber(
            ConcurrentDictionary<IObserver<BaggageInfo>, byte> observers,
            IObserver<BaggageInfo> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            observers.Remove(observer, out _);
        }
    }
}