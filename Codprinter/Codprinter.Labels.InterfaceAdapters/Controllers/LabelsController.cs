using Codprinter.Labels.Application.Dtos.CreateLabel;
using Codprinter.Labels.Application.Interfaces.CreateLabel;
using Codprinter.Labels.Domain.ValueObjects;
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
}
