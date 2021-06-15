using System;

namespace ControleEstoque.Domain.Entity
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string TypeMovement { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DateMovement { get; set; }

        public StockMovement()
        {

        }

        public StockMovement(int id, int productId, string typeMovement, decimal quantity, DateTime dateMovement)
        {
            Id = id;
            ProductId = productId;
            TypeMovement = typeMovement;
            Quantity = quantity;
            DateMovement = dateMovement;
        }
    }
}
