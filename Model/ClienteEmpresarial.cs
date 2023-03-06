using System.ComponentModel.DataAnnotations.Schema;

namespace APIDesafioIntrabank.Model
{
    [Table("tb_cliente_empresarial")]
    public class ClienteEmpresarial
    {
        public ClienteEmpresarial()
        {

        }

        public ClienteEmpresarial(string razaoSocial, string nomeFantasia, string cnpj, string telefone, string email, int enderecoId)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
            EnderecoId = enderecoId;
        }

        public int Id { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }

        public String Cnpj { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }

        public int EnderecoId { get; set; }
        public  virtual Endereco Endereco { get; set; } 
    }
}
