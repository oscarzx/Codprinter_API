using Codprinter.Printers.Application.Dtos.GetPrinterByIp;
using Codprinter.Printers.Application.Interfaces.GetPrinterByIp;

namespace Codprinter.Printers.InterfaceAdapters.Presenters;

internal sealed class GetPrinterByIpPresenter : IGetPrinterByIpOutputPort
{
    public GetPrinterByIpResponse? Content { get; private set; }

    public void Handle(GetPrinterByIpResponse response)
    {
        Content = response;
    }
}
