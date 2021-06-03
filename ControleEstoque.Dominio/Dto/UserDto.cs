using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace ControleEstoque.Domain.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do Usuário é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter mo máximo 50 caracteres.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 03 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Código do Usuário é obrigatório.")]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "Código em formato inválido.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatório.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O Perfil é obrigatório.")]
        public int Role { get; set; }

        public string GetHashPassword()
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(Password);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
