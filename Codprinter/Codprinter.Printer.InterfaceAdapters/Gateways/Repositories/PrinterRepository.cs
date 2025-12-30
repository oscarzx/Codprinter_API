using Codprinter.Printers.Application.Interfaces.Repositories;
using Codprinter.Printers.Application.POCOs;
using Codprinter.Printers.Domain;
using Codprinter.Printers.InterfaceAdapters.Gateways.Interfaces;

namespace Codprinter.Printers.InterfaceAdapters.Gateways.Repositories;

internal class PrinterRepository(
    ICodprinterPrintersCommandsDataContext context) : IPrinterRepository
{
    public async Task AddAsync(Printer printer)
        => await context.AddPrinterAsync(printer);

    public async Task<bool> ExistsAsync(string printerIp)
        => await context.ExistsPrinterAsync(printerIp);

    public async Task<IReadOnlyList<PrinterSummary>> GetAllAsync()
    {
        var printers = await context.GetAllPrintersAsync();
        return printers
            .Select(p => new PrinterSummary(
                p.Id,
                p.PrinterIp,
                p.PrinterPort,
                p.PrinterName,
                p.CreatedAt,
                p.CreatedBy))
            .ToList();
    }

    public async Task<PrinterSummary?> GetByNameAsync(string printerName)
    {
        var printer = await context.GetPrinterByNameAsync(printerName);
        if (printer is null) return null;

        return new PrinterSummary(
            printer.Id,
            printer.PrinterIp,
            printer.PrinterPort,
            printer.PrinterName,
            printer.CreatedAt,
            printer.CreatedBy);
    }

    public Task<Printer?> GetByIdAsync(Guid id)
        => context.GetPrinterByIdAsync(id);

    public Task UpdateAsync(Printer printer)
        => context.UpdatePrinterAsync(printer);

    public async Task SaveChanges()
        => await context.SaveChangesAsync();

    public async Task<IReadOnlyList<PrinterSummary>> SearchByNameAsync(string searchText)
    {
        var printers = await context.SearchPrintersByNameAsync(searchText);
        return printers
            .Select(p => new PrinterSummary(
                p.Id,
                p.PrinterIp,
                p.PrinterPort,
                p.PrinterName,
                p.CreatedAt,
                p.CreatedBy))
            .ToList();
    }

    public async Task<PrinterSummary?> GetByIpAsync(string printerIp)
    {
        var printer = await context.GetPrinterByIpAsync(printerIp);
        if (printer is null) return null;

        return new PrinterSummary(
            printer.Id,
            printer.PrinterIp,
            printer.PrinterPort,
            printer.PrinterName,
            printer.CreatedAt,
            printer.CreatedBy);
    }
}
