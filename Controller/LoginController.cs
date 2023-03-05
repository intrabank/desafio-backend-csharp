using APIDesafioIntrabank.Data;
using APIDesafioIntrabank.Model;
using APIDesafioIntrabank.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioIntrabank.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly APIDbContext _context;

        public LoginController(APIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Fazer login, retornando token JWT
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Login efetuado com sucesso</response>
        /// <response code="404">Usuário ou senha errados</response>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);

            if (user == null) return NotFound("Usuário ou senha inválidos");

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                token = token
            };
        }

    }
}
