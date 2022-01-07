
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore(config =>
{
    config.AddPolicy("AdminAdvanced", builder => builder.RequireAuthenticatedUser());

    config.AddPolicy("Admin", policy => policy.Requirements.Add(new AdminRoleRequirement("Admin")));
    config.AddPolicy("User", policy => policy.Requirements.Add(new UserRoleRequirement("User")));
    config.AddPolicy("Default", policy => policy.Requirements.Add(new DefaultRoleRequirement("Default")));
});

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddSingleton<IAuthorizationHandler, AdminRoleHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, UserRoleHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, DefaultRoleHandler>();

// Inject Services
builder.Services.AddScoped<ClotheService>();
builder.Services.AddScoped<CartService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44351/api/") });

await builder.Build().RunAsync();
