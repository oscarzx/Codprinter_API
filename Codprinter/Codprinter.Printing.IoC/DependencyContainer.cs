using Codprinter.Printing.Application;
using Codprinter.Printing.InterefacesAdapters;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Printing.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPrintingServices(this IServiceCollection services)
        {
            services.AddPrintingUseCases()
                .AddPrintingPresenters();
            return services;
        }
    }
}
