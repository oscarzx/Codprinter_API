namespace Codprinter.Printing.Domain.Entities;

public sealed class PrintLabelEntity
{
    public string ZplCommand { get; }
    public string PrinterIp { get; }
    public int PrinterPort { get; }

    public PrintLabelEntity(string zplCommand, string printerIp, int printerPort)
    {
        ZplCommand = zplCommand;
        PrinterIp = printerIp;
        PrinterPort = printerPort;
    }
}
