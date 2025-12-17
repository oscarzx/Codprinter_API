using Codprinter.Labels.Application.POCOEntities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Codprinter.Labels.DataContexts.EFCore.DataContexts;

internal class CodprinterContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CodprinterDB;Username=postgres;Password=2009");
    }

    public DbSet<Label> Labels { get; set; }

    // New DbSets for the full label template graph
    public DbSet<LabelTemplate> LabelTemplates { get; set; }
    public DbSet<LabelVariable> LabelVariables { get; set; }
    public DbSet<DataBinding> DataBindings { get; set; }
    public DbSet<LabelElements> LabelElements { get; set; }
    public DbSet<Assets> Assets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
