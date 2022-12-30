// <copyright file="Worker.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WorkerService
{
    /// <summary>
    /// A service for the background worker.
    /// </summary>
    public class Worker : BackgroundService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        /// <param name="logger">The instance of the <see cref="ILogger{Worker}"/> to use.</param>
        /// <param name="serviceScopeFactory">The instance of the <see cref="IServiceScopeFactory"/> to use.</param>
        /// <param name="httpClient">The instance of the <see cref="HttpClient"/> to use.</param>
        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory, HttpClient httpClient)
        {
            this.Logger = logger;
            this.ServiceScopeFactory = serviceScopeFactory;
            this.HttpClient = httpClient;
        }

        /// <summary>
        /// Gets the instance of the <see cref="ILogger{Worker}"/> to use.
        /// </summary>
        private ILogger<Worker> Logger { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IServiceScopeFactory"/> to use.
        /// </summary>
        private IServiceScopeFactory ServiceScopeFactory { get; }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; }

        /// <summary>
        /// The background task to execute the instructions.
        /// </summary>
        /// <param name="stoppingToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    using var scope = this.ServiceScopeFactory.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var subscriptions = dbContext.Subscribers.Where(x => x.Status == SubscriptionStatus.Active).ToList();
                    foreach (var subscription in subscriptions)
                    {
                        if (subscription.Status == SubscriptionStatus.Active && subscription.CurrentPeriodEnd > DateTime.Now)
                        {
                            await this.HttpClient.DeleteAsync($"https://localhost:44351/api/Payments/cancel-subscription/{subscription.StripeSubscriberSubscriptionId}");

                            subscription.Status = SubscriptionStatus.Inactive;
                            dbContext.Subscribers.Update(subscription);
                            await dbContext.SaveChangesAsync(stoppingToken);
                        }
                    }

                    this.Logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error");
            }
        }
    }
}
