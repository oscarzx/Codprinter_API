namespace Codprinter.Printers.Application.Dtos.UpdatePrinter;

public sealed class UpdatePrinterRequest
{
    public Guid Id { get; set; }
    public string PrinterIp { get; set; } = string.Empty;
    public int PrinterPort { get; set; }
    public string PrinterName { get; set; } = string.Empty;
}
