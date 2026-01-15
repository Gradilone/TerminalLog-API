using System.Text.Json.Serialization;
using static TerminalLog.Api.Models.Enums;

namespace TerminalLog.Api.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        public int DocaId { get; set; }
        [JsonIgnore]
        public Doca? Doca { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public string NumeroContainer { get; set; } = string.Empty;
        public string TipoContainer { get; set; } = string.Empty;
        public double PesoCarga { get; set; }
        public string PlacaVeiculo { get; set; } = string.Empty;
        public StatusAgendamento Status { get; set; } = StatusAgendamento.Ativo;
    }
}
