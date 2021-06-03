using ControleEstoque.Domain.Entity;
using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MySqlContext _context;
        private readonly DbSet<Category> _set;

        public CategoryRepository(MySqlContext context)
        {
            _context = context;
            _set = _context.Set<Category>();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByCode(string code)
        {
            return await _context.Category.FirstOrDefaultAsync(x => x.Code.Equals(code));
        }

        public async Task<Category> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<Category> Insert(Category category)
        {
            await _set.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Remove(Category category)
        {
            _set.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _set.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
