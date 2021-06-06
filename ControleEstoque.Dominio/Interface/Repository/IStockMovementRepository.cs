using ControleEstoque.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Repository
{
    public interface IStockMovementRepository : IDisposable
    {
        Task<StockMovement> Insert(StockMovement stockMovement);
        Task<StockMovement> Update(StockMovement stockMovement);
        Task<StockMovement> GetById(int id);
        Task<IEnumerable<StockMovement>> GetAll();
    }
}
