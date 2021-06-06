using ControleEstoque.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Service
{
    public interface IStockMovementService
    {
        Task<StockMovementDto> Insert(StockMovementDto stockMovementDto);
        Task<StockMovementDto> Update(StockMovementDto stockMovementDto);
        Task<StockMovementDto> GetById(int id);
        Task<IEnumerable<StockMovementDto>> ListByProductId(int productId);
        Task<IEnumerable<StockMovementDto>> GetAll();
    }
}
