using Books.Core.Extensions;
using Books.Infra.Extensions;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddInfra(builder.Configuration).AddCore();

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:3000"));
    });

    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services);
    });

    var app = builder.Build();


    await DbSeeder.Seed(app.Services);

    // Configure the HTTP request pipeline.

    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    app.UseCors();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed");
}
finally {
    Log.CloseAndFlush();
}

