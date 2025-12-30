using Codprinter.Printers.Application.POCOs;
using Codprinter.Printers.Domain;
using Codprinter.Shared.Application.UnitOfWork;

namespace Codprinter.Printers.Application.Interfaces.Repositories;

public interface IPrinterRepository : IUnitOfWork
{
    Task AddAsync(Printer printer);
    Task<bool> ExistsAsync(string printerIp);

    Task<IReadOnlyList<PrinterSummary>> GetAllAsync();
    Task<PrinterSummary?> GetByNameAsync(string printerName);
    Task<IReadOnlyList<PrinterSummary>> SearchByNameAsync(string searchText);
    Task<PrinterSummary?> GetByIpAsync(string printerIp);

    Task<Printer?> GetByIdAsync(Guid id);
    Task UpdateAsync(Printer printer);
}
