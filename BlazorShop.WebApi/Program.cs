try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .WriteTo.File(
            builder.Configuration["Serilog:JsonPath"],
            Serilog.Events.LogEventLevel.Information
         )
        .CreateBootstrapLogger();

    Log.Information("Starting up");

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("EnableCORS", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    // Inject Architecture Layers
    builder.Services.AddApplicationLayer();
    builder.Services.AddInfrastructureLayer(builder.Configuration);
    builder.Services.AddUnitOfWorkLayer();

    builder.Services.AddHttpContextAccessor();

    builder.Services.AddControllers(options =>
        options.Filters.Add<ApiExceptionFilterAttribute>())
            .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

    // Add JWT TOKEN Settings
    builder.Services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.Audience = builder.Configuration["JwtToken:Audience"];
            options.RequireHttpsMetadata = true;
            options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.FromMinutes(5),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:SecretKey"])),
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = builder.Configuration["JwtToken:Audience"],
                ValidIssuer = builder.Configuration["JwtToken:Issuer"]
            };
        });


    // Stripe Configuration - Secret Key
    StripeConfiguration.ApiKey = builder.Configuration["StripeSettings:SecretKey"];

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<Role>>();

            var rolesSeed = new RolesSeedModel
            {
                AdminRoleName = builder.Configuration["RolesSeedModel:AdminRoleName"],
                AdminRoleNormalizedName = builder.Configuration["RolesSeedModel:AdminRoleNormalizedName"],
                UserRoleName = builder.Configuration["RolesSeedModel:UserRoleName"],
                UserRoleNormalizedName = builder.Configuration["RolesSeedModel:UserRoleNormalizedName"],
                DefaultRoleName = builder.Configuration["RolesSeedModel:DefaultRoleName"],
                DefaultRoleNormalizedName = builder.Configuration["RolesSeedModel:DefaultRoleNormalizedName"],
            };
            var adminSeed = new AdminSeedModel
            {
                FirstName = builder.Configuration["AdminSeedModel:FirstName"],
                LastName = builder.Configuration["AdminSeedModel:LastName"],
                Email = builder.Configuration["AdminSeedModel:Email"],
                Password = builder.Configuration["AdminSeedModel:Password"],
                RoleName = builder.Configuration["AdminSeedModel:RoleName"],
            };

            await ApplicationDbContextSeed.SeedRolesAsync(roleManager, rolesSeed);
            await ApplicationDbContextSeed.SeedAdminUserAsync(userManager, roleManager, adminSeed);
            await ApplicationDbContextSeed.SeedClothesDataAsync(context);
            await ApplicationDbContextSeed.SeedMusicsDataAsync(context);
            await ApplicationDbContextSeed.SeedSubscriptionsDataAsync(context);
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex, "An error occurred while migrating or seeding the database.");
            throw;
        }
    }

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

    app.UseCors("EnableCORS");
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseMiddleware<JwtTokenMiddleware>();
    
    //app.UseSerilogRequestLogging();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");
        endpoints.MapControllers();
    });

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
