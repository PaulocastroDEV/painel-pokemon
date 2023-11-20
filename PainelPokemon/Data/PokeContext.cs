using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PainelPokemon.Data.mappings;
using PainelPokemon.Models.Pokemons;
using PainelPokemon.Models.Users;

namespace PainelPokemon.Data
{
    public class PokeContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<PokemonUnity> Pokemons { get; set; }

        public DbSet<FavoritePokemon> FavoritePokemons { get; set; }


        public DbSet<TypePokemon> TypePokemons { get; set; }

        public PokeContext(DbContextOptions<PokeContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pokemon.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PokemonUnityMap());
            modelBuilder.ApplyConfiguration(new FavoritePokemonMap());
            modelBuilder.Entity<TypePokemon>().HasNoKey();
        }
    }
}
