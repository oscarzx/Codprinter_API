using Codprinter.Printers.Application.Dtos.GetAllPrinters;

namespace Codprinter.Printers.Application.Interfaces.GetAllPrinters;

public interface IGetAllPrintersInputPort
{
    Task Handle(GetAllPrintersRequest request);
}
