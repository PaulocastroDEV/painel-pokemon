
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PainelPokemon.Data;
using PainelPokemon.Models.Users;
using PainelPokemon.Repositories;

using Newtonsoft;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddDbContext<PokeContext>(options =>
    options.UseSqlite("Datasource = pokemon.db"));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pokemon}/{action=Pokemons}/{id?}");

app.Run();
