public class BaggageHandlerTests
{
    [Test]
    public void Subscribe_WhenCalled_ReturnIDisposable()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();

        // Act
        var result = baggageHandler.Subscribe(subscriber.Object);

        // Assert
        Assert.That(result, Is.AssignableTo<IDisposable>());
    }

    [Test]
    public void UpdateBaggageInfo_WhenCalled_ReturnVoid()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();
        baggageHandler.Subscribe(subscriber.Object);
        var baggageInfo = new BaggageInfo();

        // Act
        baggageHandler.UpdateBaggageInfo(baggageInfo);

        // Assert
        subscriber.Verify(x => x.OnNext(baggageInfo), Times.Once);
    }

    [Test]
    public void UpdateBaggageInfo_WhenCalledTwice_ReturnVoid()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();
        baggageHandler.Subscribe(subscriber.Object);
        var baggageInfo = new BaggageInfo();

        // Act
        baggageHandler.UpdateBaggageInfo(baggageInfo);
        baggageHandler.UpdateBaggageInfo(baggageInfo);

        // Assert
        subscriber.Verify(x => x.OnNext(baggageInfo), Times.Once);
    }
    
    [Test]
    public void RemoveBaggageInfo_WhenCalled_ReturnVoid()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();
        baggageHandler.Subscribe(subscriber.Object);
        var baggageInfo = new BaggageInfo();
        baggageHandler.UpdateBaggageInfo(baggageInfo);

        // Act
        baggageHandler.RemoveBaggageInfo(baggageInfo);

        // Assert
        subscriber.Verify(x => x.OnNext(baggageInfo), Times.Exactly(2));
    }

    [Test]
    public void RemoveBaggageInfo_WhenCalledTwice_ReturnVoid()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();
        baggageHandler.Subscribe(subscriber.Object);
        var baggageInfo = new BaggageInfo();
        baggageHandler.UpdateBaggageInfo(baggageInfo);

        // Act
        baggageHandler.RemoveBaggageInfo(baggageInfo);
        baggageHandler.RemoveBaggageInfo(baggageInfo);

        // Assert
        subscriber.Verify(x => x.OnNext(baggageInfo), Times.Exactly(2));
    }

    [Test]
    public void RemoveBaggageInfo_WhenCalledWithoutUpdate_ReturnVoid()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();
        baggageHandler.Subscribe(subscriber.Object);
        var baggageInfo = new BaggageInfo();

        // Act
        baggageHandler.RemoveBaggageInfo(baggageInfo);

        // Assert
        subscriber.Verify(x => x.OnNext(baggageInfo), Times.Never);
    }

    [Test]
    public void LastBaggageClaimed_WhenCalled_ReturnVoid()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();
        baggageHandler.Subscribe(subscriber.Object);

        // Act
        baggageHandler.LastBaggageClaimed();

        // Assert
        subscriber.Verify(x => x.OnCompleted(), Times.Once);
    }
}