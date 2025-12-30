using Codprinter.Printing.Application.Dtos;
using Codprinter.Printing.Application.Interfaces;

namespace Codprinter.Printing.InterefacesAdapters.Presenters;

internal sealed class PrintLabelPresenter : IPrintLabelOutputPort
{
    public PrintLabelResponse? Content { get; private set; }

    public Task Handle(PrintLabelResponse response)
    {
        Content = response;
        return Task.CompletedTask;
    }
}
