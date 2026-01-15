using Microsoft.AspNetCore.Mvc;
using TerminalLog.Api.Models;
using TerminalLog.Api.Repositories.Interfaces;
using TerminalLog.Api.Services;

namespace TerminalLog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public UsuarioController (IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro([FromBody] Usuario usuario)
        {
            var usuarioLogin = await _usuarioRepository.GetUsuarioEmail(usuario.Email);

            if (usuarioLogin != null)
            {
                return BadRequest(new { message = "Usuário com esse email já existente" });
            }

            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash);

            await _usuarioRepository.Criar(usuario);

            return CreatedAtAction(nameof(Cadastro), new { id = usuario.Id }, usuario);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario loginRequest)
        {
            var usuario = await _usuarioRepository.GetUsuarioEmail(loginRequest.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginRequest.SenhaHash, usuario.SenhaHash))
            {
                return Unauthorized(new { message = "Email ou senha inválidos" });
            }
            var token = _tokenService.GenerateToken(usuario);
            return Ok(new { token });

        }

    }
}
