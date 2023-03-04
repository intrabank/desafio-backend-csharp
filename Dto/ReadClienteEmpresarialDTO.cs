using APIDesafioIntrabank.Model;

namespace APIDesafioIntrabank.Dto
{
    public class ReadClienteEmpresarialDTO
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int EnderecoId { get; set; }
        public DateTime HoraConsulta { get; set; } = DateTime.Now;
    }
}
