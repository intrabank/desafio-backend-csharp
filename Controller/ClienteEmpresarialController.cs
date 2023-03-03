using APIDesafioIntrabank.Data;
using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            if (clienteEmpresarial == null) return NotFound("Cliente empresarial não encontrado");

            return clienteEmpresarial;
        }

        [HttpPost]
        public ActionResult<ClienteEmpresarialDTO> Insert([FromBody] ClienteEmpresarialDTO clienteEmpresarialDTO)
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

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ClienteEmpresarialDTO ClienteEmpresarialDTO)
        {
            if (id != ClienteEmpresarialDTO.Id)
            {
                return BadRequest();
            }

            var ClienteEmpresarial = _context.ClientesEmpresariais.Find(id);

            if (ClienteEmpresarial == null)
            {
                return NotFound("Cliente não existe na base de dados");
            }

            ClienteEmpresarial.RazaoSocial = ClienteEmpresarialDTO.RazaoSocial;
            ClienteEmpresarial.NomeFantasia = ClienteEmpresarialDTO.NomeFantasia;
            ClienteEmpresarial.Cnpj = ClienteEmpresarialDTO.Cnpj;
            ClienteEmpresarial.Telefone = ClienteEmpresarialDTO.Telefone;
            ClienteEmpresarial.Email = ClienteEmpresarialDTO.Email;

            var Endereco = _context.Enderecos.Find(ClienteEmpresarialDTO.EnderecoId);

            if (Endereco == null)
            {
                return BadRequest("Endereço inválido");
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ClienteEmpresarial = _context.ClientesEmpresariais.FirstOrDefault(c => c.Id == id);

            if (ClienteEmpresarial == null) return NotFound("Cliente não existe na base de dados");

            _context.ClientesEmpresariais.Remove(ClienteEmpresarial);
            _context.SaveChanges();

            return NoContent();

        }

    }
}
