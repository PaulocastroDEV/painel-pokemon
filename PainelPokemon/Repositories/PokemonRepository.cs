using Newtonsoft.Json;
using PainelPokemon.Models;

namespace PainelPokemon.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {

        

        public Pokemon GetAll(string url, HttpClient client)
        {
            var response = client.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var pokemons = JsonConvert.DeserializeObject<Pokemon>(content);
            return pokemons;
        }

        public PokemonUnity GetOne(Uri url,HttpClient client)
        {
            var response = client.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var pokemon = JsonConvert.DeserializeObject<PokemonUnity>(content);
            return pokemon;
        }
    }
}
