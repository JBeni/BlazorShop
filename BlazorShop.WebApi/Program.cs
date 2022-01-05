
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("EnableCORS", builder =>
//    {
//        builder.AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//    });
//});

// Inject Architecture Layers
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

// Inject services
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddTransient<IEncryptionService, EncryptionService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers(options =>
    options.Filters.Add<ApiExceptionFilterAttribute>())
        .AddFluentValidation(x => x.AutomaticValidationEnabled = false);


// Add JWT TOKEN Settings
//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.Authority = builder.Configuration["JwtToken:Issuer"];
//    options.Audience = builder.Configuration["JwtToken:Audience"];
//    options.RequireHttpsMetadata = true;
//    options.SaveToken = true;

//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ClockSkew = TimeSpan.FromMinutes(5),
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:SecretKey"])),
//        RequireSignedTokens = true,
//        RequireExpirationTime = true,
//        ValidateLifetime = true,
//        ValidateAudience = true,
//        ValidateIssuer = true,
//        ValidAudience = builder.Configuration["JwtToken:Audience"],
//        ValidIssuer = builder.Configuration["JwtToken:Issuer"]
//    };
//});


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    try
//    {
//        var services = scope.ServiceProvider;
//        var context = services.GetRequiredService<ApplicationDbContext>();
//        if (context.Database.IsSqlServer())
//        {
//            context.Database.Migrate();
//        }
//        var userManager = services.GetRequiredService<UserManager<AppUser>>();
//        var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

//        var rolesSeed = new RolesSeedModel
//        {
//            AdminRoleName = builder.Configuration["RolesSeedModel:AdminRoleName"],
//            AdminRoleNormalizedName = builder.Configuration["RolesSeedModel:AdminRoleNormalizedName"],
//            UserRoleName = builder.Configuration["RolesSeedModel:UserRoleName"],
//            UserRoleNormalizedName = builder.Configuration["RolesSeedModel:UserRoleNormalizedName"],
//            DefaultRoleName = builder.Configuration["RolesSeedModel:DefaultRoleName"],
//            DefaultRoleNormalizedName = builder.Configuration["RolesSeedModel:DefaultRoleNormalizedName"],
//        };
//        var adminSeed = new AdminSeedModel
//        {
//            FirstName = builder.Configuration["AdminSeedModel:FirstName"],
//            LastName = builder.Configuration["AdminSeedModel:LastName"],
//            Email = builder.Configuration["AdminSeedModel:Email"],
//            Password = builder.Configuration["AdminSeedModel:Password"],
//            RoleName = builder.Configuration["AdminSeedModel:RoleName"],
//        };

//        await ApplicationDbContextSeed.SeedRolesAsync(roleManager, rolesSeed);
//        await ApplicationDbContextSeed.SeedAdminUserAsync(userManager, roleManager, adminSeed);
//    }
//    catch (Exception ex)
//    {
//        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
//        Log.Logger.Error(ex, "An error occurred while migrating or seeding the database.");
//        throw;
//    }
//}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseCors("EnableCORS");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});
