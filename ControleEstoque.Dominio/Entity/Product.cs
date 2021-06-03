using System;

namespace ControleEstoque.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Caterory { get; set; }
        public int MeasureId { get; set; }
        public virtual Measures Measure { get; set; }
        public decimal Cust { get; set; }
        public DateTime ChangeDate { get; set; }
        public int UserChangeId { get; set; }
        public virtual User UserChange { get; set; }
        public bool Inactive { get; set; }

        public Product(int id, string sKU, string name, string description, int categoryId, int measureId, decimal cust, DateTime changeDate, int userChangeId, bool inactive = false)
        {
            Id = id;
            SKU = sKU;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            MeasureId = measureId;
            Cust = cust;
            ChangeDate = changeDate;
            UserChangeId = userChangeId;
            Inactive = inactive;
        }

        public string GetSkuName => $"{SKU} - {Name}";
    }
}
