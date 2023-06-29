public class BaggageHandlerUnsubscriberTests
{
    [Test]
    public void UnsubscriberDispose_WhenDispose_OnNextNotCalled()
    {
        // Arrange
        var baggageHandler = new BaggageHandler();
        var subscriber = new Mock<IObserver<BaggageInfo>>();
        var unsubscriber = baggageHandler.Subscribe(subscriber.Object);
        var baggageInfo = new BaggageInfo();

        // Act
        unsubscriber.Dispose();
        baggageHandler.UpdateBaggageInfo(baggageInfo);

        // Assert
        subscriber.Verify(x => x.OnNext(It.IsAny<BaggageInfo>()), Times.Never);
    }
}