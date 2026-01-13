using Microsoft.AspNetCore.Mvc;
using TerminalLog.Api.Models;
using TerminalLog.Api.Repositories.Interfaces;

namespace TerminalLog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IDocaRepository _docaRepository;

        public AgendamentoController(IAgendamentoRepository agendamentoRepository, IDocaRepository docaRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _docaRepository = docaRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _agendamentoRepository.GetAgendamentoId(id);
            if (agendamento == null)
            {
                return NotFound(new { mensagem = $"Agendamento com ID {id} não encontrado." });
            }
            return Ok(agendamento);
        }

        [HttpPost("criarAgendamento")]
        public async Task<IActionResult> Criar([FromBody] Agendamento agendamento)
        {
            if(agendamento.DataHoraChegada < DateTime.Now)
            {
                return BadRequest("A data e hora de chegada não pode ser no passado.");
            }

            var doca = await _docaRepository.GetDocaId(agendamento.DocaId);

            if(doca.CapacidadePeso < agendamento.PesoCarga)
            {
                return BadRequest("A carga excede a capacidade da doca.");
            }

            if(doca.Status != Enums.StatusDoca.Livre)
            {
                return BadRequest("A doca selecionada não está Livre no momento");
            }

            await _agendamentoRepository.Criar(agendamento);

            return CreatedAtAction(nameof(GetById), new { id = agendamento.Id }, agendamento);
        }

        [HttpPatch("cancelar/{id}")]
        public async Task<IActionResult> Cancelar(int id)
        {
            var agendamento = await _agendamentoRepository.GetAgendamentoId(id);
            if (agendamento == null) return NotFound("Agendamento não encontrado.");
            agendamento.Status = Enums.StatusAgendamento.Cancelado;

            await _agendamentoRepository.SalvarAlteracoes();

            return Ok(new { mensagem = "Agendamento cancelado com sucesso." });

        }



    }
}
