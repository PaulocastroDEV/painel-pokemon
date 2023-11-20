using Newtonsoft.Json;

namespace PainelPokemon.Models.Pokemons
{
    public class TypesPokemons
    {
        [JsonProperty("type")]
        public TypePokemon Type { get; set; }


    }

    public class TypePokemon {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}