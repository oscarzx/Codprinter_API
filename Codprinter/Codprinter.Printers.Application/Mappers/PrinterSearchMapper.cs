using Codprinter.Printers.Application.Dtos.GetPrinterByName;
using Codprinter.Printers.Domain;

namespace Codprinter.Printers.Application.Mappers;

public static class PrinterSearchMapper
{
    public static GetPrinterByNameResponse ToGetPrinterByNameResponse(this IReadOnlyList<PrinterSummary> printers)
    {
        var response = new GetPrinterByNameResponse();

        foreach (var p in printers)
        {
            response.Items.Add(new PrinterByNameItem
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
