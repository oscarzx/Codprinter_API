using Codprinter.Printers.Application.POCOs;
using Codprinter.Printers.Domain;

namespace Codprinter.Printers.Application.Mappers;

public static class PrinterMapper
{
    public static Printer ToNewPrinter(this PrinterEntity entity)
        => new Printer
        {
            Id = Guid.NewGuid(),
            CreatedBy = entity.UserId,
            PrinterIp = entity.PrinterIp,
            PrinterPort = entity.PrinterPort,
            PrinterName = entity.PrinterName,
            CreatedAt = DateTime.UtcNow
        };


}
