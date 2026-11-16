using StudentGradebookLibrary.Repos;
// using StudentGradebookLibrary.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();