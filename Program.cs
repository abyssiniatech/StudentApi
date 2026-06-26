
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Tms.Api.Services;
using TmsApi.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<TmsDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("TmsDatabase")
    )
);
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure middleware
app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}



// Map controllers
app.MapControllers();

app.Run();

