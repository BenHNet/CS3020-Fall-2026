using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

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
