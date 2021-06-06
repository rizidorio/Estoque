using ControleEstoque.Domain.Entity;
using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;
        private readonly DbSet<User> _set;

        public UserRepository(MySqlContext context)
        {
            _context = context;
            _set = _context.Set<User>();
        }

        public void Dispose()
        {
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByCode(string code)
        {
            return await _set.FirstOrDefaultAsync(x => x.Code.Equals(code));
        }

        public async Task<User> GetById(int Id)
        {
            return await _set.FindAsync(Id);
        }

        public async Task<User> Insert(User user)
        {
            await _set.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Remove(User user)
        {
            _set.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _set.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
