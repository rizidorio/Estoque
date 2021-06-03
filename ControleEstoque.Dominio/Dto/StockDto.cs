using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Dto
{
    public class StockDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Produto é obrigatório.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatório.")]
        public decimal Quantity { get; set; }
    }
}
