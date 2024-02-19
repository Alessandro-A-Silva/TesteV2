using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using TesteV2.Entities;
using TesteV2.Interfaces.Services;
using TesteV2.Request.PessoasFisicas;
using TesteV2.Request.Usuarios;
using TesteV2.Services;

namespace TesteV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasFisicasController : ControllerBase
    {
        private readonly IPessoasFisicasService _pessoasFisicasService;
        public PessoasFisicasController(IPessoasFisicasService pessoasFisicasService) => _pessoasFisicasService = pessoasFisicasService;

        [HttpPost("Cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PostPessoasFisicas request)
        {
            try
            {
                MailAddress mailAddress;
                mailAddress = new MailAddress(request.Email);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"O endereço de e-mail {request.Email} não é valido.");
            }

            var usuarioEmail = await _pessoasFisicasService.ReadByEmail(request.Email);
            if (usuarioEmail != null)
                return StatusCode(StatusCodes.Status400BadRequest, $"O endereço de email {request.Email} já está em uso.");

            var usuarioCpf = await _pessoasFisicasService.ReadByCpf(request.Cpf);
            if(usuarioCpf != null)
                return StatusCode(StatusCodes.Status400BadRequest, $"O endereço de cpf {request.Email} já está em uso.");

            try
            {
                await _pessoasFisicasService.Create(request);
                return StatusCode(StatusCodes.Status201Created, $"Pessoa física cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar pessoa física. {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PessoasFisicas>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ReadAll([FromQuery] GetPessoasFisicas filter)
        {
            try
            {
                var pessoasFisicas = await _pessoasFisicasService.ReadAll(filter);
                return Ok(pessoasFisicas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao ler pessoas físicas. {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await _pessoasFisicasService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar pessoa física. {ex.Message}");
            }
        }

        [HttpPut("Atualizar")]
        [ProducesResponseType(typeof(Usuarios), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] PessoasFisicas request)
        {
            try
            {
                await _pessoasFisicasService.Update(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar pessoa física. {ex.Message}");
            }
        }
    }
}
