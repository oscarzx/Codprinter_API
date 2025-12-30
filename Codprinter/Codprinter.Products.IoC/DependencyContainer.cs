using Codprinter.Products.Application;
using Codprinter.Products.DataContext.EFCore;
using Codprinter.Products.InterfacesAdapters;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Products.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProductServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<DBOptions> configureDBOptions)
        {
            services.AddProductUseCases()
                .AddProductPresenters()
                .AddProductDataContexts(configuration, configureDBOptions);
            return services;
        }
    }
}
