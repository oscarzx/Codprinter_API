using Codprinter.Printers.Application.Dtos.CreatePrinter;
using Codprinter.Printers.Application.Dtos.GetAllPrinters;
using Codprinter.Printers.Application.Dtos.GetPrinterByIp;
using Codprinter.Printers.Application.Dtos.GetPrinterByName;
using Codprinter.Printers.Application.Dtos.UpdatePrinter;
using Codprinter.Printers.Application.Interfaces.CreatePrinter;
using Codprinter.Printers.Application.Interfaces.GetAllPrinters;
using Codprinter.Printers.Application.Interfaces.GetPrinterByIp;
using Codprinter.Printers.Application.Interfaces.GetPrinterByName;
using Codprinter.Printers.Application.Interfaces.UpdatePrinter;
using Codprinter.Printers.Domain.ValueObjects;
using Codprinter.Printers.InterfaceAdapters.Presenters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codprinter.Printers.InterfaceAdapters.Controllers;

public static class PrinterController
{
    public static WebApplication UsePrinterController(this WebApplication app)
    {
        app.MapPost(Endpoints.CreatePrinter, CreatePrinter).WithTags("Printer");
        app.MapGet(Endpoints.GetAllPrinters, GetAllPrinters).WithTags("Printer");
        app.MapGet(Endpoints.GetPrinterByName, GetPrinterByName).WithTags("Printer");
        app.MapGet(Endpoints.GetPrinterByIp, GetPrinterByIp).WithTags("Printer");
        app.MapPost(Endpoints.UpdatePrinter, UpdatePrinter).WithTags("Printer");
        return app;
    }

    public static async Task<CreatePrinterResponse> CreatePrinter(
        [FromBody] CreatePrinterRequest request,
        ICreatePrinterInputPort inputPort,
        ICreatePrinterOutputPort outputPort)
    {
        await inputPort.Handle(request);
        return outputPort.Content;
    }

    private static async Task<IResult> GetAllPrinters(
        IGetAllPrintersInputPort inputPort,
        IGetAllPrintersOutputPort outputPort)
    {
        await inputPort.Handle(new GetAllPrintersRequest());

        var presenter = (GetAllPrintersPresenter)outputPort;
        return Results.Ok(presenter.Content ?? new GetAllPrintersResponse());
    }

    private static async Task<IResult> GetPrinterByName(
        [FromQuery] string searchText,
        IGetPrinterByNameInputPort inputPort,
        IGetPrinterByNameOutputPort outputPort)
    {
        await inputPort.Handle(new GetPrinterByNameRequest { SearchText = searchText });

        var presenter = (GetPrinterByNamePresenter)outputPort;
        return Results.Ok(presenter.Content ?? new GetPrinterByNameResponse());
    }

    private static async Task<IResult> GetPrinterByIp(
        [FromQuery] string printerIp,
        IGetPrinterByIpInputPort inputPort,
        IGetPrinterByIpOutputPort outputPort)
    {
        await inputPort.Handle(new GetPrinterByIpRequest { PrinterIp = printerIp });

        var presenter = (GetPrinterByIpPresenter)outputPort;
        if (presenter.Content is null)
            return Results.NotFound();

        return Results.Ok(presenter.Content);
    }

    private static async Task<IResult> UpdatePrinter(
        [FromBody] UpdatePrinterRequest request,
        IUpdatePrinterInputPort inputPort,
        IUpdatePrinterOutputPort outputPort)
    {
        await inputPort.Handle(request);

        var presenter = (UpdatePrinterPresenter)outputPort;
        return Results.Ok(presenter.Content ?? new UpdatePrinterResponse());
    }
}
