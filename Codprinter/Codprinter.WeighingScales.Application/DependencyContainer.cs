using Codprinter.WeighingScales.Application.Interfaces.CreateWeighingScale;
using Codprinter.WeighingScales.Application.Interfaces.GetAllWeighingScales;
using Codprinter.WeighingScales.Application.Interfaces.UpdateWeighingScale;
using Codprinter.WeighingScales.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.WeighingScales.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddWeighingScaleUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateWeighingScaleInputPort, CreateWeighingScaleInteractor>();
            services.AddScoped<IGetAllWeighingScalesInputPort, GetAllWeighingScalesInteractor>();
            services.AddScoped<IUpdateWeighingScaleInputPort, UpdateWeighingScaleInteractor>();
            return services;
        }
    }
}
