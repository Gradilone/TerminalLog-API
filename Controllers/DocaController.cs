using Microsoft.AspNetCore.Mvc;
using TerminalLog.Api.Models;
using TerminalLog.Api.Repositories;
using TerminalLog.Api.Repositories.Interfaces;
using static TerminalLog.Api.Models.Enums;

namespace TerminalLog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocaController : ControllerBase
    {
        private readonly IDocaRepository _docaRepository;

        public DocaController(IDocaRepository docaRepository)
        {
            _docaRepository = docaRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var docas = await _docaRepository.ListarTodas();
            return Ok(docas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doca = await _docaRepository.GetDocaId(id);

            if (doca == null)
            {
                return NotFound(new { mensagem = $"Doca com ID {id} não encontrada." });
            }

            return Ok(doca);
        }

        [HttpPost("criarDoca")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Criar([FromBody] Doca doca)
        {
            if (string.IsNullOrEmpty(doca.CodigoDoca))
            {
                return BadRequest("O nome da doca é obrigatório.");
            }
            await _docaRepository.Criar(doca);
            return CreatedAtAction(nameof(GetById), new { id = doca.Id }, doca);
        }
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatusDoca(int id, [FromBody] StatusDoca novoStatus)
        {
            var doca = await _docaRepository.GetDocaId(id);
            if (doca == null) return NotFound("Doca não encontrada");
            if (novoStatus == StatusDoca.Manutencao && doca.Status == StatusDoca.Ocupada)
            {
                return BadRequest("Não é possível colocar em 'Manutenção' quando a doca está 'Ocupada'.");
            }

            doca.Status = novoStatus;

            await _docaRepository.SalvarAlteracoes();

            return Ok(new { Mensagem = "Status atualizado com sucesso", Doca = doca });

        }

        [HttpDelete]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deletar (int id)
        {
            var doca = await _docaRepository.GetDocaId(id);

            if (doca == null)
            {
                return NotFound(new { Mensagem = "Doca não encontrada." });
            }

            if (doca.Status == StatusDoca.Ocupada)
            {
                return BadRequest(new { Mensagem = "Não é possível deletar uma doca que está ocupada." });
            }

            try
            {
                await _docaRepository.Deletar(doca);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {Mensagem = "Ocorreu um erro ao tentar deletar a doca.", Detalhes = ex.Message });
            }
        }


    }
}
