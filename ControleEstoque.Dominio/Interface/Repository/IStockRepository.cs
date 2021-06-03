using ControleEstoque.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Repository
{
    public interface IStockRepository
    {
        Task<Stock> Insert(Stock stock);
        Task<Stock> Update(Stock stock);
        Task<Stock> GetById(int id);
        Task<IEnumerable<Stock>> GetAll();
    }
}
