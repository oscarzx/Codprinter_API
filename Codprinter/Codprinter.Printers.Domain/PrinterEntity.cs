namespace Codprinter.Printers.Domain
{
    public class PrinterEntity(
        string printerIp, int printerPort, string printerName, Guid userId)
    {
        public string PrinterIp => printerIp;
        public int PrinterPort => printerPort = 9100;
        public string PrinterName => printerName;
        public Guid UserId => userId;
    }
}
