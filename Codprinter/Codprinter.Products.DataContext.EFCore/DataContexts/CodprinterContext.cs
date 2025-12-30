using Codprinter.Products.Application.POCOs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Codprinter.Products.DataContext.EFCore.DataContexts;

internal class CodprinterContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=CodprinterDB;Username=postgres;Password=2009");
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
