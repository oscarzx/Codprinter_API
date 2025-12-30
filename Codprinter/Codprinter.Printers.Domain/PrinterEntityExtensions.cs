namespace Codprinter.Printers.Domain;

public static class PrinterEntityExtensions
{
    public static PrinterEntity Update(this PrinterEntity current, UpdatePrinterData data)
    {
        if (data is null) throw new ArgumentNullException(nameof(data));

        var ip = string.IsNullOrWhiteSpace(data.PrinterIp) ? current.PrinterIp : data.PrinterIp.Trim();
        var name = string.IsNullOrWhiteSpace(data.PrinterName) ? current.PrinterName : data.PrinterName.Trim();
        var port = data.PrinterPort ?? current.PrinterPort;

        return new PrinterEntity(ip, port, name, current.UserId);
    }
}
