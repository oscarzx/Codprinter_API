using Codprinter.Labels.Application.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codprinter.Labels.DataContexts.EFCore.Configuration
{
    internal class AssetsConfiguration : IEntityTypeConfiguration<Assets>
    {
        public void Configure(EntityTypeBuilder<Assets> builder)
        {
            builder.ToTable("assets");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("asset_id");
            builder.Property(x => x.Type).HasColumnName("type").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.MimeType).HasColumnName("mime_type").IsRequired();
            builder.Property(x => x.StorageUrl).HasColumnName("storage_url");
            builder.Property(x => x.BinaryData).HasColumnName("binary_data").IsRequired();
            builder.Property(x => x.Checksum).HasColumnName("checksum");
            builder.Property(x => x.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");

            // Recommended indexes
            builder.HasIndex(x => new { x.Type, x.Name }).HasDatabaseName("ix_assets_type_name");
            builder.HasIndex(x => x.Checksum).IsUnique().HasFilter("checksum IS NOT NULL").HasDatabaseName("uq_assets_checksum");
        }
    }
}
