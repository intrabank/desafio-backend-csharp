using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIDesafioIntrabank.Model
{
    [Table("tb_cliente_empresarial")]
    public class ClienteEmpresarial
    {
        public int Id { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String Cnpj { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public int EnderecoId { get; set; }

        [JsonIgnore]
        public  Endereco Endereco { get; set; } //Navegação
    }
}
