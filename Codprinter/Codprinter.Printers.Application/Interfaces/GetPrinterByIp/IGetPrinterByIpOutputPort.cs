using Codprinter.Printers.Application.Dtos.GetPrinterByIp;

namespace Codprinter.Printers.Application.Interfaces.GetPrinterByIp;

public interface IGetPrinterByIpOutputPort
{
    GetPrinterByIpResponse? Content { get; }
    void Handle(GetPrinterByIpResponse response);
}
