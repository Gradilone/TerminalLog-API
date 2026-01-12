namespace TerminalLog.Api.Models
{
    public class Enums
    {
        public enum StatusDoca
        {
            Livre = 1,
            Ocupada = 2,
            Manutencao = 3
        }

        public enum TipoOperacao
        {
            Carga = 1,
            Descarga = 2,
            Ambas = 3
        }

        public enum StatusAgendamento
        {
            Ativo = 1,
            Concluido = 2,
            Cancelado = 3
        }

        public enum UserRole
        {
            Admin = 1,
            Transportadora = 2
        }
    }
}
