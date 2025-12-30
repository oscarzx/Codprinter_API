using Codprinter.Printers.Application.Dtos.UpdatePrinter;
using Codprinter.Printers.Application.Interfaces.UpdatePrinter;

namespace Codprinter.Printers.InterfaceAdapters.Presenters;

internal sealed class UpdatePrinterPresenter : IUpdatePrinterOutputPort
{
    public UpdatePrinterResponse? Content { get; private set; }

    public void Handle(UpdatePrinterResponse response)
    {
        Content = response;
    }
}
