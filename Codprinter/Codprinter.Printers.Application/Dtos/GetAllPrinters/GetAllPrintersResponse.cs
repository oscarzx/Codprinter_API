namespace Codprinter.Printers.Application.Dtos.GetAllPrinters;

public sealed class GetAllPrintersResponse
{
    public List<PrinterListItem> Items { get; set; } = new();
}

public sealed class PrinterListItem
{
    public Guid Id { get; set; }
    public string PrinterIp { get; set; } = string.Empty;
    public int PrinterPort { get; set; }
    public string PrinterName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
}
