using ControleEstoque.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Repository
{
    public interface IMeasuresRepository
    {
        Task<Measures> Insert(Measures measures);
        Task<Measures> Update(Measures measures);
        Task<Measures> Remove(Measures measures);
        Task<Measures> GetByCode(string code);
        Task<Measures> GetById(int id);
        Task<IEnumerable<Measures>> GetAll();
    }
}
