using Codprinter.WeighingScales.Application.POCOs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Codprinter.WeighingScales.DataCOntexts.EFCore.DataContexts
{
    internal class CodprinterContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=CodprinterDB;Username=postgres;Password=2009");
        }

        public DbSet<WeighingScale> WeighingScales { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
