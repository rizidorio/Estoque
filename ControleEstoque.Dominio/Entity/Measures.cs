using System.Collections.Generic;

namespace ControleEstoque.Domain.Entity
{
    public class Measures
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public bool Inactive { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public Measures(int id, string code, string name, string initials, bool inactive = false)
        {
            Id = id;
            Code = code;
            Name = name;
            Initials = initials;
            Inactive = inactive;
        }
    }
}