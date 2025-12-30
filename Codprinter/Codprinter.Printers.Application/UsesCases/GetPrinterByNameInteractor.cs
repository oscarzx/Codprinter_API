using Codprinter.Printers.Application.Dtos.GetPrinterByName;
using Codprinter.Printers.Application.Interfaces.GetPrinterByName;
using Codprinter.Printers.Application.Interfaces.Repositories;
using Codprinter.Printers.Application.Mappers;

namespace Codprinter.Printers.Application.UsesCases;

internal sealed class GetPrinterByNameInteractor(
 IPrinterRepository repository,
 IGetPrinterByNameOutputPort outputPort) : IGetPrinterByNameInputPort
{
    public async Task Handle(GetPrinterByNameRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SearchText))
            throw new ArgumentException("SearchText es requerido.");

        var printers = await repository.SearchByNameAsync(request.SearchText);
        var response = printers.ToGetPrinterByNameResponse();
        outputPort.Handle(response);
    }
}
