using System;

namespace ControleEstoque.Domain.Entity
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int StokId { get; set; }
        public virtual Stock Stock { get; set; }
        public string TypeStokMov { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DateMovement { get; set; }

        public StockMovement(int id, int stokId, string typeStokMov, decimal quantity, DateTime dateMovement)
        {
            Id = id;
            StokId = stokId;
            TypeStokMov = typeStokMov;
            Quantity = quantity;
            DateMovement = dateMovement;
        }
    }
}
