using Codprinter.Products.Application.Interfaces.CreateProduct;
using Codprinter.Products.Application.Interfaces.GetAllProducts;
using Codprinter.Products.Application.Interfaces.GetProduct;
using Codprinter.Products.Application.Interfaces.GetProductByName;
using Codprinter.Products.Application.Interfaces.Repositories;
using Codprinter.Products.Application.Interfaces.UpdateProduct;
using Codprinter.Products.InterfacesAdapters.Gateways.Repositories;
using Codprinter.Products.InterfacesAdapters.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Products.InterfacesAdapters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProductPresenters(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICreateProductOutputPort, CreateProductPresenter>();
            services.AddScoped<IGetProductOutputPort, GetProductPresenter>();
            services.AddScoped<IGetAllProductsOutputPort, GetAllProductsPresenter>();
            services.AddScoped<IUpdateProductOutputPort, UpdateProductPresenter>();
            services.AddScoped<IGetProductByNameOutputPort, GetProductByNamePresenter>();

            return services;
        }
    }
}
