using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PainelPokemon.Models.Pokemons;

namespace PainelPokemon.Data.mappings
{
    public class FavoritePokemonMap: IEntityTypeConfiguration<FavoritePokemon>
    {
        public void Configure(EntityTypeBuilder<FavoritePokemon> builder)
        {
            builder.HasKey(fp => fp.Id);

            // Configuração das chaves estrangeiras

        }
    }
}
