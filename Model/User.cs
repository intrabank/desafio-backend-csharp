using System.ComponentModel.DataAnnotations.Schema;

namespace APIDesafioIntrabank.Model
{
    [Table("tb_user")]
    public class User
    {
        public User()
        {
        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
