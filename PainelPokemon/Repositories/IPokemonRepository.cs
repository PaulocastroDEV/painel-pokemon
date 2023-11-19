using PainelPokemon.Models.Pokemons;

namespace PainelPokemon.Repositories
{
    public interface IPokemonRepository
    {
        public Pokemon GetAll(string url,HttpClient client);
        public PokemonUnity GetOne(Uri url, HttpClient client);
    }
}
