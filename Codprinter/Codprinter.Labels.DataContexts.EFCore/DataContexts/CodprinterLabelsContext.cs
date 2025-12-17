using Codprinter.Labels.Application.POCOEntities;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Codprinter.Labels.DataContexts.EFCore.DataContexts;

internal class CodprinterLabelsContext(IOptions<DBOptions> options) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(options.Value.ConnectionString);
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
