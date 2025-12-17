using Codprinter.Labels.Application.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codprinter.Labels.DataContexts.EFCore.Configuration
{
    internal class LabelElementsConfiguration : IEntityTypeConfiguration<LabelElements>
    {
        public void Configure(EntityTypeBuilder<LabelElements> builder)
        {
            builder.ToTable("label_elements");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("label_element_id");
            builder.Property(x => x.LabelTemplateId).HasColumnName("label_template_id").IsRequired();
            builder.Property(x => x.Type).HasColumnName("type").IsRequired();
            builder.Property(x => x.Xmm).HasColumnName("xmm").HasColumnType("numeric(9,3)").IsRequired();
            builder.Property(x => x.Ymm).HasColumnName("ymm").HasColumnType("numeric(9,3)").IsRequired();
            builder.Property(x => x.WidthMm).HasColumnName("width_mm").HasColumnType("numeric(9,3)");
            builder.Property(x => x.HeightMm).HasColumnName("height_mm").HasColumnType("numeric(9,3)");
            builder.Property(x => x.RotationDeg).HasColumnName("rotation_deg").HasColumnType("numeric(6,2)").HasDefaultValue(0);
            builder.Property(x => x.ZIndex).HasColumnName("z_index").IsRequired();
            builder.Property(x => x.PropsJson).HasColumnName("props_json").IsRequired();
            builder.Property(x => x.LabelVariableId).HasColumnName("label_variable_id");
            builder.Property(x => x.AssetId).HasColumnName("asset_id");

            builder.HasIndex(x => new { x.LabelTemplateId, x.ZIndex }).HasDatabaseName("ix_label_elements_template_z");
        }
    }
}
