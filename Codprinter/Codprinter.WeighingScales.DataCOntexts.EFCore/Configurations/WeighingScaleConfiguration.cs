using Codprinter.WeighingScales.Application.POCOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codprinter.WeighingScales.DataContexts.EFCore.Configurations;

internal class WeighingScaleConfiguration : IEntityTypeConfiguration<WeighingScale>
{
    public void Configure(EntityTypeBuilder<WeighingScale> builder)
    {
        builder.ToTable("WeighingScales");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CreateBy)
            .IsRequired();

        builder.Property(x => x.WeighingScaleName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.WeighingScaleIp)
            .IsRequired()
            .HasMaxLength(45); // IPv4/IPv6

        builder.Property(x => x.WeighingScalePort)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasIndex(x => x.WeighingScaleIp)
            .IsUnique();

        builder.HasIndex(x => x.WeighingScaleName)
            .IsUnique();
    }
}
