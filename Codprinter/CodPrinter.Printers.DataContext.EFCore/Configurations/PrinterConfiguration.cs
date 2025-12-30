using Codprinter.Printers.Application.POCOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodPrinter.Printers.DataContext.EFCore.Configurations;

internal class PrinterConfiguration : IEntityTypeConfiguration<Printer>
{
    public void Configure(EntityTypeBuilder<Printer> builder)
    {
        builder.ToTable("Printers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CreatedBy)
            .IsRequired();

        builder.Property(x => x.PrinterIp)
            .IsRequired()
            .HasMaxLength(45); // IPv4/IPv6

        builder.Property(x => x.PrinterPort)
            .IsRequired();

        builder.Property(x => x.PrinterName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasIndex(x => x.PrinterIp)
            .IsUnique();

        builder.HasIndex(x => x.PrinterName)
            .IsUnique();
    }
}
