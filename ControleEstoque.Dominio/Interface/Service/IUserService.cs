using ControleEstoque.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<UserDto> Insert(UserDto userDto);
        Task<UserDto> Update(UserDto userDto);
        Task<bool> Remover(string code);
        Task<UserDto> GetByCode(string code);
        Task<IEnumerable<UserDto>> GetAll();
    }
}
