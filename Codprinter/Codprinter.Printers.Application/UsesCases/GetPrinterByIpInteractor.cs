using Codprinter.Printers.Application.Dtos.GetPrinterByIp;
using Codprinter.Printers.Application.Exceptions;
using Codprinter.Printers.Application.Interfaces.GetPrinterByIp;
using Codprinter.Printers.Application.Interfaces.Repositories;
using Codprinter.Printers.Application.Mappers;

namespace Codprinter.Printers.Application.UsesCases;

internal sealed class GetPrinterByIpInteractor(
 IPrinterRepository repository,
 IGetPrinterByIpOutputPort outputPort) : IGetPrinterByIpInputPort
{
    public async Task Handle(GetPrinterByIpRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.PrinterIp))
            throw new ArgumentException("PrinterIp es requerido.");

        var printer = await repository.GetByIpAsync(request.PrinterIp.Trim());
        if (printer is null)
            throw new PrinterNotFoundException($"No se encontró una impresora con la IP '{request.PrinterIp}'.");

        outputPort.Handle(printer.ToGetPrinterByIpResponse());
    }
}
