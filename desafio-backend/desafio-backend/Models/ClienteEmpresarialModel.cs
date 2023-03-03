using System.ComponentModel.DataAnnotations;

namespace desafio_backend.Models
{
    public class ClienteEmpresarial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
    }
}
