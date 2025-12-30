using Codprinter.Products.Application.POCOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Codprinter.Products.DataContext.EFCore.Configurations
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .ValueGeneratedNever();

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(x => x.ProductCode)
                .IsRequired()
                .HasColumnType("text");

            // jsonb mapping
            builder.Property(x => x.CustomFields)
                .IsRequired()
                .HasColumnType("jsonb")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<Dictionary<string, object?>>(v, (JsonSerializerOptions?)null) ?? new());

            builder.HasIndex(x => x.ProductCode)
                .IsUnique();
        }
    }
}
