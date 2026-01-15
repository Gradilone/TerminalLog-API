using TerminalLog.Api.Models;

namespace TerminalLog.Api.Repositories.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
