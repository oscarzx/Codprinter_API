using Codprinter.Labels.InterfaceAdapters.Controllers;
using Microsoft.AspNetCore.Builder;

namespace Codprinter.Labels.IoC;

public static class EndpointsContainer
{
    public static WebApplication MapCodprinterLabelsEndpoints(this WebApplication app)
    {
        app.UseLabelController();
        return app;
    }
}
