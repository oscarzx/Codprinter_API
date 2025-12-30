using Codprinter.Printing.Application.Interfaces;
using Codprinter.Printing.Application.UseCases;
using Codprinter.Printing.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Printing.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPrintingUseCases(this IServiceCollection services)
        {
            services.AddScoped<PrintLabelDomainService>();
            services.AddScoped<IPrintLabelInputPort, PrintLabelInteractor>();
            return services;
        }
    }
}
