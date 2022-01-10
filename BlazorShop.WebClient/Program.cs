
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44351/api/") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore(config =>
{
    config.AddPolicy("DefaultRole", builder => builder.RequireAuthenticatedUser());

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
builder.Services.AddScoped<IClotheService, ClotheService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();
