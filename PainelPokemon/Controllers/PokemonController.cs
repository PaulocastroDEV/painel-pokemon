using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PainelPokemon.Models;
using PainelPokemon.Repositories;
using System.Diagnostics;


namespace PainelPokemon.Controllers
{
    public class PokemonController : Controller
    {
        private readonly ILogger<PokemonController> _logger;

        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(ILogger<PokemonController> logger,IPokemonRepository pokemonRepository)
        {
            _logger = logger;
            _pokemonRepository = pokemonRepository;
        }


        [HttpGet("")]
        public IActionResult Pokemons(string? urlPast)
        {
            var url= "https://pokeapi.co/api/v2/pokemon/?offset=0&limit=20";
            if (urlPast != null)
            {
                url = urlPast;
            }
            
            HttpClient client = new HttpClient();
            var pokemons = _pokemonRepository.GetAll(url,client);
            PokemonsResults pokemonResults = new PokemonsResults();
            pokemonResults.Pokemons=pokemons;

            foreach (var pokemonResult in pokemons.Results){

                var pokemon = _pokemonRepository.GetOne(pokemonResult.Url, client);
                pokemonResults.Pokemon.Add(pokemon);
            }
            return View(pokemonResults);


            
        }
    }
}