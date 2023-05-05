using OrderNow;
using OrderNow.Blazor.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderNow.Blazor.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ConexionLocal") ?? throw new InvalidOperationException("Connection string was not found.");

IConfiguration _ = new ConfigurationBuilder()
        .AddUserSecrets("3EA9A8FC-B75D-4300-883A-2609D5362685") //Nombre de la carpeta que hemos creado
            .Build();
builder.Services.AddApplicationServices(builder);
var app = builder.Build();

try
{
    await SeedData.SeedInitialData(app);
}
catch (Exception ex)
{
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapHub<BusinessHub>("/businesshub");
app.MapFallbackToPage("/_Host");

app.Run();