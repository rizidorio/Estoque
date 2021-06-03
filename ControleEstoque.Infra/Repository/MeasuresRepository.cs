using ControleEstoque.Domain.Entity;
using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Repository
{
    public class MeasuresRepository : IMeasuresRepository
    {
        private readonly MySqlContext _context;
        private readonly DbSet<Measures> _set;

        public MeasuresRepository(MySqlContext context)
        {
            _context = context;
            _set = context.Set<Measures>();
        }

        public async Task<IEnumerable<Measures>> GetAll()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public async Task<Measures> GetByCode(string code)
        {
            return await _context.Measures.FirstOrDefaultAsync(x => x.Code.Equals(code));
        }

        public async Task<Measures> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<Measures> Insert(Measures measures)
        {
            await _set.AddAsync(measures);
            await _context.SaveChangesAsync();
            return measures;
        }

        public async Task<Measures> Remove(Measures measures)
        {
            _set.Remove(measures);
            await _context.SaveChangesAsync();
            return measures;
        }

        public async Task<Measures> Update(Measures measures)
        {
            _set.Update(measures);
            await _context.SaveChangesAsync();
            return measures;
        }
    }
}
