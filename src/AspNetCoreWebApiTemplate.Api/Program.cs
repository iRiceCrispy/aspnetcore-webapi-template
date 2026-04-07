using Scalar.AspNetCore;

using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Application starting...");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog((services, lc) => lc
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services));

    builder.Services.AddOpenApi();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    app.UseHttpsRedirection();

    app.MapGet("/", () => "Hello, World!");

    app.Run();

    Log.Information("Application shut down.");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly\n");
}
finally
{
    Log.CloseAndFlush();
}
