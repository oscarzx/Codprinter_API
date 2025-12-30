using Codprinter.WeighingScales.Application.Interfaces.CreateWeighingScale;
using Codprinter.WeighingScales.Application.Interfaces.GetAllWeighingScales;
using Codprinter.WeighingScales.Application.Interfaces.Repositories;
using Codprinter.WeighingScales.Application.Interfaces.UpdateWeighingScale;
using Codprinter.WeighingScales.InterfacesAdapters.Gateways.Repositories;
using Codprinter.WeighingScales.InterfacesAdapters.Presenters;
using Codprinter.WeighingScales.InterfacesAdapters.Presenters.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.WeighingScales.InterfacesAdapters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddWeighingScalePresenters(this IServiceCollection services)
        {
            services.AddScoped<IWeighingScaleRepository, WeighingScalesRepository>();

            services.AddScoped<ICreateWeighingScaleOutputPort, CreateWeighingScalesPresenter>();
            services.AddScoped<IGetAllWeighingScalesOutputPort, GetAllWeighingScalesPresenter>();
            services.AddScoped<IUpdateWeighingScaleOutputPort, UpdateWeighingScalePresenter>();

            return services;
        }
    }
}
