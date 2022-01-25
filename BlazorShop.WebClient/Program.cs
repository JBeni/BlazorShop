
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44351/api/") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddOptions();
builder.Services.AddMatBlazor();
builder.Services.AddAuthorizationCore(config =>
{
    config.AddPolicy(StringRoleResources.Customer, policy => policy.Requirements.Add(new CustomerRoleRequirement()));

    config.AddPolicy(StringRoleResources.Admin, policy => policy.Requirements.Add(new AdminRoleRequirement(StringRoleResources.Admin)));
    config.AddPolicy(StringRoleResources.User, policy => policy.Requirements.Add(new UserRoleRequirement(StringRoleResources.User)));
    config.AddPolicy(StringRoleResources.Default, policy => policy.Requirements.Add(new DefaultRoleRequirement(StringRoleResources.Default)));
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddSingleton<IAuthorizationHandler, AdminRoleHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, UserRoleHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, DefaultRoleHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, CustomerRoleHandler>();

// Inject Services
builder.Services.AddTransient<IClotheService, ClotheService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IMusicService, MusicService>();
builder.Services.AddTransient<IReceiptService, ReceiptService>();
builder.Services.AddTransient<ISubscriptionService, SubscriptionService>();
builder.Services.AddTransient<ISubscriberService, SubscriberService>();
builder.Services.AddTransient<IStripeService, StripeService>();

await builder.Build().RunAsync();
