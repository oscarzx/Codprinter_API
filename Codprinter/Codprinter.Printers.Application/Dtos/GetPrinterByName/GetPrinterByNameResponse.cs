namespace Codprinter.Printers.Application.Dtos.GetPrinterByName;

public sealed class GetPrinterByNameResponse
{
    public List<PrinterByNameItem> Items { get; set; } = new();
}

public sealed class PrinterByNameItem
{
    public Guid Id { get; set; }
    public string PrinterIp { get; set; } = string.Empty;
    public int PrinterPort { get; set; }
    public string PrinterName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
}
