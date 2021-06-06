using System;

namespace ControleEstoque.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Cust { get; set; }
        public DateTime ChangeDate { get; set; }
        public bool Inactive { get; set; }

        public Product(int id, string sKU, string name, string description, string category, decimal cust, DateTime changeDate, bool inactive = false)
        {
            Id = id;
            SKU = sKU;
            Name = name;
            Description = description;
            Category = category;
            Cust = cust;
            ChangeDate = changeDate;
            Inactive = inactive;
        }
    }
}
