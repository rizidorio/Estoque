using ControleEstoque.Domain.Entity;
using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly MySqlContext _context;
        private readonly DbSet<Stock> _set;

        public StockRepository(MySqlContext context)
        {
            _context = context;
            _set = _context.Set<Stock>();
        }

        public async Task<IEnumerable<Stock>> GetAll()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public async Task<Stock> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<Stock> Insert(Stock stock)
        {
            await _set.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock> Update(Stock stock)
        {
            _set.Update(stock);
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
