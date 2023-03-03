using desafio_backend.Models;
using desafio_backend.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ICliente _clienteRepositorio;

        public ClienteController(ICliente clienteRespositorio) 
        {
            _clienteRepositorio = clienteRespositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteEmpresarialModel>>> BuscarTodosClientes()
        {
            List<ClienteEmpresarialModel> clientes = await _clienteRepositorio.BuscarTodosClientes();
            clientes = clientes.OrderBy(c => c.RazaoSocial).ToList();
            return Ok(clientes);
        }

        [HttpGet("buscarPorId/{id}")]   
        public async Task<ActionResult<List<ClienteEmpresarialModel>>> BuscarPorId(int id)
        {
            ClienteEmpresarialModel cliente = await _clienteRepositorio.BuscarPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteEmpresarialModel>> Cadastrar([FromBody] ClienteEmpresarialModel clienteModel)
        {
            ClienteEmpresarialModel cliente = await _clienteRepositorio.Adicionar(clienteModel);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteEmpresarialModel>> Atualizar([FromBody] ClienteEmpresarialModel clienteModel, int id)
        {
            clienteModel.Id = id;
            ClienteEmpresarialModel cliente = await _clienteRepositorio.Atualizar(clienteModel, id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteEmpresarialModel>> Apagar(int id)
        {
            bool apagado = await _clienteRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
