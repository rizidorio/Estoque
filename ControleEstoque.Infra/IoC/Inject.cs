using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Domain.Interface.Service;
using ControleEstoque.Infra.Context;
using ControleEstoque.Infra.Repository;
using ControleEstoque.Infra.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ControleEstoque.Infra.IoC
{
    public static class Inject
    {
        public static void InjectService(this IServiceCollection services)
        {
            services.AddDbContext<MySqlContext>();

            #region Repositorios
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Servicos
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockMovementService, StockMovementService>();
            services.AddScoped<IUserService, UserService>();
            #endregion
        }
    }
}
