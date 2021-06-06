using ControleEstoque.Domain.Entity;
using ControleEstoque.Domain.Interface.Repository;
using ControleEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Repository
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly MySqlContext _context;
        private readonly DbSet<StockMovement> _set;

        public StockMovementRepository(MySqlContext context)
        {
            _context = context;
            _set = context.Set<StockMovement>();
        }

        public void Dispose()
        {
        }

        public async Task<IEnumerable<StockMovement>> GetAll()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public async Task<StockMovement> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<StockMovement> Insert(StockMovement stockMovement)
        {
            await _set.AddAsync(stockMovement);
            await _context.SaveChangesAsync();
            return stockMovement;
        }

        public async Task<StockMovement> Update(StockMovement stockMovement)
        {
            _set.Update(stockMovement);
            await _context.SaveChangesAsync();
            return stockMovement;
        }
    }
}
