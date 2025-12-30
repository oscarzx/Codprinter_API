using Codprinter.Printers.Application.Dtos.GetPrinterByName;

namespace Codprinter.Printers.Application.Interfaces.GetPrinterByName;

public interface IGetPrinterByNameOutputPort
{
    GetPrinterByNameResponse? Content { get; }
    void Handle(GetPrinterByNameResponse response);
}
