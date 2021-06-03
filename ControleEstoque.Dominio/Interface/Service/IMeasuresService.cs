using ControleEstoque.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Service
{
    public interface IMeasuresService
    {
        Task<MeasuresDto> Insert(MeasuresDto measuresDto);
        Task<MeasuresDto> Update(MeasuresDto measuresDto);
        Task<bool> Remover(string code);
        Task<MeasuresDto> GetByCode(string code);
        Task<IEnumerable<MeasuresDto>> GetAll();
    }
}
