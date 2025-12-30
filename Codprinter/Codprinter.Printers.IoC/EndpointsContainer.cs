using Codprinter.Printers.InterfaceAdapters.Controllers;
using Microsoft.AspNetCore.Builder;

namespace Codprinter.Printers.IoC
{
    public static class EndpointsContainer
    {
        public static WebApplication MapCodprinterPrintersEndpoints(this WebApplication app)
        {
            app.UsePrinterController();
            return app;
        }
    }
}
