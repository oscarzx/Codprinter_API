using Codprinter.Printers.Application.Dtos.GetAllPrinters;

namespace Codprinter.Printers.Application.Interfaces.GetAllPrinters;

public interface IGetAllPrintersOutputPort
{
    GetAllPrintersResponse? Content { get; }
    void Handle(GetAllPrintersResponse response);
}
