using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.EntityTypeConfigurations
{
    public class ProducMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Stock).HasDefaultValueSql("0");
            builder.Property(p => p.Price).HasColumnType("decimal(14,2)");
            builder.Property(p => p.InnerBarcode).HasMaxLength(50);
        }
    }
}