using Codprinter.Printers.Application.Dtos.GetPrinterByIp;

namespace Codprinter.Printers.Application.Interfaces.GetPrinterByIp;

public interface IGetPrinterByIpInputPort
{
    Task Handle(GetPrinterByIpRequest request);
}
