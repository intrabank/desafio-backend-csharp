using APIDesafioIntrabank.Data;
using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using APIDesafioIntrabank.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioIntrabank.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteEmpresarialController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IMapper _mapper;

        public ClienteEmpresarialController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            return Ok(clienteEmpresarial);
        }

        [HttpPost]
        public ActionResult<ClienteEmpresarialDTO> Insert([FromBody] CreateClienteDTO createClienteDTO)
        {
            var clienteExists = _context.ClientesEmpresariais.FirstOrDefault(c => c.Cnpj == createClienteDTO.Cnpj);

            if (clienteExists != null)
            {
                return BadRequest("Já existe um cliente empresarial cadastrado com esse CNPJ.");
            }

            var clienteEmpresarial = _mapper.Map<ClienteEmpresarial>(createClienteDTO);

            _context.ClientesEmpresariais.Add(clienteEmpresarial);
            _context.SaveChanges();

            return CreatedAtAction("FindById", new { id = clienteEmpresarial.Id }, clienteEmpresarial);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ClienteEmpresarialDTO clienteEmpresarialDTO)
        {
            if (id != clienteEmpresarialDTO.Id)
            {
                return BadRequest();
            }

            var ClienteEmpresarial = _context.ClientesEmpresariais.Find(id);

            if (ClienteEmpresarial == null)
            {
                return NotFound("Cliente não existe na base de dados");
            }

            ClienteEmpresarial.RazaoSocial = clienteEmpresarialDTO.RazaoSocial;
            ClienteEmpresarial.NomeFantasia = clienteEmpresarialDTO.NomeFantasia;
            ClienteEmpresarial.Cnpj = clienteEmpresarialDTO.Cnpj;
            ClienteEmpresarial.Telefone = clienteEmpresarialDTO.Telefone;
            ClienteEmpresarial.Email = clienteEmpresarialDTO.Email;

            var Endereco = _context.Enderecos.Find(clienteEmpresarialDTO.EnderecoId);

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
