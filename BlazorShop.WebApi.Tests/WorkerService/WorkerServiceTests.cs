// <copyright file="WorkerServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WorkerService
{
    /// <summary>
    /// Tests for <see cref="Worker"/> class.
    /// </summary>
    public class WorkerServiceTests : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerServiceTests"/> class.
        /// </summary>
        public WorkerServiceTests()
        {
            this.Worker = new Worker(
                this.Logger,
                this.ServiceScopeFactory,
                this.HttpClient);
        }

        /// <summary>
        /// Gets the instance of the <see cref="Worker"/> to use.
        /// </summary>
        private Worker Worker { get; }

        /// <summary>
        /// Gets the instance of the <see cref="ILogger{Worker}"/> to use.
        /// </summary>
        private ILogger<Worker> Logger { get; } = Mock.Of<ILogger<Worker>>();

        /// <summary>
        /// Gets the instance of the <see cref="IServiceScopeFactory"/> to use.
        /// </summary>
        private IServiceScopeFactory ServiceScopeFactory { get; }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; } = Mock.Of<HttpClient>();

        /// <summary>
        /// A test for <see cref="Worker.ExecuteAsync(CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ExecuteAsync()
        {
            //// Arrange
            //var loggerMock = new Mock<ILogger<Worker>>();
            //var serviceScopeFactoryMock = new Mock<IServiceScopeFactory>();
            //var dbContextMock = new Mock<ApplicationDbContext>();
            //var subscriptions = new List<Subscriber> { new Subscriber { Status = SubscriptionStatus.Active, CurrentPeriodEnd = DateTime.Now.AddDays(-1), StripeSubscriberSubscriptionId = "subscriptionId" } };
            //dbContextMock.Setup(x => x.Subscribers).Returns((DbSet<Subscriber>)subscriptions.AsQueryable());
            //var scopeMock = new Mock<IServiceScope>();
            //scopeMock.Setup(x => x.ServiceProvider.GetRequiredService<ApplicationDbContext>()).Returns(dbContextMock.Object);
            //serviceScopeFactoryMock.Setup(x => x.CreateScope()).Returns(scopeMock.Object);
            //var httpClientMock = new Mock<HttpClient>();
            //var cancellationTokenSource = new CancellationTokenSource();

            //var worker = new Worker(loggerMock.Object, serviceScopeFactoryMock.Object, httpClientMock.Object);

            //// Act
            //await worker.StartAsync(cancellationTokenSource.Token);
            //await Task.Delay(1500);
            //await worker.StopAsync(cancellationTokenSource.Token);

            //// Assert
            //httpClientMock.Verify(x => x.DeleteAsync(It.Is<string>(s => s.Contains("cancel-subscription") && s.Contains("subscriptionId"))), Times.Once);
            //dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
            //Assert.Equal(SubscriptionStatus.Inactive, subscriptions[0].Status);

            //try
            //{
            //    while (!stoppingToken.IsCancellationRequested)
            //    {
            //        using var scope = this.ServiceScopeFactory.CreateScope();
            //        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //        var subscriptions = dbContext.Subscribers.Where(x => x.Status == SubscriptionStatus.Active).ToList();
            //        foreach (var subscription in subscriptions)
            //        {
            //            if (subscription.Status == SubscriptionStatus.Active && subscription.CurrentPeriodEnd > DateTime.Now)
            //            {
            //                await this.HttpClient.DeleteAsync($"https://localhost:44351/api/Payments/cancel-subscription/{subscription.StripeSubscriberSubscriptionId}");

            //                subscription.Status = SubscriptionStatus.Inactive;
            //                dbContext.Subscribers.Update(subscription);
            //                await dbContext.SaveChangesAsync(stoppingToken);
            //            }
            //        }

            //        this.Logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //        await Task.Delay(1000, stoppingToken);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex, "Error");
            //}
        }

        /// <summary>
        /// Ensure garbage collector.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
