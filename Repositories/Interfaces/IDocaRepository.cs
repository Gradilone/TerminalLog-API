using TerminalLog.Api.Models;

namespace TerminalLog.Api.Repositories.Interfaces
{
    public interface IDocaRepository
    {
        Task Criar(Doca doca);
        Task<List<Doca>> ListarTodas();
        Task<Doca?> GetDocaId(int id); 
        Task Deletar(Doca doca);
        Task SalvarAlteracoes();
    }
}
