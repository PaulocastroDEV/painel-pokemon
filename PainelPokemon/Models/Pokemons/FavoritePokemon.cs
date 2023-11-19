using Newtonsoft.Json;
using PainelPokemon.Models.Users;

namespace PainelPokemon.Models.Pokemons
{
    public class FavoritePokemon
    {
        public int Id { get; set; }

  
        public int UserId { get; set; }
      
        public int PokemonUnityId { get; set; }
        
    }
}
