using Codprinter.Printers.Application.Dtos.UpdatePrinter;

namespace Codprinter.Printers.Application.Interfaces.UpdatePrinter;

public interface IUpdatePrinterInputPort
{
    Task Handle(UpdatePrinterRequest request);
}
