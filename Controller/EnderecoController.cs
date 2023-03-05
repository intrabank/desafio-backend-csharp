using APIDesafioIntrabank.Data;
using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioIntrabank.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IMapper _mapper;

        public EnderecoController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDTO> FindAll()
        {
            var enderecos = _context.Enderecos.ToList();
            return _mapper.Map<List<ReadEnderecoDTO>>(enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null) return NotFound("Endereco não encontrado");

            var enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);

            return Ok(enderecoDTO);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] CreateEnderecoDTO createEnderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(createEnderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction("FindById", new { id = endereco.Id }, endereco);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateEnderecoDTO updateEnderecoDTO)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null) return NotFound("Esse endereco não está cadastrado na base");

            _mapper.Map(updateEnderecoDTO, endereco);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null) return NotFound("Esse endereco não está cadastrado na base");

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
