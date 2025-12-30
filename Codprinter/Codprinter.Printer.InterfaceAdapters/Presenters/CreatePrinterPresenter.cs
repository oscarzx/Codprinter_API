using Codprinter.Printers.Application.Dtos.CreatePrinter;
using Codprinter.Printers.Application.Interfaces.CreatePrinter;

namespace Codprinter.Printers.InterfaceAdapters.Presenters;

internal class CreatePrinterPresenter : ICreatePrinterOutputPort
{
    public CreatePrinterResponse Content { get; private set; } = default!;

    public Task Handle(CreatePrinterResponse response)
    {
        Content = response;
        return Task.CompletedTask;
    }
}
