using APIDesafioIntrabank.Data;
using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioIntrabank.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnderecoController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IMapper _mapper;

        public EnderecoController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Procurar todos os endereços
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Endereços retornados com sucesso</response>
        [HttpGet]
        public IEnumerable<ReadEnderecoDTO> FindAll([FromQuery] int skip = 0, [FromQuery] int take = 5)
        {
            var enderecos = _context.Enderecos.Skip(skip).Take(take).ToList();
            return _mapper.Map<List<ReadEnderecoDTO>>(enderecos);
        }

        /// <summary>
        /// Procurar endereço por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Endereço retornado com sucesso</response>
        /// <response code="404">Endereço não encontrado</response>
        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null) return NotFound("Endereco não encontrado");

            var enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);

            return Ok(enderecoDTO);
        }

        /// <summary>
        /// Inserir um endereço
        /// </summary>
        /// <param name="createEnderecoDTO"></param>
        /// <returns></returns>
        /// <response code="201">Endereço criado com sucesso</response>
        [HttpPost]
        public IActionResult Insert([FromBody] CreateEnderecoDTO createEnderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(createEnderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction("FindById", new { id = endereco.Id }, endereco);

        }

        /// <summary>
        /// Atualizar um endereço
        /// </summary>
        /// <param name="updateEnderecoDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Endereço atualizado com sucesso</response>
        /// <response code="404">Endereço não existe na base</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateEnderecoDTO updateEnderecoDTO)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null) return NotFound("Esse endereco não está cadastrado na base");

            _mapper.Map(updateEnderecoDTO, endereco);

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Deletar um endereço
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Endereço deletado com sucesso</response>
        /// <response code="404">Endereço não existe na base</response>
        /// /// <response code="400">Endereço está associado a um usuário</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null) return NotFound("Esse endereco não está cadastrado na base");

            var cliente = _context.ClientesEmpresariais.FirstOrDefault(c => c.EnderecoId == endereco.Id);

            if (cliente != null)
            {
                return BadRequest("Existe um cliente empresarial cadastrado com esse endereço.");
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
