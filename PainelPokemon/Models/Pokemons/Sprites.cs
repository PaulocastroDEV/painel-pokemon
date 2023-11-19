using Newtonsoft.Json;

namespace PainelPokemon.Models.Pokemons
{
    public class Sprites
    {
        public int Id { get; set; }

        [JsonProperty("front_default")]
        public Uri FrontDefault { get; private set; }
    }
}
