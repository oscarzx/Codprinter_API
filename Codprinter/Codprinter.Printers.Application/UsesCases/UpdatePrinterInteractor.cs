using Codprinter.Printers.Application.Dtos.UpdatePrinter;
using Codprinter.Printers.Application.Exceptions;
using Codprinter.Printers.Application.Interfaces.Repositories;
using Codprinter.Printers.Application.Interfaces.UpdatePrinter;

namespace Codprinter.Printers.Application.UsesCases;

internal sealed class UpdatePrinterInteractor(
 IPrinterRepository repository,
 IUpdatePrinterOutputPort outputPort) : IUpdatePrinterInputPort
{
    public async Task Handle(UpdatePrinterRequest request)
    {
        if (request.Id == Guid.Empty)
            throw new ArgumentException("Id es requerido.");

        if (string.IsNullOrWhiteSpace(request.PrinterName))
            throw new ArgumentException("PrinterName es requerido.");

        if (string.IsNullOrWhiteSpace(request.PrinterIp))
            throw new ArgumentException("PrinterIp es requerido.");

        var current = await repository.GetByIdAsync(request.Id);
        if (current is null)
            throw new PrinterNotFoundException($"No se encontró la impresora con id '{request.Id}'.");

        // Si cambia la IP, validar conflicto
        var normalizedIp = request.PrinterIp.Trim();
        if (!string.Equals(current.PrinterIp, normalizedIp, StringComparison.OrdinalIgnoreCase))
        {
            if (await repository.ExistsAsync(normalizedIp))
                throw new PrinterIpConflictException("Ya existe una impresora con ese número de IP.");
        }

        current.PrinterIp = normalizedIp;
        current.PrinterPort = request.PrinterPort;
        current.PrinterName = request.PrinterName.Trim();

        await repository.UpdateAsync(current);
        await repository.SaveChanges();

        outputPort.Handle(new UpdatePrinterResponse());
    }
}
