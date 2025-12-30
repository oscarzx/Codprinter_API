using Codprinter.Products.Application.Interfaces.CreateProduct;
using Codprinter.Products.Application.Interfaces.GetAllProducts;
using Codprinter.Products.Application.Interfaces.GetProduct;
using Codprinter.Products.Application.Interfaces.GetProductByName;
using Codprinter.Products.Application.Interfaces.UpdateProduct;
using Codprinter.Products.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Products.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProductUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductInputPort, CreateProductInteractor>();
            services.AddScoped<IGetProductInputPort, GetProductInteractor>();
            services.AddScoped<IGetAllProductsInputPort, GetAllProductsInteractor>();
            services.AddScoped<IUpdateProductInputPort, UpdateProductInteractor>();
            services.AddScoped<IGetProductByNameInputPort, GetProductByNameInteractor>();
            return services;
        }
    }
}
