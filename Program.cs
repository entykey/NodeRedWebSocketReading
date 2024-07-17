using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NodeRedWebSocketReading.Data;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSignalR(); // Add SignalR service

builder.Services.AddSingleton<WebSocketService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Map the TemperatureHub
// app.MapHub<TemperatureHub>("/temperatureHub");

app.Run();
