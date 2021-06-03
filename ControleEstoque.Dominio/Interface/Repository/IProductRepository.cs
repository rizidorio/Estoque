using ControleEstoque.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Repository
{
    public interface IProductRepository
    {
        Task<Product> Insert(Product product);
        Task<Product> Update(Product product);
        Task<Product> Remove(Product product);
        Task<Product> GetBySku(string sku);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
    }
}
