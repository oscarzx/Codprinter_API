using Codprinter.Printing.Application.Dtos;

namespace Codprinter.Printing.Application.Interfaces;

public interface IPrintLabelOutputPort
{
    PrintLabelResponse? Content { get; }
    Task Handle(PrintLabelResponse response);
}
