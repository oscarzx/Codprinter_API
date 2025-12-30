using Codprinter.Printers.Application.POCOs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodPrinter.Printers.DataContext.EFCore.DataContexts;

internal class CodprinterContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=CodprinterDB;Username=postgres;Password=2009");
    }

    public DbSet<Printer> Printers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
