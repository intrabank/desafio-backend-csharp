using System.ComponentModel.DataAnnotations.Schema;

namespace APIDesafioIntrabank.Model
{
    [Table("tb_endereco")]
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais  { get; set; }
        public ClienteEmpresarial ClienteEmpresarial { get; set; }

    }
}
