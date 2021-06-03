using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Domain.Interface.Service;
using ControleEstoque.Infra.Repository;
using ControleEstoque.Infra.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ControleEstoque.Infra.IoC
{
    public static class Inject
    {
        public static void InjectService(this IServiceCollection services)
        {
            #region Repositorios
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMeasuresRepository, MeasuresRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Servicos
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMeasuresService, MeasuresService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IStockMovementService, StockMovementService>();
            services.AddScoped<IUserService, UserService>();
            #endregion
        }
    }
}
