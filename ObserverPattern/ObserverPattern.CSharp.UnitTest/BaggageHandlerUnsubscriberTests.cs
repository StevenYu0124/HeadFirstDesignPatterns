public class BaggageHandlerUnsubscriberTests
{
    [Test]
    public void UnsubscriberDispose_WhenCalled_ReturnVoid()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();
        var disposable = baggageHandler.Subscribe(subscriber.Object);

        // Act
        disposable.Dispose();

        // Assert
    }
}