namespace Codprinter.Printers.Application.Dtos.CreatePrinter;

public class CreatePrinterRequest
{
    public string PrinterIp { get; set; }
    public int PrinterPort { get; set; }
    public string PrinterName { get; set; }
}
