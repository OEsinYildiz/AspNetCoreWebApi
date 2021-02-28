using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product {Id = 1, CategoryId = _ids[0], Name = "Tukenmez Kalem", Price = 10.20m, Stock = 100},
                new Product {Id = 2, CategoryId = _ids[0], Name = "Kursun Kalem", Price = 11.20m, Stock = 140},
                new Product {Id = 3, CategoryId = _ids[0], Name = "Siyah Kalem", Price = 4.20m, Stock = 150},
                new Product {Id = 4, CategoryId = _ids[1], Name = "Kirmizi Kalem", Price = 6.20m, Stock = 165},
                new Product {Id = 5, CategoryId = _ids[1], Name = "Yesil Kalem", Price = 9.20m, Stock = 132},
                new Product {Id = 6, CategoryId = _ids[1], Name = "Basmali Kalem", Price = 21.20m, Stock = 112}
            );
        }
    }
}