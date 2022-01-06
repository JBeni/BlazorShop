
using Microsoft.AspNetCore.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore(config =>
{
    config.AddPolicy("Admin", builder => builder.RequireClaim("Admin"));
    config.AddPolicy("User", new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole("User").Build());
    config.AddPolicy("Default", new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole("Default").Build());
});

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

// Inject Services
builder.Services.AddScoped<ClotheService>();
builder.Services.AddScoped<CartService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44351/api/") });

await builder.Build().RunAsync();
