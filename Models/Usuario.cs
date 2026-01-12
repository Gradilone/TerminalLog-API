using static TerminalLog.Api.Models.Enums;

namespace TerminalLog.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Transportadora;
    }
}
