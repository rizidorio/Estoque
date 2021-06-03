using ControleEstoque.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Service
{
    public interface IStockService
    {
        Task<StockDto> Insert(StockDto stockDto);
        Task<StockDto> Update(StockDto stockDto);
        Task<StockDto> GetById(int id);
        Task<StockDto> GetByProductId(int productId);
        Task<IEnumerable<StockDto>> GetAll();
    }
}
