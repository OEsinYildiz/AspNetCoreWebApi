using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Data.EntityTypeConfigurations;
using UdemyNLayerProject.Data.Seeds;

namespace UdemyNLayerProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSI\PRESTIGE; Database=UdemyNLayerProject; uid=sa; pwd=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProducMapping());
            modelBuilder.ApplyConfiguration(new PersonMapping());

            //Seeds
            modelBuilder.ApplyConfiguration(new CategorySeed(new[] {1, 2}));
            modelBuilder.ApplyConfiguration(new ProductSeed(new[] {1, 2}));
            base.OnModelCreating(modelBuilder);
        }
    }
}