using Codprinter.Labels.Application.Dtos.CreateLabel;
using Codprinter.Labels.Application.Dtos.GetLabel;
using Codprinter.Labels.Application.Interfaces.CreateLabel;
using Codprinter.Labels.Application.Interfaces.GetLabel;
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
        //app.MapGet("/labels/{labelId}", () => "Label details");
        app.MapPost(Endpoints.CreateLabel, CreateLabel).WithTags("Labels");
        app.MapGet(Endpoints.GetLabelByName, GetLabelByName).WithTags("Labels");

        return app;
    }

    public static  async Task<CreateLabelResponse> CreateLabel(
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
}
