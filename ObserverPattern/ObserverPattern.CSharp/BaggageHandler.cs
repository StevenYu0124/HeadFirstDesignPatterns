public sealed class BaggageHandler : IObservable<BaggageInfo>
{
    private HashSet<IObserver<BaggageInfo>> observers;
    private HashSet<BaggageInfo> baggageInfos;

    public BaggageHandler()
    {
        observers = new HashSet<IObserver<BaggageInfo>>();
        baggageInfos = new HashSet<BaggageInfo>();
    }

    public IDisposable Subscribe(IObserver<BaggageInfo> observer)
    {
        observers.Add(observer);
        return new Unsubscriber<BaggageInfo>(observers, observer);
    }

    public void UpdateBaggageInfo(BaggageInfo baggageInfo)
    {
        if (baggageInfos.Add(baggageInfo))
        {
            foreach (var observer in observers)
            {
                observer.OnNext(baggageInfo);
            }
        }
    }

    public void RemoveBaggageInfo(BaggageInfo baggageInfo)
    {
        if (baggageInfos.Remove(baggageInfo))
        {
            foreach (var observer in observers)
            {
                observer.OnNext(baggageInfo);
            }
        }
    }

    public void LastBaggageClaimed()
    {
        foreach (var observer in observers)
        {
            observer.OnCompleted();
        }
        baggageInfos.Clear();
    }

    private class Unsubscriber<BaggageInfo> : IDisposable
    {
        private readonly ISet<IObserver<BaggageInfo>> observers;
        private readonly IObserver<BaggageInfo> observer;

        public Unsubscriber(
            ISet<IObserver<BaggageInfo>> observers,
            IObserver<BaggageInfo> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            observers.Remove(observer);
        }
    }
}