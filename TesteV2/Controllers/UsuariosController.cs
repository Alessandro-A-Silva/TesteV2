using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using TesteV2.Entities;
using TesteV2.Interfaces.Services;
using TesteV2.Request.Usuarios;

namespace TesteV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {   
        private readonly IUsuariosService _usuariosService;
        public UsuariosController(IUsuariosService usuariosService) => _usuariosService = usuariosService;

        [HttpPost("Cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] PostUsuarios request)
        {
            try
            {
                MailAddress mailAddress;
                mailAddress = new MailAddress(request.Email);
            }
            catch(Exception)
            {
                 return StatusCode(StatusCodes.Status400BadRequest,$"O endereço de e-mail {request.Email} não é valido.");
            }
            var usuario = await _usuariosService.ReadByEmail(request.Email);

            if (usuario != null)
                return StatusCode(StatusCodes.Status400BadRequest, $"O endereço de email {request.Email} já está em uso.");

            try
            {
                await _usuariosService.Create(request);
                return StatusCode(StatusCodes.Status201Created, $"Usuário cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar usuário. {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(Usuarios),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromForm] PostLogin request)
        {
            try
            {
                var usuario = await _usuariosService.ReadByEmail(request.Email);
                if (usuario == null)
                    return StatusCode(StatusCodes.Status400BadRequest,"Usuario não existe");

                if (usuario.Senha != request.Senha)
                    return StatusCode(StatusCodes.Status400BadRequest, "Senha incorreta.");

                return Ok(usuario);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar efetuar login. {ex.Message}");
            }
        }

        [HttpPut("Atualizar")]
        [ProducesResponseType(typeof(Usuarios), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] Usuarios request)
        {
            try
            {
                await _usuariosService.Update(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar usuario. {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Usuarios>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ReadAll([FromQuery] Usuarios filter)
        {
            try
            {
                var usuarios = await _usuariosService.ReadAll(filter);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao ler usuarios. {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await _usuariosService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar usuario. {ex.Message}");
            }
        }
    }
}
