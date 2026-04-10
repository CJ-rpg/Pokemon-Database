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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BL.Logic.Pokemon>()
                .ToTable("Pokemon");

            modelBuilder.Entity<BL.Logic.Pokemon>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Pokemons)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
