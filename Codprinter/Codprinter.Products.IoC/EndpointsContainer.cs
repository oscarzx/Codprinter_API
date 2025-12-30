using Codprinter.Products.InterfacesAdapters.Controllers;
using Microsoft.AspNetCore.Builder;

namespace Codprinter.Products.IoC;

public static class EndpointsContainer
{
    public static WebApplication MapCodprinterProductsEndpoints(this WebApplication app)
    {
        app.UseProductsController();
        return app;
    }
}
