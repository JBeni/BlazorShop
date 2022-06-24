// <copyright file="Worker.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly HttpClient _httpClient;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory, HttpClient httpClient)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _httpClient = httpClient;
        }

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
                            await _httpClient.DeleteAsync($"https://localhost:44351/api/Payments/cancel-subscription/{subscription.StripeSubscriberSubscriptionId}");

                            subscription.Status = SubscriptionStatus.Inactive;
                            dbContext.Subscribers.Update(subscription);
                            await dbContext.SaveChangesAsync();
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
