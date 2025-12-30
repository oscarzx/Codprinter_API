using Codprinter.Printing.Application.Dtos;

namespace Codprinter.Printing.Application.Interfaces;

public interface IPrintLabelInputPort
{
    Task Handle(PrintLabelRequest request);
}
