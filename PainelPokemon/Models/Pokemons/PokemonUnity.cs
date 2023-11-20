using Newtonsoft.Json;
using PainelPokemon.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelPokemon.Models.Pokemons
{
    public class PokemonUnity
    {

        [JsonProperty("Id")]
        public int Id { get; set; }


        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("weight")]
        public int Weight { get; private set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; private set; }

        [NotMapped]
        [JsonProperty("types")]
        public TypesPokemons[] Type { get; private set; }

        





        public ICollection<FavoritePokemon> FavoritedByUsers { get; set; } = new List<FavoritePokemon>();
    }
   
}
