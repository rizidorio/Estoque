using ControleEstoque.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Repository
{
    public interface IStockMovementRepository
    {
        Task<StockMovement> Insert(StockMovement stockMovement);
        Task<StockMovement> Update(StockMovement stockMovement);
        Task<StockMovement> GetById(int id);
        Task<IEnumerable<StockMovement>> GetAll();
    }
}
