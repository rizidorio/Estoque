using ControleEstoque.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Service
{
    public interface ICategoryService
    {
        Task<CategoryDto> Insert(CategoryDto categoryDto);
        Task<CategoryDto> Update(CategoryDto categoryDto);
        Task<bool> Remover(string code);
        Task<CategoryDto> GetByCode(string code);
        Task<IEnumerable<CategoryDto>> GetAll();
    }
}
