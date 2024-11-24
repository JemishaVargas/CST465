using Microsoft.Extensions.Options;
using Midterm;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("JSON/MidtermQuestions.json");
});

builder.Services.Configure<MidtermExam>(builder.Configuration.GetSection("MidtermExam"));

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
