using System;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Dto
{
    public class StockMovementDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Estoque é obrigatório.")]
        public int StokId { get; set; }

        [Required(ErrorMessage = "Tipo de movimentação é obrigatório.")]
        public string TypeStokMov { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatório.")]
        public decimal Quantity { get; set; }
        public DateTime DateMovement { get; set; }
    }
}
