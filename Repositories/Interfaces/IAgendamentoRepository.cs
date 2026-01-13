using TerminalLog.Api.Models;

namespace TerminalLog.Api.Repositories.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task Criar(Agendamento agendamento);
        Task<List<Agendamento>> ListarTodas();
        Task Deletar(Agendamento agendamento);
        Task SalvarAlteracoes();
        Task<Agendamento?> GetAgendamentoId(int id);
    }
}
