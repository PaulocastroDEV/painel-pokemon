using Newtonsoft.Json;

namespace PainelPokemon.Models.Pokemons
{
    public class Result
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
