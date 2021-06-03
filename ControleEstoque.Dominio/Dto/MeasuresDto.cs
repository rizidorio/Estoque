using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Dto
{
    public class MeasuresDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Código é obrigatório.")]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "Código em formato inválido.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O Nome da medida deve ter até 20 caracteres.")]
        [MinLength(2, ErrorMessage = "O Nome da medida deve ter no mínimo 2 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A sigla é obrigatória.")]
        public string Initials { get; set; }

        public bool Inactive { get; set; }
    }
}
