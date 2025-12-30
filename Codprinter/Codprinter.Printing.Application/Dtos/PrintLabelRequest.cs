namespace Codprinter.Printing.Application.Dtos;

public sealed class PrintLabelRequest
{
    public required string ZplCommand { get; init; }
    public required string PrinterIp { get; init; }
    public required int PrinterPort { get; init; }
}
