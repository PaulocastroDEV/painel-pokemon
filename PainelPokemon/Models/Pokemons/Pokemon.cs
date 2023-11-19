using Newtonsoft.Json;


namespace PainelPokemon.Models.Pokemons
{
    public class Pokemon
    {

        public int Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }


        public object Previous { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }

    }
}
