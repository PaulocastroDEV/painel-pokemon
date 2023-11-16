using Newtonsoft.Json;

namespace PainelPokemon.Models
{
    public class PokemonUnity
    {

        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("weight")]
        public int Weight{  get; private set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; private set; }
    }
}
