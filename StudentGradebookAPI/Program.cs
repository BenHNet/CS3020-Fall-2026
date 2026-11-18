using StudentGradebookLibrary.Repos;
// using StudentGradebookLibrary.Managers;
using Serilog;

using StudentGradebookLibrary;
using StudentGradebookLibrary.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ICourseInstanceManager, CourseInstanceManager>();
builder.Services.AddSingleton<ICourseManager, CourseManager>();
builder.Services.AddScoped<IStudentManager, StudentManager>();

// One shared JsonRepo for the whole app
builder.Services.AddSingleton<IRepo>(new JsonRepo());

// Once StudentManager takes IRepo in its constructor
// builder.Services.AddSingleton<IStudentManager, StudentManager>();

// Once CourseManager takes IRepo in its constructor (no ICourseManager interface yet)
// builder.Services.AddSingleton<CourseManager>();

// Once CourseInstanceManager is made public and takes IRepo
// builder.Services.AddSingleton<CourseInstanceManager>();

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
