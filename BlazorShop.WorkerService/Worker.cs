// <copyright file="Worker.cs" author="Beniamin Jitca">
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
        /// .
        /// </summary>
        private readonly ILogger<Worker> _logger;

        /// <summary>
        /// .
        /// </summary>
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// .
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serviceScopeFactory"></param>
        /// <param name="httpClient"></param>
        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory, HttpClient httpClient)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _httpClient = httpClient;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var subscriptions = dbContext.Subscribers.Where(x => x.Status == SubscriptionStatus.Active).ToList();
                    foreach (var subscription in subscriptions)
                    {
                        if (subscription.Status == SubscriptionStatus.Active && subscription.CurrentPeriodEnd > DateTime.Now)
                        {
                            await this._httpClient.DeleteAsync($"https://localhost:44351/api/Payments/cancel-subscription/{subscription.StripeSubscriberSubscriptionId}");

                            subscription.Status = SubscriptionStatus.Inactive;
                            dbContext.Subscribers.Update(subscription);
                            await dbContext.SaveChangesAsync(stoppingToken);
                        }
                    }

                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
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
