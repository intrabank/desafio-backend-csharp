using System.ComponentModel.DataAnnotations;

namespace APIDesafioIntrabank.Dto
{
    public class UpdateClienteDTO
    {
        [Required(ErrorMessage = "A razão social é obrigatória")]
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int EnderecoId { get; set; }
    }
}
