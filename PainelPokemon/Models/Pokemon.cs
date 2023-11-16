using Newtonsoft.Json;


namespace PainelPokemon.Models
{
    public class Pokemon
    {
       /* [JsonProperty("count")]
        public int Count { get;  set; }
       */
        [JsonProperty("next")]
        public Uri Next { get;  set; }

        /*
        [JsonProperty("previous")]
        public object Previous { get; set; }
        */
        [JsonProperty("results")]
        public Result[] Results { get; set; }

    }
}
