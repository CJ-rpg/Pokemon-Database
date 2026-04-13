using Microsoft.EntityFrameworkCore;
using Pokemon.BL.Logic;

namespace Pokemon.UI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<BL.Logic.Pokemon> Pokemons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ability> Ability { get; set; }
        public DbSet<PossibleAbilities> PossibleAbilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BL.Logic.Pokemon>()
                .ToTable("Pokemon");
            
            modelBuilder.Entity<Ability>()
                .ToTable("Abilities");

            modelBuilder.Entity<BL.Logic.Pokemon>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Pokemons)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<PossibleAbilities>()
             .HasOne(pa => pa.Pokemon)
             .WithMany(p => p.PossibleAbilities)
             .HasForeignKey(pa => pa.DexNum);

            modelBuilder.Entity<PossibleAbilities>()
                .HasOne(pa => pa.Ability)
                .WithMany(a => a.PossibleAbilities)
                .HasForeignKey(pa => pa.AbilityId);

            modelBuilder.Entity<PokemonTypes>()
                .HasKey(pt => new { pt.DexNum, pt.TypeId });

            modelBuilder.Entity<PokemonTypes>()
                .HasOne(pt => pt.Pokemon)
                .WithMany(p => p.PokemonTypes)
                .HasForeignKey(pt => pt.DexNum);

            modelBuilder.Entity<PokemonTypes>()
                .HasOne(pt => pt.Type)
                .WithMany(t => t.PokemonTypes)
                .HasForeignKey(pt => pt.TypeId);
        }
    }
}
