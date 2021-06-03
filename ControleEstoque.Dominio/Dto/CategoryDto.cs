using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Código é obrigatório.")]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "Código em formato inválido.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [MaxLength(30, ErrorMessage = "O Nome deve ter no máximo 30 caracteres.")]
        [MinLength(5, ErrorMessage = "O Nome deve ter no mínimo 5 caracteres.")]
        public string Name { get; set; }

        public bool Inactive { get; set; }
    }
}
