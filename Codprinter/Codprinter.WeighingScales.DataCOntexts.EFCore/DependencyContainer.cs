using Codprinter.Shared.Infrastructure.Options;
using Codprinter.WeighingScales.DataCOntexts.EFCore.Services;
using Codprinter.WeighingScales.InterfacesAdapters.Gateways.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.WeighingScales.DataCOntexts.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddWeighingScalesDataContexts(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<DBOptions> configureDBOptions)
        {
            services.Configure(configureDBOptions);
            services.AddScoped<ICodprinterWeighingScaleCommandsDataContext, CodprinterWeighingScalesCommandsDataContext>();

            return services;
        }
    }
}
