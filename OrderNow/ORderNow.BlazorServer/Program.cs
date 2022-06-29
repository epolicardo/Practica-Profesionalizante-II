using Data.Entities;
using OrderNow.BlazorServer.Data;
using OrderNow.BlazorServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceProvider? sp;
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7269/") });
//builder.Services.AddHttpClient();
builder.Services.AddHttpClient("OrderNowApi", c =>
{
    c.BaseAddress = new Uri("https://localhost:7269/");
    c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services
    .AddScoped<IOrdersApiServices, OrdersApiServices>()
    .AddScoped<IGenericApiServices<Orders>, GenericApiServices<Orders>>(); ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
