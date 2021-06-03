using ControleEstoque.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Service
{
    public interface IProductService
    {
        Task<ProductDto> Insert(ProductDto productDto);
        Task<ProductDto> Update(ProductDto productDto);
        Task<bool> Remover(string sku);
        Task<ProductDto> GetBySku(string sku);
        Task<IEnumerable<ProductDto>> GetAll();
    }
}
