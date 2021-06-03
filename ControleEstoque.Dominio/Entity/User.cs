using System.Security.Cryptography;
using System.Text;

namespace ControleEstoque.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public User()
        {

        }

        public User(int id, string code, string name, string password, int role)
        {
            Id = id;
            Code = code;
            Name = name;
            Password = password;
            Role = role;
        }

        public string GetLowerName => Name.ToLower();
    }
}
