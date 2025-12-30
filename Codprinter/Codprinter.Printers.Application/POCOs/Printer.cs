namespace Codprinter.Printers.Application.POCOs;

public class Printer
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public string PrinterIp { get; set; }
    public int PrinterPort { get; set; }
    public string PrinterName { get; set; }
    public DateTime CreatedAt { get; set; }
}
