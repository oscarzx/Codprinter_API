using Codprinter.Printers.Application.Dtos.GetPrinterByName;
using Codprinter.Printers.Application.Interfaces.GetPrinterByName;

namespace Codprinter.Printers.InterfaceAdapters.Presenters;

internal sealed class GetPrinterByNamePresenter : IGetPrinterByNameOutputPort
{
    public GetPrinterByNameResponse? Content { get; private set; }

    public void Handle(GetPrinterByNameResponse response)
    {
        Content = response;
    }
}
