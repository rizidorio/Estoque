namespace ControleEstoque.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(int id, string code, string name, string password, string role)
        {
            Id = id;
            Code = code;
            Name = name;
            Password = password;
            Role = role;
        }
    }
}
