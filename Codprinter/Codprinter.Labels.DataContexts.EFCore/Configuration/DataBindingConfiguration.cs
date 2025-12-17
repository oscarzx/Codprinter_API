using Codprinter.Labels.Application.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codprinter.Labels.DataContexts.EFCore.Configuration
{
    internal class DataBindingConfiguration : IEntityTypeConfiguration<DataBinding>
    {
        public void Configure(EntityTypeBuilder<DataBinding> builder)
        {
            builder.ToTable("data_bindings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("data_binding_id");
            builder.Property(x => x.LabelVariableId).HasColumnName("label_variable_id").IsRequired();
            builder.Property(x => x.ConnectionName).HasColumnName("connection_name").IsRequired();
            builder.Property(x => x.QueryType).HasColumnName("query_type").IsRequired();
            builder.Property(x => x.TableName).HasColumnName("table_name");
            builder.Property(x => x.ColumnName).HasColumnName("column_name");
            builder.Property(x => x.SqlQuery).HasColumnName("sql_query");
            builder.Property(x => x.KeyMappingJson).HasColumnName("key_mapping_json");
            builder.Property(x => x.CacheTtlSeconds).HasColumnName("cache_ttl_seconds");

            // Index on label_variable_id for faster joins
            builder.HasIndex(x => x.LabelVariableId).HasDatabaseName("ix_data_bindings_variable");
        }
    }
}
