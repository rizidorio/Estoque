using ControleEstoque.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> Insert(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);
        Task<Category> GetByCode(string code);
        Task<Category> GetById(int id);
        Task<IEnumerable<Category>> GetAll();
    }
}
