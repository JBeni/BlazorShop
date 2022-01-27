namespace BlazorShop.Tests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;
        private static string _currentUserId;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var services = new ServiceCollection();

            //var startup = Program(_configuration);

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "BlazorShop.WebApi"));

            //startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new Table[] { "__EFMigrationsHistory" }
            };

            EnsureDatabase();
        }

        private void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.Migrate();
        }

        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("WebApiConnection"));

            _currentUserId = null;
        }

        public static async Task<TEntity> FindAsync<TEntity>(int id)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(id);
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }

        public static async Task<string> RunAsDefaultUserAsync()
        {
            var userName = "test@local";
            var password = "Testing1234!";

            using var scope = _scopeFactory.CreateScope();

            var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

            var user = new User { UserName = userName, Email = userName };

            var result = await userManager.CreateAsync(user, password);

            _currentUserId = user.Id.ToString();

            return _currentUserId;
        }
    }
}
