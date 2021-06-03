namespace ControleEstoque.Domain.Entity
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }

        public Stock(int id, int productId, decimal quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
