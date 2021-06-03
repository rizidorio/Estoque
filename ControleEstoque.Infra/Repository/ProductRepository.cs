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
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private readonly DbSet<Product> _set;

        public ProductRepository(MySqlContext context)
        {
            _context = context;
            _set = _context.Set<Product>();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetBySku(string sku)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.SKU.Equals(sku));
        }

        public async Task<Product> Insert(Product product)
        {
            await _set.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            _set.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _set.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
