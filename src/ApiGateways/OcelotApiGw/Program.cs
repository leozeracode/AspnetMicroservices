using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder
    .Host
   .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
    })
.ConfigureLogging((hostingContext, loggingbuilder) =>
{
    hostingContext.Configuration.GetSection("Logging");
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});

builder.Services.AddOcelot(builder.Configuration).AddCacheManager((settings) =>
{
    settings.WithDictionaryHandle();
});

var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");


app.Run();
