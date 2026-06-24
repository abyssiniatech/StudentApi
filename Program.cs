
using Microsoft.EntityFrameworkCore;
using TmsApi.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();


builder.Services.AddDbContext<TmsDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("TmsDatabase")
    )
);


var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();

// Map controllers
app.MapControllers();

app.Run();

