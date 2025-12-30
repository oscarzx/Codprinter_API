using Codprinter.WeighingScales.InterfacesAdapters.Controllers;
using Microsoft.AspNetCore.Builder;

namespace Codprinter.WeighingScales.IoC
{
    public static class EndpointsContainer
    {
        public static WebApplication MapCodprinterWeighingScalesEndpoints(this WebApplication app)
        {
            app.UseWeighingScalesController();
            return app;
        }
    }
}
