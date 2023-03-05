using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIDesafioIntrabank.Model
{
    [Table("tb_endereco")]
    public class Endereco
    {
        public Endereco()
        {

        }

        public Endereco(string rua, string cidade, string estado, string pais)
        {
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais  { get; set; }

        [JsonIgnore]
        public virtual ClienteEmpresarial ClienteEmpresarial { get; set; }

    }
}
