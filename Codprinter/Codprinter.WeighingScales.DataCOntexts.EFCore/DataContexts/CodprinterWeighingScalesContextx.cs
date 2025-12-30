using Codprinter.Shared.Infrastructure.Options;
using Codprinter.WeighingScales.Application.POCOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Codprinter.WeighingScales.DataCOntexts.EFCore.DataContexts;

internal class CodprinterWeighingScalesContextx(IOptions<DBOptions> options) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(options.Value.ConnectionString);
    }

    public DbSet<WeighingScale> WeighingScales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
