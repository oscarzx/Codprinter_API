using Codprinter.Printers.Application.Dtos.GetAllPrinters;
using Codprinter.Printers.Domain;

namespace Codprinter.Printers.Application.Mappers;

public static class PrinterListMapper
{
    public static GetAllPrintersResponse ToGetAllPrintersResponse(this IReadOnlyList<PrinterSummary> printers)
    {
        var response = new GetAllPrintersResponse();

        foreach (var p in printers)
        {
            response.Items.Add(new PrinterListItem
            {
                Id = p.Id,
                PrinterIp = p.PrinterIp,
                PrinterPort = p.PrinterPort,
                PrinterName = p.PrinterName,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy
            });
        }

        return response;
    }
}
