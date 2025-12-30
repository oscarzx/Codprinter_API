using Codprinter.Printers.InterfaceAdapters.Gateways.Interfaces;
using Codprinter.Shared.Infrastructure.Options;
using CodPrinter.Printers.DataContext.EFCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodPrinter.Printers.DataContext.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPrinterDataContexts(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<DBOptions> configureDBOptions)
        {
            services.Configure(configureDBOptions);
            services.AddScoped<ICodprinterPrintersCommandsDataContext, CodprinterPrintersCommandsDataContext>();

            return services;
        }
    }
}
