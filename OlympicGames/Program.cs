using OlympicGames.Models; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICountrySportService, CountrySportService>();

var app = builder.Build();

app.UseStaticFiles(); 
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CountrySport}/{action=Index}/{id?}"
);

app.Run();
