using Codprinter.Printers.Application;
using Codprinter.Printers.InterfaceAdapters;
using Codprinter.Shared.Infrastructure.Options;
using CodPrinter.Printers.DataContext.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Printers.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPrinterServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<DBOptions> configureDBOptions)
        {
            services.AddPrinterUseCases()
                .AddPrinterPresenters()
                .AddPrinterDataContexts(configuration, configureDBOptions);

            return services;
        }
    }
}
