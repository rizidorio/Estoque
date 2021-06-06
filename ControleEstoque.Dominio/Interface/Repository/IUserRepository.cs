using ControleEstoque.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Interface.Repository
{
    public interface IUserRepository : IDisposable
    {
        Task<User> Insert(User user);
        Task<User> Update(User user);
        Task<User> Remove(User user);
        Task<User> GetByCode(string code);
        Task<User> GetById(int Id);
        Task<IEnumerable<User>> GetAll();
    }
}
