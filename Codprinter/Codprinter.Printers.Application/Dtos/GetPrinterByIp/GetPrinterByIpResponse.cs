namespace Codprinter.Printers.Application.Dtos.GetPrinterByIp;

public sealed class GetPrinterByIpResponse
{
    public Guid Id { get; set; }
    public string PrinterIp { get; set; } = string.Empty;
    public int PrinterPort { get; set; }
    public string PrinterName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
}
