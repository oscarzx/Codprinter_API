using Codprinter.Printers.Application.Dtos.GetAllPrinters;
using Codprinter.Printers.Application.Interfaces.GetAllPrinters;

namespace Codprinter.Printers.InterfaceAdapters.Presenters;

internal sealed class GetAllPrintersPresenter : IGetAllPrintersOutputPort
{
    public GetAllPrintersResponse? Content { get; private set; }

    public void Handle(GetAllPrintersResponse response)
    {
        Content = response;
    }
}
