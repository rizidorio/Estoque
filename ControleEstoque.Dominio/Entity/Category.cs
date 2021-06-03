using System.Collections.Generic;
using System.Linq;

namespace ControleEstoque.Domain.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Inactive { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public Category(int id, string code, string name, bool inactive = false)
        {
            Id = id;
            Code = code;
            Name = name;
            Inactive = inactive;
        }

        public List<Product> GetProductsOnlyActive()
        {
            return Products.Where(i => !i.Inactive).ToList();
        }
    }
}