using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PainelPokemon.Models.Pokemons;

namespace PainelPokemon.Data.mappings
{
    public class PokemonUnityMap : IEntityTypeConfiguration<PokemonUnity>
    {
        public void Configure(EntityTypeBuilder<PokemonUnity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Weight).IsRequired();

          
        }
    }
}
