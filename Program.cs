using Blazored.Toast;
using Blazorise;
using BlazorStrap;
using GesConso;
using GesConso.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;


using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<StateContainer>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<Database>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")));
builder.Services.AddBlazorStrap();
//Ajout du service Toast
builder.Services.AddBlazoredToast();
builder.Services.AddBlazorise();
builder.Services.AddSyncfusionBlazor();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

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
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.MapRazorPages(); // Ajoutez cette ligne si elle n'est pas déjà présente


app.MapFallbackToPage("/commandedetails/{id}", "/commandeid/{id}");



app.Run();
