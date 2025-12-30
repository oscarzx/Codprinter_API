using Codprinter.Printing.Application.Interfaces;
using Codprinter.Printing.InterefacesAdapters.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Printing.InterefacesAdapters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPrintingPresenters(this IServiceCollection services)
        {
            services.AddScoped<IPrintLabelOutputPort, PrintLabelPresenter>();
            return services;
        }
    }
}
