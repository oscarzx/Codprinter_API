using Codprinter.Printers.Application.Dtos.GetPrinterByName;

namespace Codprinter.Printers.Application.Interfaces.GetPrinterByName;

public interface IGetPrinterByNameInputPort
{
    Task Handle(GetPrinterByNameRequest request);
}
