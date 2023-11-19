using System.Text.Json.Serialization;
using PainelPokemon.Models.Pokemons;

namespace PainelPokemon.Models.Users
{
    public class User
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      
        public ICollection<FavoritePokemon> FavoritePokemons { get; set; } = new List<FavoritePokemon>();



    }
}
