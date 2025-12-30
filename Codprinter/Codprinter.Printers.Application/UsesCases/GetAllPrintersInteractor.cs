using Codprinter.Printers.Application.Dtos.GetAllPrinters;
using Codprinter.Printers.Application.Interfaces.GetAllPrinters;
using Codprinter.Printers.Application.Interfaces.Repositories;
using Codprinter.Printers.Application.Mappers;

namespace Codprinter.Printers.Application.UsesCases;

internal sealed class GetAllPrintersInteractor(
 IPrinterRepository repository,
 IGetAllPrintersOutputPort outputPort) : IGetAllPrintersInputPort
{
    public async Task Handle(GetAllPrintersRequest request)
    {
        var printers = await repository.GetAllAsync();
        var response = printers.ToGetAllPrintersResponse();
        outputPort.Handle(response);
    }
}
