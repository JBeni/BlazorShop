// <copyright file="Program.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

/// <summary>
/// The configurations for the background worker.
/// </summary>
try
{
    IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            IConfiguration configuration = hostContext.Configuration;

            services.AddHttpClient();
            services.AddDbContext<ApplicationDbContext>(opts =>
                  opts.UseSqlServer(
                    configuration["ConnectionStrings:WebApiConnection"],
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                  );

            services.AddHostedService<Worker>();
        })
        .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
