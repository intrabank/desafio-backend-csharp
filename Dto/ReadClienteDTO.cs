using APIDesafioIntrabank.Model;

namespace APIDesafioIntrabank.Dto
{
    public class ReadClienteDTO
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public ReadEnderecoDTO Endereco { get; set; }
    }
}
