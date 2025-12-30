using Codprinter.Printing.Application.Dtos;
using Codprinter.Printing.Application.Interfaces;
using Codprinter.Printing.Domain.ValueObjects;
using Codprinter.Printing.InterefacesAdapters.Presenters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codprinter.Printing.InterefacesAdapters.Controllers;

public static class PrintingController
{
    public static WebApplication UsePrintingController(this WebApplication app)
    {
        app.MapPost(Endpoints.PrintLabel, PrintLabel).WithTags("Printing");
        return app;
    }

    private static async Task<IResult> PrintLabel(
    [FromBody] PrintLabelRequest request,
    IPrintLabelInputPort inputPort,
    IPrintLabelOutputPort outputPort)
    {
        await inputPort.Handle(request);

        var presenter = (PrintLabelPresenter)outputPort;
        if (presenter.Content is null)
        {
            return Results.Ok(new PrintLabelResponse { Message = "Print job sent." });
        }

        return Results.Ok(presenter.Content);
    }
}
