using System;

namespace ControleEstoque.Domain.Entity
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int StokId { get; set; }
        public virtual Stock Stock { get; set; }
        public int TypeStokMov { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DateMovement { get; set; }
        public int UserMovementId { get; set; }
        public virtual User UserMovement { get; set; }

        public StockMovement(int id, int stokId, int typeStokMov, decimal quantity, DateTime dateMovement, int userMovementId)
        {
            Id = id;
            StokId = stokId;
            TypeStokMov = typeStokMov;
            Quantity = quantity;
            DateMovement = dateMovement;
            UserMovementId = userMovementId;
        }
    }
}
