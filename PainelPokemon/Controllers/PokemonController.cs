using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainelPokemon.Data;
using PainelPokemon.Models.Pokemons;
using PainelPokemon.Models.Users;
using PainelPokemon.Repositories;



namespace PainelPokemon.Controllers
{
    public class PokemonController : Controller
    {
        private readonly ILogger<PokemonController> _logger;

        private readonly IPokemonRepository _pokemonRepository;

        private readonly PokeContext _context;



        public PokemonController(ILogger<PokemonController> logger,IPokemonRepository pokemonRepository, PokeContext context)
        {
            _logger = logger;
            _pokemonRepository = pokemonRepository;
            _context=context;
        }


        [Route("/pokemon/favorite")]
        public async Task<IActionResult> favorite()
        {

            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            
            var favoritePokemons =  _context.FavoritePokemons.ToListAsync().Result.Where(x => x.UserId == userId);
            var pokemons = new List<PokemonUnity>();
            HttpClient client = new HttpClient();
            foreach (var pokemonResult in favoritePokemons)
            {
                System.Uri uri = new System.Uri($"https://pokeapi.co/api/v2/pokemon/{pokemonResult.PokemonUnityId}");
                var pokemon = _pokemonRepository.GetOne(uri, client);
                pokemons.Add(pokemon);
            }
            return View(pokemons);

            
        }
        [Route("/pokemon/RemoveFavorite")]
        public async Task<IActionResult> RemoveFavorite(int id)
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var existingPokemon = await _context.FavoritePokemons.FirstOrDefaultAsync(p => p.PokemonUnityId == id && p.UserId == userId);
            Console.WriteLine(existingPokemon);
            if (existingPokemon != null) { 
                  _context.FavoritePokemons.Remove(existingPokemon);
                  await _context.SaveChangesAsync();

            }
            
           
            return Redirect("/pokemon/favorite");

        }






        [Route("/pokemon/Addfavorite")]
        public async Task<IActionResult> AddFavoritePokemon(int id)
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            HttpClient client = new HttpClient();
            System.Uri uri = new System.Uri($"https://pokeapi.co/api/v2/pokemon/{id}");

            var pokemonInfo =  _pokemonRepository.GetOne(uri, client);

            var existingPokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == pokemonInfo.Id);
            if (existingPokemon == null)
            {
                
                _context.Pokemons.Add(pokemonInfo);
                await _context.SaveChangesAsync();
            }
            var favoritesPokemons = await _context.FavoritePokemons.FirstOrDefaultAsync(x=> x.PokemonUnityId == pokemonInfo.Id && x.UserId==userId);
            if (favoritesPokemons == null)
            {

                var favoritePokemon = new FavoritePokemon
                {
                    UserId = user.Id,
                    PokemonUnityId = pokemonInfo.Id
                };
                _context.FavoritePokemons.Add(favoritePokemon);
                await _context.SaveChangesAsync();
            }

            

            return Redirect("/pokemon/favorite");
        }



        [Route("")]
        public IActionResult Pokemons(string? urlPast)
        {


            var url= "https://pokeapi.co/api/v2/pokemon/?offset=0&limit=10";
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