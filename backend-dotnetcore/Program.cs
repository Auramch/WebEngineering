using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using RUG.WebEng.Properties.Models;
using RUG.WebEng.Properties.Repositories;

DotNetEnv.Env.TraversePath().NoClobber().LoadMulti(new[] { ".env", "dotnet.env" });

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Using database connection string: {dbConnectionString}");
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<PropertyRepository>();
builder.Services.AddScoped<LocationRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Indicate we would like ENUM values to be converted to strings in their
    // JSON representation, as opposed to meaningless integers
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config =>
{
    config.EnableAnnotations(); // we will use attributes for further specification
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", builder =>
        builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
    );
});

var app = builder.Build();

#if false
    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    await DatabaseSeeder.InitializeAsync(context);
#endif

app.UseCors("default");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Find all Controller classes/implementations in the current application and
// register their routes and operations.
app.MapControllers();

// Run the app
app.Run();