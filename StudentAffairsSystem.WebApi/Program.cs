using Asp.Versioning;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using StudentAffairsSystem.WebApi.Data;
using StudentAffairsSystem.WebApi.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Env.Load();
// Add services to the container.

// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true; // If no version is specified, use the default
    options.DefaultApiVersion = new ApiVersion(1, 0); // Set the default version to 1.0
    options.ReportApiVersions = true; // Include the version in the response header
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // Format version as 'v1'
    options.SubstituteApiVersionInUrl = true; // Substitute the version number in the URL
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<StudentAffairsDbContext>(options =>
    options.UseNpgsql(
        Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));

// Register repositories and UnitOfWork.
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.CreateDbIfNotExists();
}
else
{
    app.UseExceptionHandler("/error");
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Global routing with API versioning in the URL
app.MapControllers();
app.MapControllerRoute(
    "default",
    "api/v{version:apiVersion}/{controller}/{action=Index}/{id?}");


app.Run();