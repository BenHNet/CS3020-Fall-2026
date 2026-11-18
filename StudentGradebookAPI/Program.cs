using Serilog;
using StudentGradebookLibrary.Repos;
using StudentGradebookLibrary.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Singleton because the managers can be reused by all the different controller
builder.Services.AddSingleton<ICourseInstanceManager, CourseInstanceManager>();
builder.Services.AddSingleton<ICourseManager, CourseManager>();
builder.Services.AddSingleton<IStudentManager, StudentManager>();
builder.Services.AddSingleton<IRepo>(new JsonRepo());
builder.Services.AddSingleton<IStudentCourseInstanceManager, StudentCourseInstanceManager>();

// NSwag: OpenAPI document + swagger UI
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Student Gradebook API";
    config.Version = "v1";
});

// Serilog config 
builder.Services.AddSerilog((services, loggerConfiguration) => loggerConfiguration
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        Path.Combine(builder.Environment.ContentRootPath, "Logs", "log-.txt"),
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 7));


var app = builder.Build();

// Serilog request logging 
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Log application start
app.Logger.LogInformation("Starting Student Gradebook API...");

app.Run();
