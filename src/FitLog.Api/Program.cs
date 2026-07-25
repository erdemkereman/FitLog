using FitLog.Api.Data;
using FitLog.Api.Interfaces;
using FitLog.Api.Repositories;
using FitLog.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddScoped<IExerciseService,ExerciseService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddDbContext<FitLogDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddOpenApi();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "FitLog API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();