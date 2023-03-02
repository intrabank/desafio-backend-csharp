using System.ComponentModel.DataAnnotations;

namespace desafio_backend.Controllers.Models
{
    public class Cliente
    {
        [Key]
        [MaxLength(4, ErrorMessage = "O CNPJ deve ter no máximo 4 caracteres")]
        public int CNPJ { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Razão Social deve ter entre 3 e 200 caracteres")]
        public string RazaoSocial { get; set; }
    }
}
