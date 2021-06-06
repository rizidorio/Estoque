using System;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "SKU é obrigatório.")]
        [RegularExpression(@"^[A-Z\d]{8,12}$", ErrorMessage = "SKU em formato inválido.")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo 100 caracteres.")]
        [MinLength(5, ErrorMessage = "O nome deve conter no mínimo 5 caracteres.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória.")]
        [MaxLength(30, ErrorMessage = "A categoria deve conter no máximo 30 caracteres.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Preço de custo é obrigatório.")]
        public decimal Cust { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ChangeDate { get; set; }
        public bool Inactive { get; set; }
    }
}
