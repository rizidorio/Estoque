using System;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Dto
{
    public class StockMovementDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Prosuto é obrigatório.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Tipo de movimentação é obrigatório.")]
        public string TypeMovement { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatório.")]
        public decimal Quantity { get; set; }
        public DateTime DateMovement { get; set; }
    }
}
