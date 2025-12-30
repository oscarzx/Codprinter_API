using Codprinter.Printers.Application.Dtos.CreatePrinter;

namespace Codprinter.Printers.Application.Interfaces.CreatePrinter;

public interface ICreatePrinterOutputPort
{
    CreatePrinterResponse Content { get; }
    Task Handle(CreatePrinterResponse response);
}
