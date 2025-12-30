using Codprinter.Shared.Infrastructure.Options;
using Codprinter.WeighingScales.Application;
using Codprinter.WeighingScales.DataCOntexts.EFCore;
using Codprinter.WeighingScales.InterfacesAdapters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.WeighingScales.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddWeighingScaleServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<DBOptions> configureDBOptions)
        {
            services.AddWeighingScaleUseCases()
                .AddWeighingScalePresenters()
                .AddWeighingScalesDataContexts(configuration, configureDBOptions);
            return services;
        }
    }
}
