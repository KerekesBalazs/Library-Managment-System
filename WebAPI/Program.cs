using Serilog;
using WebAPI.Configurations;
using Backend.Infrastructure.Configurations;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting up the application");
    var builder = WebApplication.CreateBuilder(args);

    Log.Information("Setting up the application");
    builder.Logging
        .ClearProviders()
        .AddSerilog(Log.Logger);

    // Add services to the container.
    builder.Services
        .AddBackendServices(builder.Configuration)
        .AddWebApiServices(builder.Configuration);

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


    var app = builder.Build();

    //// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    app.MapControllers();

    Log.Information("Application started successfully! Waiting for requests...");
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}