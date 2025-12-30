using Codprinter.Printers.Application.POCOs;
using Codprinter.Printers.InterfaceAdapters.Gateways.Interfaces;
using Codprinter.Shared.Infrastructure.Options;
using CodPrinter.Printers.DataContext.EFCore.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CodPrinter.Printers.DataContext.EFCore.Services
{
    internal sealed class CodprinterPrintersCommandsDataContext(IOptions<DBOptions> options) :
        CodprinterPrintersContext(options),
        ICodprinterPrintersCommandsDataContext
    {
        public async Task AddPrinterAsync(Printer printer)
            => await AddAsync(printer);

        public async Task<bool> ExistsPrinterAsync(string printerIp)
            => await Printers.AnyAsync(p => p.PrinterIp == printerIp);

        public async Task<List<Printer>> GetAllPrintersAsync()
            => await Printers
                .AsNoTracking()
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

        public async Task<Printer?> GetPrinterByNameAsync(string printerName)
            => await Printers
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrinterName == printerName);

        public async Task<List<Printer>> SearchPrintersByNameAsync(string searchText)
        {
            var term = (searchText ?? string.Empty).Trim();
            if (term.Length == 0)
                return new List<Printer>();

            return await Printers
                .AsNoTracking()
                .Where(p => EF.Functions.ILike(p.PrinterName, $"%{term}%"))
                .OrderBy(p => p.PrinterName)
                .ToListAsync();
        }

        public async Task<Printer?> GetPrinterByIdAsync(Guid id)
            => await Printers.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Printer?> GetPrinterByIpAsync(string printerIp)
            => await Printers
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrinterIp == printerIp);

        public Task UpdatePrinterAsync(Printer printer)
        {
            Printers.Update(printer);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
