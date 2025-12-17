using Codprinter.Labels.Application.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codprinter.Labels.DataContexts.EFCore.Configuration;

internal class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.Property(l => l.LabelName).IsRequired()
               .HasMaxLength(100);
    }
}
