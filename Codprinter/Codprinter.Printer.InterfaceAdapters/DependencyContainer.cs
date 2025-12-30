using Codprinter.Printers.Application.Interfaces.CreatePrinter;
using Codprinter.Printers.Application.Interfaces.GetAllPrinters;
using Codprinter.Printers.Application.Interfaces.GetPrinterByIp;
using Codprinter.Printers.Application.Interfaces.GetPrinterByName;
using Codprinter.Printers.Application.Interfaces.Repositories;
using Codprinter.Printers.Application.Interfaces.UpdatePrinter;
using Codprinter.Printers.InterfaceAdapters.Gateways.Repositories;
using Codprinter.Printers.InterfaceAdapters.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Printers.InterfaceAdapters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPrinterPresenters(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IPrinterRepository, PrinterRepository>();

            // Presenters
            services.AddScoped<ICreatePrinterOutputPort, CreatePrinterPresenter>();
            services.AddScoped<IGetAllPrintersOutputPort, GetAllPrintersPresenter>();
            services.AddScoped<IGetPrinterByNameOutputPort, GetPrinterByNamePresenter>();
            services.AddScoped<IGetPrinterByIpOutputPort, GetPrinterByIpPresenter>();
            services.AddScoped<IUpdatePrinterOutputPort, UpdatePrinterPresenter>();

            return services;
        }
    }
}
