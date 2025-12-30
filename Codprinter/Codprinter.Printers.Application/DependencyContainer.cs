using Codprinter.Printers.Application.Interfaces.CreatePrinter;
using Codprinter.Printers.Application.Interfaces.GetAllPrinters;
using Codprinter.Printers.Application.Interfaces.GetPrinterByIp;
using Codprinter.Printers.Application.Interfaces.GetPrinterByName;
using Codprinter.Printers.Application.Interfaces.UpdatePrinter;
using Codprinter.Printers.Application.UsesCases;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Printers.Application;

public static class DependencyContainer
{
    public static IServiceCollection AddPrinterUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreatePrinterInputPort, CreatePrinterInteractor>();
        services.AddScoped<IGetAllPrintersInputPort, GetAllPrintersInteractor>();
        services.AddScoped<IGetPrinterByNameInputPort, GetPrinterByNameInteractor>();
        services.AddScoped<IGetPrinterByIpInputPort, GetPrinterByIpInteractor>();
        services.AddScoped<IUpdatePrinterInputPort, UpdatePrinterInteractor>();

        return services;
    }
}
