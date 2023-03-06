using APIDesafioIntrabank.Data;
using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using APIDesafioIntrabank.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioIntrabank.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IMapper _mapper;

        public UserController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Fazer login, retornando token JWT
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Login efetuado com sucesso</response>
        /// <response code="404">Usuário ou senha errados</response>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserDTO model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);

            if (user == null) return NotFound("Usuário ou senha inválidos");

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        /// <summary>
        /// Cadastrar um novo usuário, retornando token JWT
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Cadastro efetuado com sucesso</response>
        [HttpPost("cadastro")]
        public ActionResult<dynamic> Insert([FromBody] UserDTO model)
        {
            var user = _mapper.Map<User>(model);
            _context.Add(user);
            _context.SaveChanges();

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
