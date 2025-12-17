using Codprinter.Labels.Application.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codprinter.Labels.DataContexts.EFCore.Configuration
{
    internal class LabelVariableConfiguration : IEntityTypeConfiguration<LabelVariable>
    {
        public void Configure(EntityTypeBuilder<LabelVariable> builder)
        {
            builder.ToTable("label_variables");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("label_variable_id");
            builder.Property(x => x.LabelTemplateId).HasColumnName("label_template_id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.DisplayName).HasColumnName("display_name").IsRequired();
            builder.Property(x => x.DataType).HasColumnName("data_type").IsRequired();
            builder.Property(x => x.SourceType).HasColumnName("source_type").IsRequired();
            builder.Property(x => x.DefaultValue).HasColumnName("default_value");
            builder.Property(x => x.IsRequired).HasColumnName("is_required").HasDefaultValue(false);
            builder.Property(x => x.ValidationRuleJson).HasColumnName("validation_rule_json");
            builder.Property(x => x.CalculationExpr).HasColumnName("calculation_expr");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            // Unique constraint per template on (label_template_id, name)
            builder.HasIndex(x => new { x.LabelTemplateId, x.Name })
            .IsUnique()
            .HasDatabaseName("uq_label_variables");
        }
    }
}
