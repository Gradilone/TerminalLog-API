using TerminalLog.Api.Models;

namespace TerminalLog.Api.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Criar(Usuario usuario);
        Task<List<Usuario>> ListarTodos();
    }
}
