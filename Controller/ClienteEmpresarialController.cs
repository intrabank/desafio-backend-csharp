using APIDesafioIntrabank.Data;
using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioIntrabank.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteEmpresarialController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ClienteEmpresarialController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ClienteEmpresarialDTO> FindAll()
        {
            return _context.ClientesEmpresariais.Select(
                c => new ClienteEmpresarialDTO(
                    c.Id, c.RazaoSocial, c.NomeFantasia, c.Cnpj, c.Telefone, c.Email, c.EnderecoId)
                ).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteEmpresarialDTO> FindById(int id)
        {
            var clienteEmpresarial = _context.ClientesEmpresariais.Where(c => c.Id == id)
                .Select(c => new ClienteEmpresarialDTO
                (c.Id, c.RazaoSocial, c.NomeFantasia, c.Cnpj, c.Telefone, c.Email, c.EnderecoId)).FirstOrDefault();

            if (clienteEmpresarial == null) return NotFound("Cliente não encontrado");

            return clienteEmpresarial;
        }

        [HttpPost]
        public ActionResult<ClienteEmpresarialDTO> Insert(ClienteEmpresarialDTO clienteEmpresarialDTO)
        {
            var clienteEmpresarial = new ClienteEmpresarial()
            {
                RazaoSocial = clienteEmpresarialDTO.RazaoSocial,
                NomeFantasia = clienteEmpresarialDTO.NomeFantasia,
                Cnpj = clienteEmpresarialDTO.Cnpj,
                Telefone = clienteEmpresarialDTO.Telefone,
                Email = clienteEmpresarialDTO.Email,
                EnderecoId = clienteEmpresarialDTO.EnderecoId
            };

            _context.ClientesEmpresariais.Add(clienteEmpresarial);
            _context.SaveChanges();

            return CreatedAtAction("FindById", new { id = clienteEmpresarial.Id }, clienteEmpresarial);
        }

    }
}
