using desafio_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClienteEmpresarialModel>> BuscarTodosClientes()
        {
            return Ok();
        }
    }
}
