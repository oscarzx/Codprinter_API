using Codprinter.Labels.Application.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codprinter.Labels.DataContexts.EFCore.Configuration
{
    internal class LabelTemplateConfiguration : IEntityTypeConfiguration<LabelTemplate>
    {
        public void Configure(EntityTypeBuilder<LabelTemplate> builder)
        {
            builder.ToTable("label_templates");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("label_template_id");
            builder.Property(x => x.TemplateName).HasColumnName("name").IsRequired();
            // Unique index on name and also serves fast lookup by name
            builder.HasIndex(x => x.TemplateName).IsUnique().HasDatabaseName("ix_label_templates_name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Dpi).HasColumnName("dpi").IsRequired();
            builder.Property(x => x.Units).HasColumnName("units").IsRequired();
            builder.Property(x => x.Width).HasColumnName("width_mm").HasColumnType("numeric(9,3)").IsRequired();
            builder.Property(x => x.Height).HasColumnName("height_mm").HasColumnType("numeric(9,3)").IsRequired();
            builder.Property(x => x.RawJson).HasColumnName("raw_json").IsRequired();
            builder.Property(x => x.ElementsJson).HasColumnName("elements_json");
            builder.Property(x => x.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(x => x.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("NOW()");
        }
    }
}
