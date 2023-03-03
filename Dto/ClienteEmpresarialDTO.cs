namespace APIDesafioIntrabank.Dto
{
    public class ClienteEmpresarialDTO
    {
        public ClienteEmpresarialDTO()
        {

        }

        public ClienteEmpresarialDTO(int id, string razaoSocial, string nomeFantasia, string cnpj, string telefone, string email, int enderecoId)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
            EnderecoId = enderecoId;
        }

        public ClienteEmpresarialDTO(string razaoSocial, string nomeFantasia, string cnpj, string telefone, string email, int enderecoId)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
            EnderecoId = enderecoId;
        }

        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int EnderecoId { get; set; }
    }
}
