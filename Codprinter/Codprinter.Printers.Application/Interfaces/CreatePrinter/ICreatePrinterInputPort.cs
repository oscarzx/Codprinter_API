using Codprinter.Printers.Application.Dtos.CreatePrinter;

namespace Codprinter.Printers.Application.Interfaces.CreatePrinter;

public interface ICreatePrinterInputPort
{
    Task Handle(CreatePrinterRequest request);
}
