using Codprinter.Products.Application.POCOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codprinter.Products.DataContext.EFCore.Configurations;

internal sealed class ProductSiteConfiguration : IEntityTypeConfiguration<ProductSite>
{
    public void Configure(EntityTypeBuilder<ProductSite> builder)
    {
        builder.ToTable("Product_Site");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .HasColumnType("uuid")
        .ValueGeneratedNever();

        builder.Property(x => x.Site)
        .IsRequired()
        .HasColumnType("text");

        builder.Property(x => x.Barcode)
        .HasColumnType("text");

        builder.Property(x => x.PriceType)
        .HasColumnType("text");

        builder.Property(x => x.Clearance)
        .HasColumnType("text");

        builder.Property(x => x.ProductCode)
        .IsRequired()
        .HasColumnType("text");

        builder.Property(x => x.LegacyProductCode)
        .HasColumnType("text");

        builder.Property(x => x.ProductName)
        .HasColumnType("text");

        builder.Property(x => x.Price)
        .HasColumnType("numeric(18,2)");

        builder.HasIndex(x => new { x.Site, x.ProductCode })
        .IsUnique();

        // Relación lógica por ProductCode (sin navegación en Product POCO)
        builder.HasOne<Product>()
        .WithMany()
        .HasForeignKey(x => x.ProductCode)
        .HasPrincipalKey(x => x.ProductCode)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
