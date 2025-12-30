using Codprinter.Printers.Application.Dtos.UpdatePrinter;

namespace Codprinter.Printers.Application.Interfaces.UpdatePrinter;

public interface IUpdatePrinterOutputPort
{
    UpdatePrinterResponse? Content { get; }
    void Handle(UpdatePrinterResponse response);
}
