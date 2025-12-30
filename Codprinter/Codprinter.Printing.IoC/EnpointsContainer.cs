using Codprinter.Printing.InterefacesAdapters.Controllers;
using Microsoft.AspNetCore.Builder;

namespace Codprinter.Printing.IoC
{
    public static class EnpointsContainer
    {
        public static WebApplication MapCodprinterPrintingEndpoints(this WebApplication app)
        {
            app.UsePrintingController();
            return app;
        }
    }
}
