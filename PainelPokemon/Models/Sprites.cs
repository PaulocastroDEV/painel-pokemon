using Newtonsoft.Json;

namespace PainelPokemon.Models
{
    public class Sprites
    {

        [JsonProperty("front_default")]
        public Uri FrontDefault { get; private set; }
    }
}
