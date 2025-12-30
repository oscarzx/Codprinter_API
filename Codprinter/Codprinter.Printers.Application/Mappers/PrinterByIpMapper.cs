using Codprinter.Printers.Application.Dtos.GetPrinterByIp;
using Codprinter.Printers.Domain;

namespace Codprinter.Printers.Application.Mappers;

public static class PrinterByIpMapper
{
    public static GetPrinterByIpResponse ToGetPrinterByIpResponse(this PrinterSummary printer)
    {
        return new GetPrinterByIpResponse
        {
            Id = printer.Id,
            PrinterIp = printer.PrinterIp,
            PrinterPort = printer.PrinterPort,
            PrinterName = printer.PrinterName,
            CreatedAt = printer.CreatedAt,
            CreatedBy = printer.CreatedBy
        };
    }
}
