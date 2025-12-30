namespace Codprinter.Printers.Domain;

public sealed class UpdatePrinterData
{
    public string PrinterIp { get; set; } = string.Empty;
    public int? PrinterPort { get; set; }
    public string PrinterName { get; set; } = string.Empty;
}
