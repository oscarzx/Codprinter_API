using Codprinter.Labels.Application.Dtos.CreateLabel;
using Codprinter.Labels.Application.Dtos.DeleteLabel;
using Codprinter.Labels.Application.Dtos.GetAllLabels;
using Codprinter.Labels.Application.Dtos.GetLabel;
using Codprinter.Labels.Application.Dtos.UpdateLabel;
using Codprinter.Labels.Application.Interfaces.CreateLabel;
using Codprinter.Labels.Application.Interfaces.DeleteLabel;
using Codprinter.Labels.Application.Interfaces.GetAllLabels;
using Codprinter.Labels.Application.Interfaces.GetLabel;
using Codprinter.Labels.Application.Interfaces.UpdateLabel;
using Codprinter.Labels.Domain.ValueObjects;
using Codprinter.Labels.InterfaceAdapters.Presenters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codprinter.Labels.InterfaceAdapters.Controllers;

public static class LabelsController
{
    public static WebApplication UseLabelController(this WebApplication app)
    {
        // Existing endpoints
        app.MapPost(Endpoints.CreateLabel, CreateLabel).WithTags("Labels");
        app.MapGet(Endpoints.GetLabelByName, GetLabelByName).WithTags("Labels");

        // New list endpoint (uses GetLabelTemplates constant)
        app.MapGet(Endpoints.GetLabelTemplates, GetAllLabels).WithTags("Labels");

        // Update endpoint uses POST as requested
        app.MapPost(Endpoints.UpdateLabelTemplate, UpdateLabel).WithTags("Labels");

        // Delete endpoint (borrado lógico por nombre de plantilla)
        app.MapDelete(Endpoints.DeleteLabelTemplate, DeleteLabel).WithTags("Labels");

        return app;
    }

    public static async Task<CreateLabelResponse> CreateLabel(
        [FromBody] CreateLabelRequest request,
        ICreateLabelInputPort inputPort,
        ICreateLabelOutputPort outputPort)
    {
        await inputPort.Handle(request);
        return outputPort.Content;
    }

    private static async Task<IResult> GetLabelByName(
        [FromQuery] string templateName,
        IGetLabelInputPort inputPort,
        IGetLabelOutputPort outputPort)
    {
        var request = new GetLabelRequest { TemplateName = templateName };
        await inputPort.Handle(request);

        var presenter = (GetLabelPresenter)outputPort;
        if (presenter.Content is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(presenter.Content);
    }

    private static async Task<IResult> GetAllLabels(
        [FromQuery] bool onlyActive,
        IGetAllLabelsInputPort inputPort,
        IGetAllLabelsOutputPort outputPort)
    {
        var request = new GetAllLabelsRequest { OnlyActive = onlyActive };
        await inputPort.Handle(request);

        var presenter = (GetAllLabelsPresenter)outputPort;
        if (presenter.Content is null)
        {
            return Results.Ok(new GetAllLabelsResponse());
        }

        return Results.Ok(presenter.Content);
    }

    private static async Task<IResult> UpdateLabel(
        [FromBody] UpdateLabelRequest request,
        IUpdateLabelInputPort inputPort,
        IUpdateLabelOutputPort outputPort)
    {
        await inputPort.Handle(request);
        var presenter = (UpdateLabelPresenter)outputPort;
        return Results.Ok(presenter.Content ?? new UpdateLabelResponse());
    }

    private static async Task<IResult> DeleteLabel(
        [AsParameters] DeleteLabelRequest request,
        IDeleteLabelInputPort inputPort,
        IDeleteLabelOutputPort outputPort)
    {
        //var request = new DeleteLabelRequest { TemplateName = templateName };
        await inputPort.Handle(request);

        var presenter = (DeleteLabelPresenter)outputPort;
        return Results.Ok(presenter.Content);
    }
}
