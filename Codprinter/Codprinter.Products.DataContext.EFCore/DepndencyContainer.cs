using Codprinter.Products.DataContext.EFCore.Services;
using Codprinter.Products.InterfacesAdapters.Gateways.Interfaces;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Products.DataContext.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProductDataContexts(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<DBOptions> configureDBOptions)
        {
            // Register your data contexts here
            // services.AddTransient<IYourDataContext, YourDataContextImplementation>();
            services.Configure(configureDBOptions);
            services.AddScoped<ICodprinterProductsCommandsDataContext, CodprinterProductsCommandsDataContext>();

            return services;
        }
    }
}
