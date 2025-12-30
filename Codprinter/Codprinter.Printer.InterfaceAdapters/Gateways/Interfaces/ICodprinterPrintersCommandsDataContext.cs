using Codprinter.Printers.Application.POCOs;

namespace Codprinter.Printers.InterfaceAdapters.Gateways.Interfaces;

public interface ICodprinterPrintersCommandsDataContext
{
    Task AddPrinterAsync(Printer printer);
    Task<bool> ExistsPrinterAsync(string printerIp);
    Task<List<Printer>> GetAllPrintersAsync();
    Task<Printer?> GetPrinterByNameAsync(string printerName);
    Task<List<Printer>> SearchPrintersByNameAsync(string searchText);
    Task<Printer?> GetPrinterByIpAsync(string printerIp);
    Task<Printer?> GetPrinterByIdAsync(Guid id);
    Task UpdatePrinterAsync(Printer printer);
    Task SaveChangesAsync();
}
