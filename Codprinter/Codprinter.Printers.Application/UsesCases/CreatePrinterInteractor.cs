using Codprinter.Printers.Application.Dtos.CreatePrinter;
using Codprinter.Printers.Application.Exceptions;
using Codprinter.Printers.Application.Interfaces.CreatePrinter;
using Codprinter.Printers.Application.Interfaces.Repositories;
using Codprinter.Printers.Application.Mappers;
using Codprinter.Printers.Domain;

namespace Codprinter.Printers.Application.UsesCases;

internal class CreatePrinterInteractor(
    IPrinterRepository repository,
    ICreatePrinterOutputPort outputPort) : ICreatePrinterInputPort
{
    public async Task Handle(CreatePrinterRequest request)
    {
        if(await repository.ExistsAsync(request.PrinterIp))
        {
            throw new PrinterAlreadyExistException("Ya existe una impresora con ese número de IP.");
        }

        Guid userId = Guid.NewGuid(); // This should be replaced with actual user ID retrieval logic
        var printer = new PrinterEntity(request.PrinterIp, request.PrinterPort, request.PrinterName, userId);
        await repository.AddAsync(printer.ToNewPrinter());
        await repository.SaveChanges();

        var response = new CreatePrinterResponse
        {
            Message = "Impresora creada correctamente.",
        };
        await outputPort.Handle(response);
    }
}
